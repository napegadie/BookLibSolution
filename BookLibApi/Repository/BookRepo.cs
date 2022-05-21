using BookLibApi.Core.Entities;
using BookLibApi.DataStore;
using BookLibApi.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BookLibApi.Repository
{
    public class BookRepo : IBookRepo
    {
        private BookDbContext _context;
        public BookRepo(BookDbContext context)
        {
            _context = context;
        }

        public async Task<DropDownDto> GetCreateValuesForDropdowns()
        {
            var response = new DropDownDto()
            {
                Genres = await _context.Genres
                                       .Select(g => new GenreDto()
                                       {
                                           GenreId = g.GenreId,
                                           GenreName = g.GenreName
                                       })
                                       .OrderBy(n => n.GenreName).ToListAsync(),
                Publishers = await _context.Publishers.Include(p => p.Books)
                                           .Select(p => new PublisherDto()
                                            {
                                                PublisherId = p.PublisherId,
                                                Name = p.Name
                                            })
                                           .OrderBy(n => n.Name).ToListAsync(),
                Authors = await _context.Authors
                                        .Select(a => new AuthorDto()
                                        {
                                            AuthorId = a.AuthorId,
                                            FirstName = a.FirstName,
                                            LastName = a.LastName
                                        })
                                        .OrderBy(n => n.FirstName).ToListAsync()
            };

            return response;
        }

        public async Task<DropDownDto> GetUpdateValuesForDropdowns()
        {
            var response = new DropDownDto()
            {
                Genres = await _context.Genres
                                       .Select(g => new GenreDto()
                                       {
                                           GenreId = g.GenreId,
                                           GenreName = g.GenreName
                                       })
                                       .OrderBy(n => n.GenreName).ToListAsync(),
                Publishers = await _context.Publishers
                                           .Select(p => new PublisherDto()
                                           {
                                               PublisherId = p.PublisherId,
                                               Name = p.Name
                                           })
                                           .OrderBy(n => n.Name).ToListAsync(),
                Authors = await _context.Authors
                                        .Select(a => new AuthorDto()
                                        {
                                            AuthorId = a.AuthorId,
                                            FirstName = a.FirstName,
                                            LastName = a.LastName
                                        })
                                        .OrderBy(n => n.FirstName).ToListAsync()
            };

            return response;
        }

        public async Task<bool> AddBookAsync(Book newBook)
        {

            if (newBook == null)
            {
                throw new ArgumentNullException(nameof(newBook));
            }

            //var _book = new Book()
            //{
            //    Title = newBook.Title,
            //    Description = newBook.Description,
            //    DatePublished = newBook.DatePublished,
            //    CoverUrl = newBook.CoverUrl,
            //    PublisherId = newBook.PublisherId,
            //    GenreId = newBook.GenreId
            //};


            await _context.Books.AddAsync(newBook);
            bool resp = await _context.SaveChangesAsync() >= 1;

            if (!resp)
            {
                return false;
            }


            return resp;
        }

        public async Task<bool> DeleteBookSync(int bookId)
        {
            var _book = await _context.Books.FirstOrDefaultAsync(n => n.BookId == bookId);

            if (_book == null)
            {
                throw new Exception($"The publisher with id: {bookId} does not exist");

            }

            _context.Books.Remove(_book);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var bookDto = await _context.Books
                               .Include(b => b.BookGenre)
                               .Include(b => b.Publisher)
                               .Include(b => b.Book_Authors).ThenInclude(b => b.Author)
                               .Select(b => new BookDto()
                               {
                                   BookId = b.BookId,
                                   Title = b.Title,
                                   Description = b.Description,
                                   DatePublished = b.DatePublished,
                                   CoverUrl = b.CoverUrl,
                                   PublisherId = b.PublisherId,
                                   PublisherName = b.Publisher.Name,
                                   GenreId = b.GenreId,
                                   GenreName = b.BookGenre.GenreName,
                                   AuthorIds = b.Book_Authors.Select(b => b.AuthorId).ToList()
                               }).ToListAsync();

            return bookDto;
        }


        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            var bookDetails = await _context.Books
                .Include(p => p.Publisher)
                .Include(g => g.BookGenre)
                .Include(ba => ba.Book_Authors)
                .FirstOrDefaultAsync(b => b.BookId == bookId);

            return bookDetails;

        }

        public async Task<Book> GetBookByNameAsync(string title)
        {
            var _bookData = await _context.Books.Where(p => p.Title.Contains(title))
                                     .Include(p => p.Book_Authors)
                                     .FirstOrDefaultAsync();

            return _bookData;
        }

        public async Task<bool> UpdateBookAsync(Book newBook)
        {
            var _book = _context.Books.FirstOrDefault(n => n.BookId == newBook.BookId);

            if (_book == null)
            {
                throw new ArgumentNullException(nameof(_book));

            }

            _book.Title = newBook.Title;
            _book.Description = newBook.Description;
            _book.DatePublished = newBook.DatePublished;
            _book.CoverUrl = newBook.CoverUrl;
            _book.PublisherId = newBook.PublisherId;
            _book.GenreId = newBook.GenreId;

            _context.Entry(_book).State = EntityState.Modified;
            bool resp = await _context.SaveChangesAsync() >= 1;

            return (resp);
        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
