using BookLibApi.Core.Entities;
using BookLibApi.Dtos;

namespace BookLibApi.Repository
{
    public interface IAuthorRepo
    {
        // Collection
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();

        // Individual item
        Task<bool> AddAuthorAsync(Author newAuthor);
        Task<Author> GetAuthorByIdAsync(int authorId);
        Task<Author> GetAuthorByNameAsync(string name);
        Task<bool> UpdateAuthorAsync(Author newAuthor);
        Task<bool> DeleteAuthorSync(int authorId);
    }
}
