using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibApi.Core.Entities
{
    public class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DatePublished { get; set; }
        public string CoverUrl { get; set; } = string.Empty;

        //Navigation Properties
        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher? Publisher { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre? BookGenre { get; set; }

        public List<Book_Author>? Book_Authors { get; set; }
    }
}
