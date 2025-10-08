using Microsoft.AspNetCore.Mvc;
using ArticleService.Models;
using ArticleService.Services;

namespace ArticleService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly RedisCacheService _cache;
        private readonly CacheStats _stats;

        private static readonly Dictionary<string, Article> _database = new();

        public ArticlesController(RedisCacheService cache, CacheStats stats)
        {
            _cache = cache;
            _stats = stats;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var cached = await _cache.GetAsync<Article>($"article:{id}");
            if (cached != null)
            {
                _stats.RecordHit();
                return Ok(new { source = "cache", data = cached });
            }

            if (!_database.TryGetValue(id, out var article))
                return NotFound();

            _stats.RecordMiss();
            await _cache.SetAsync($"article:{id}", article, TimeSpan.FromMinutes(10));
            return Ok(new { source = "database", data = article });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Article article)
        {
            _database[article.Id] = article;
            await _cache.SetAsync($"article:{article.Id}", article, TimeSpan.FromMinutes(10));
            return Ok(article);
        }
    }
}
