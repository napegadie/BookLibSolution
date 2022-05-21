using BookLibApi.Core.Entities;

namespace BookLibApi.Dtos
{
    public class DropDownDto
    {
        public DropDownDto()
        {
            Genres = new List<GenreDto>();
            Publishers = new List<PublisherDto>();
            Authors = new List<AuthorDto>();
        }

        public List<GenreDto> Genres { get; set; }
        public List<PublisherDto> Publishers { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
