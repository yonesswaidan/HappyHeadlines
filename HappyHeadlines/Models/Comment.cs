namespace HappyHeadlines.Models
{
    public class Comment
    {
        public int ArticleId { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime PostedAt { get; set; }
    }
}
