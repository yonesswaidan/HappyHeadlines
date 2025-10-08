using Microsoft.AspNetCore.Mvc;
using CommentService.Models;
using CommentService.Services;

namespace CommentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly RedisCacheService _cache;
        private readonly CacheStats _stats;

        private static readonly Dictionary<string, List<Comment>> _database = new();

        public CommentsController(RedisCacheService cache, CacheStats stats)
        {
            _cache = cache;
            _stats = stats;
        }

        [HttpGet("{articleId}")]
        public async Task<IActionResult> Get(string articleId)
        {
            var cached = await _cache.GetAsync<List<Comment>>($"comments:{articleId}");
            if (cached != null)
            {
                _stats.RecordHit();
                return Ok(new { source = "cache", data = cached });
            }

            if (!_database.TryGetValue(articleId, out var comments))
                return NotFound();

            _stats.RecordMiss();
            await _cache.SetAsync($"comments:{articleId}", comments, TimeSpan.FromMinutes(10));
            return Ok(new { source = "database", data = comments });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            if (!_database.ContainsKey(comment.ArticleId))
                _database[comment.ArticleId] = new List<Comment>();

            _database[comment.ArticleId].Add(comment);
            await _cache.RemoveAsync($"comments:{comment.ArticleId}"); // refresh cache
            return Ok(comment);
        }
    }
}
