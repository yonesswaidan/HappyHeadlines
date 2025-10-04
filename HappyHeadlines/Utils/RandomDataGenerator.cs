using HappyHeadlines.Models;

namespace HappyHeadlines.Utils
{
    public static class RandomDataGenerator
    {
private static readonly string[] Headlines = new[]
{
    "Katten stjal morgenmaden fra naboen",
    "Byens café har fået ny barista – kaffen er nu perfekt",
    "Børnene maler hele skolen i regnbuens farver",
    "Biblioteket åbner igen efter renovering",
    "Fodboldklubben vandt den lokale turnering",
    "Lokal bor finder sjældent mønster i skoven"
};

        private static readonly string[] CommentTexts = new[]
        {
            "Sjov artikel, måtte smile højt!",
            "Helt enig med det her",
            "Hmm, det virker lidt underligt",
            "Kan nogen forklare, hvad der menes?",
            "Super godt skrevet!",
            "Det her kunne jeg godt relatere til",
            "Interessant, havde ikke tænkt på det før",
            "Haha, det er lige noget for mig",
            "Tak for infoen, lærte noget nyt",
            "Synes det her var lidt overdrevet"
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
