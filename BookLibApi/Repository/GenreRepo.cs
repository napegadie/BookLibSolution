using BookLibApi.Core.Entities;
using BookLibApi.DataStore;
using BookLibApi.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BookLibApi.Repository
{
    public class GenreRepo : IGenreRepo
    {
        private BookDbContext _context;
        public GenreRepo(BookDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddGenreAsync(Genre newGenre)
        {
            if (newGenre == null)
            {
                throw new ArgumentNullException(nameof(newGenre));
            }

            var _genre = new Genre()
            {
                GenreName = newGenre.GenreName
            };


            _context.Genres.Add(_genre);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }


        public async Task<bool> UpdateGenreAsync(Genre newGenre)
        {
            var _genre = _context.Genres.FirstOrDefault(n => n.GenreId == newGenre.GenreId);

            if (_genre == null)
            {
                throw new ArgumentNullException(nameof(_genre));

            }

            _genre.GenreName = newGenre.GenreName;
            bool resp = await _context.SaveChangesAsync() >= 1;

            return (resp);
        }

        public async Task<bool> DeleteGenreSync(int genreId)
        {
            var _genre = await _context.Genres.FirstOrDefaultAsync(n => n.GenreId == genreId);

            if (_genre == null)
            {
                throw new Exception($"The genre with id: {genreId} does not exist");

            }

            _context.Genres.Remove(_genre);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
        {
            return await _context.Genres
                          .Include(g => g.Books)
                          .Select(b => new GenreDto()
                          {
                              GenreId = b.GenreId,
                              GenreName = b.GenreName
                          }).ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int genreId)
        {
            var _genreData = await _context.Genres.Where(g => g.GenreId == genreId)
                                     .Include(g => g.Books)
                                     .FirstOrDefaultAsync();

            return _genreData;
        }

        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            var _genreData = await _context.Genres.Where(g => g.GenreName.Contains(name))
                                     .Include(g => g.Books)
                                     .FirstOrDefaultAsync();

            return _genreData;
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
