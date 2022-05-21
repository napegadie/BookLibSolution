using System.ComponentModel.DataAnnotations;

namespace BookLibApi.Core.Entities
{
    public class Publisher
    {
        [Key]
        [Required]
        public int PublisherId { get; set; }
        public string Name { get; set; } = string.Empty;

        //Navigation Properties
        public List<Book>? Books { get; set; }
    }
}
