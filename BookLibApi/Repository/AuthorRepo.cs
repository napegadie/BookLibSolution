using BookLibApi.Core.Entities;
using BookLibApi.DataStore;
using BookLibApi.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BookLibApi.Repository
{
    public class AuthorRepo : IAuthorRepo
    {
        private BookDbContext _context;
        public AuthorRepo(BookDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAuthorAsync(Author newAuthor)
        {
            if (newAuthor == null)
            {
                throw new ArgumentNullException(nameof(newAuthor));
            }

            var _author = new Author()
            {
                LastName = newAuthor.LastName,
                FirstName = newAuthor.FirstName
            };


            await _context.Authors!.AddAsync(_author);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<bool> DeleteAuthorSync(int authorId)
        {
            var _author = await _context.Authors!.FirstOrDefaultAsync(n => n.AuthorId == authorId);

            if (_author == null)
            {
                throw new Exception($"The author with id: {authorId} does not exist");

            }

            _context.Authors!.Remove(_author);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            return await _context.Authors!
                          .Include(g => g.Book_Authors)
                          .Select(b => new AuthorDto()
                          {
                              AuthorId = b.AuthorId,
                              FirstName=b.FirstName,
                              LastName=b.LastName
                          }).ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            var _authorData = await _context.Authors!.Where(p => p.AuthorId == authorId)
                                     .Include(p => p.Book_Authors)
                                     .FirstOrDefaultAsync();

            return _authorData!;
        }

        public async Task<Author> GetAuthorByNameAsync(string name)
        {
            var _authorData = await _context.Authors!.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name))
                                     .Include(p => p.Book_Authors)
                                     .FirstOrDefaultAsync();

            return _authorData!;
        }

        public async Task<bool> UpdateAuthorAsync(Author newAuthor)
        {
            var _author = _context.Authors!.FirstOrDefault(n => n.AuthorId == newAuthor.AuthorId);

            if (_author == null)
            {
                throw new ArgumentNullException(nameof(_author));

            }

            _author.FirstName = newAuthor.FirstName;
            _author.LastName = newAuthor.LastName;
            _context.Entry(_author).State = EntityState.Modified;
            bool resp = await _context.SaveChangesAsync() >= 1;

            return (resp);
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
