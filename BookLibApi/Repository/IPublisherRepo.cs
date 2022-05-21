using BookLibApi.Core.Entities;
using BookLibApi.Dtos;

namespace BookLibApi.Repository
{
    public interface IPublisherRepo
    {
        // Collection
        Task<IEnumerable<PublisherDto>> GetAllPublishersAsync();

        // Individual item
        Task<bool> AddPublisherAsync(Publisher newPublisher);
        Task<Publisher> GetPublisherByIdAsync(int publisherId);
        Task<Publisher> GetPublisherByNameAsync(string name);
        Task<bool> UpdatePublisherAsync(Publisher newPublisher);
        Task<bool> DeletePublisherSync(int publisherId);

        // Association 
        Task<IEnumerable<Book>> GetBooksAsync(int publisherId);
    }
}
