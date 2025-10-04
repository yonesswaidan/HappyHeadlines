namespace HappyHeadlines.Services
{
    public class DashboardService
    {
        private readonly ArticleCache _articleCache;
        private readonly CommentCache _commentCache;

        public DashboardService(ArticleCache articleCache, CommentCache commentCache)
        {
            _articleCache = articleCache;
            _commentCache = commentCache;
        }

        public async Task StartUpdating(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine($"\n--- Dashboard update ---");
                Console.WriteLine($"ArticleCache hit ratio: {_articleCache.HitRatio:F2} %");
                Console.WriteLine($"CommentCache hit ratio: {_commentCache.HitRatio:F2} %");
                await Task.Delay(3000);
            }
        }
    }
}
