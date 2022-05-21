namespace BookLibApi.Repository
{
    public interface IBookAuthorRepo
    {
        // Individual item
        Task<bool> AddBook_AuthorAsync(List<int>? authorIds, int bookId);
        Task<bool> UpdateBook_AuthorAsync(List<int>? authorIds, int bookId);
        Task<bool> DeleteBook_AuthorSync(int bookId);
    }
}
