using HappyHeadlines.Models;

namespace HappyHeadlines.Utils
{
    public static class RandomDataGenerator
    {
        private static readonly string[] Headlines = new[]
        {
            "Breaking News: AI changes everything",
            "EASV students ace the semester project",
            "Blazor overtakes React in popularity",
            "C# 13 adds revolutionary features",
            "SpaceX lands on Mars",
            "Developers demand more coffee breaks"
        };

        private static readonly string[] CommentTexts = new[]
        {
            "Great article!",
            "I totally agree with this.",
            "This is nonsense!",
            "Can someone explain this further?",
            "Nice job!"
        };

        public static Article GenerateArticle(int id)
        {
            var random = new Random(id);
            return new Article
            {
                Id = id,
                Headline = Headlines[random.Next(Headlines.Length)],
                PublishDate = DateTime.UtcNow.AddDays(-random.Next(1, 14))
            };
        }

        public static List<Comment> GenerateComments(int articleId)
        {
            var random = new Random(articleId * 13);
            int count = random.Next(1, 6);
            var comments = new List<Comment>();

            for (int i = 0; i < count; i++)
            {
                comments.Add(new Comment
                {
                    ArticleId = articleId,
                    Author = $"User{random.Next(1, 100)}",
                    Text = CommentTexts[random.Next(CommentTexts.Length)],
                    PostedAt = DateTime.UtcNow.AddMinutes(-random.Next(1, 1000))
                });
            }
            return comments;
        }
    }
}
