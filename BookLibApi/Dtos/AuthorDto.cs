using System.ComponentModel.DataAnnotations;

namespace BookLibApi.Dtos
{
    public class AuthorDto
    {
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
    }
}
