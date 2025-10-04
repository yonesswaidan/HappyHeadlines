using HappyHeadlines.Services;

namespace HappyHeadlines
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("📰 HappyHeadlines Cache Simulation starting...\n");

            var articleCache = new ArticleCache();
            var commentCache = new CommentCache();
            var dashboard = new DashboardService(articleCache, commentCache);

            // preload latest 14 days of articles
            articleCache.PreloadArticles();

            // run for 60 seconds
            var cts = new CancellationTokenSource();
            var simulation = RunSimulation(articleCache, commentCache, cts.Token);
            var dashboardTask = dashboard.StartUpdating(cts.Token);

            await Task.Delay(TimeSpan.FromSeconds(60));
            cts.Cancel();

            await Task.WhenAll(simulation, dashboardTask);
            Console.WriteLine("\n✅ Simulation complete. Press any key to exit...");
            Console.ReadKey();
        }

        static async Task RunSimulation(ArticleCache articleCache, CommentCache commentCache, CancellationToken token)
        {
            var random = new Random();
            while (!token.IsCancellationRequested)
            {
                var articleId = random.Next(1, 100);
                _ = articleCache.GetArticle(articleId);

                if (random.NextDouble() < 0.6)
                    _ = commentCache.GetCommentsForArticle(articleId);

                await Task.Delay(300);
            }
        }
    }
}
