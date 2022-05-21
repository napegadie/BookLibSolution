namespace BookLibWebMvc.EntitiesDto
{
    public class PublisherDto
    {
        public int PublisherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string>? Books { get; set; }
    }
}
