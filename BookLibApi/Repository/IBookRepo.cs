using BookLibApi.Core.Entities;
using BookLibApi.Dtos;

namespace BookLibApi.Repository
{
    public interface IBookRepo
    {
        // Collection
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<DropDownDto> GetCreateValuesForDropdowns();
        Task<DropDownDto> GetUpdateValuesForDropdowns();

        // Individual item
        Task<bool> AddBookAsync(Book newBook);
        Task<Book> GetBookByIdAsync(int bookId);
        Task<Book> GetBookByNameAsync(string name);
        Task<bool> UpdateBookAsync(Book newBook);
        Task<bool> DeleteBookSync(int bookId);
    }
}
