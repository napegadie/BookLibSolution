using BookLibApi.Core.Entities;
using BookLibApi.Dtos;

namespace BookLibApi.Repository
{
    public interface IGenreRepo
    {
        // Collection
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();
        Task<bool> AddGenreAsync(Genre newGenre);
        //Genre GetGenreById(int genreId);
        Task<Genre> GetGenreByIdAsync(int genreId);
        //Genre GetGenreByName(string name);
        Task<Genre> GetGenreByNameAsync(string name);
        //Genre UpdateGenre(int genreId, Genre newGenre);
        Task<bool> UpdateGenreAsync(Genre newGenre);
        //void DeleteGenre(int genreId);
        Task<bool> DeleteGenreSync(int genreId);
    }
}
