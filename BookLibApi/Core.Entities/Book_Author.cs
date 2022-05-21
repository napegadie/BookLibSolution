using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibApi.Core.Entities
{
    public class Book_Author
    {
        [Key]
        [Required]
        public int Book_AuthorId { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }


        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}
