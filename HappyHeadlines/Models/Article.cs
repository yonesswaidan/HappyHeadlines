namespace HappyHeadlines.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Headline { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
    }
}
