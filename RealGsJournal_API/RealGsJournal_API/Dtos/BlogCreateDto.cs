namespace RealGsJournal_API.Dtos
{
    public class BlogCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public bool IsPublished { get; set; }
    }
}

