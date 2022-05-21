using BookLibApi.Core.Entities;
using BookLibApi.DataStore;
using System.Text.RegularExpressions;

namespace BookLibApi.Repository
{
    public class BookAuthorRepo : IBookAuthorRepo
    {
        private BookDbContext _context;
        public BookAuthorRepo(BookDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddBook_AuthorAsync(List<int>? authorIds, int bookId)
        {
            bool resp = false;

            try
            {
                if (authorIds != null)
                {
                    foreach (var id in authorIds)
                    {
                        var _book_author = new Book_Author()
                        {
                            BookId = bookId,
                            AuthorId = id
                        };
                        await _context.Book_Authors.AddAsync(_book_author);
                    }

                    resp = await _context.SaveChangesAsync() >= 1;
                    return resp;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return resp;
            }
        }

        public async Task<bool> DeleteBook_AuthorSync(int bookId)
        {
            bool resp = false;

            try
            {
                var list = _context.Book_Authors.Where(ba => ba.BookId == bookId).ToList();

                if (list.Count == 0)
                {
                    //throw new Exception($"The No Author match found for Book with id: {bookId}");
                    return resp;

                }

                _context.Book_Authors.RemoveRange(list);
                resp = await _context.SaveChangesAsync() >= 1;

                return resp;
            }
            catch (Exception ex)
            {
                return resp;
            }

        }

        public async Task<bool> UpdateBook_AuthorAsync(List<int>? authorIds, int bookId)
        {
            bool resp = false;
            try
            {
                var list = _context.Book_Authors.Where(ba => ba.BookId == bookId).ToList();

                if (list == null)
                {
                    throw new Exception($"The No Author match found for Book with id: {bookId}");

                }

                _context.Book_Authors.RemoveRange(list);
                resp = await _context.SaveChangesAsync() >= 1;

                if (resp && authorIds != null)
                {
                    foreach (var id in authorIds)
                    {
                        var _book_author = new Book_Author()
                        {
                            BookId = bookId,
                            AuthorId = id
                        };
                        await _context.Book_Authors.AddAsync(_book_author);
                    }

                    resp = await _context.SaveChangesAsync() >= 1;
                    return resp;
                }
                else
                {
                    return resp;
                }
            }
            catch (Exception ex)
            {
                return resp;
            }

        }

        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
