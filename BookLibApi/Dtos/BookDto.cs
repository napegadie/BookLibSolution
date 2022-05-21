namespace BookLibApi.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DatePublished { get; set; }
        public string CoverUrl { get; set; } = string.Empty;
        public string PublisherName { get; set; } = string.Empty;
        public int PublisherId { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public List<int>? AuthorIds { get; set; }
    }
}
