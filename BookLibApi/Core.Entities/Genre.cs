using System.ComponentModel.DataAnnotations;

namespace BookLibApi.Core.Entities
{
    public class Genre
    {
        [Key]
        [Required]
        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;

        public List<Book>? Books { get; set; }
    }
}
