using HappyHeadlines.Models;
using HappyHeadlines.Utils;

namespace HappyHeadlines.Services
{
    public class CommentCache : CacheService<int, List<Comment>>
    {
        private readonly Queue<int> _recentKeys = new();

        public override List<Comment> LoadItem(int key)
        {
            if (_recentKeys.Count >= 30)
                _cache.TryRemove(_recentKeys.Dequeue(), out _);

            _recentKeys.Enqueue(key);
            return RandomDataGenerator.GenerateComments(key);
        }

        public List<Comment> GetCommentsForArticle(int articleId)
        {
            return GetItem(articleId);
        }
    }
}
