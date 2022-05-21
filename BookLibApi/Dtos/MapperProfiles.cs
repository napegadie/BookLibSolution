using AutoMapper;
using BookLibApi.Core.Entities;

namespace BookLibApi.Dtos
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Author, AuthorDto>()
                    .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ReverseMap();
                cfg.CreateMap<BookDto, Book>()
                    .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
                    .ReverseMap();
                cfg.CreateMap<GenreDto, Genre>()
                    .ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => src.GenreId))
                    .ReverseMap();
                cfg.CreateMap<PublisherDto, Publisher>()
                    .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.PublisherId))
                    .ReverseMap();
            });
        }
    }
}
