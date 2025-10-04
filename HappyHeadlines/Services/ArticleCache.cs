using HappyHeadlines.Models;
using HappyHeadlines.Utils;

namespace HappyHeadlines.Services
{
    public class ArticleCache : CacheService<int, Article>
    {
        public override Article LoadItem(int key)
        {
            return RandomDataGenerator.GenerateArticle(key);
        }

        public void PreloadArticles()
        {
            for (int i = 1; i <= 50; i++)
            {
                GetItem(i);
            }
        }

        public Article GetArticle(int id)
        {
            return GetItem(id);
        }
    }
}
