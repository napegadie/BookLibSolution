using System.ComponentModel.DataAnnotations;

namespace BookLibApi.Core.Entities
{
    public class Author
    {
        [Key]
        [Required]
        public int AuthorId { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        //Navigations Properties
        public List<Book_Author>? Book_Authors { get; set; }
    }
}
