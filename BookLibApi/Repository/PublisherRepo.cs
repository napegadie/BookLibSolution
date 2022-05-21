using BookLibApi.Core.Entities;
using BookLibApi.DataStore;
using BookLibApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookLibApi.Repository
{
    public class PublisherRepo : IPublisherRepo
    {
        private BookDbContext _context;
        public PublisherRepo(BookDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPublisherAsync(Publisher newPublisher)
        {
            if (newPublisher == null)
            {
                throw new ArgumentNullException(nameof(newPublisher));
            }

            var _publisher = new Publisher()
            {
                Name = newPublisher.Name
            };


            _context.Publishers.Add(_publisher);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<bool> DeletePublisherSync(int publisherId)
        {
            var _publisher = await _context.Publishers.FirstOrDefaultAsync(n => n.PublisherId == publisherId);

            if (_publisher == null)
            {
                throw new Exception($"The publisher with id: {publisherId} does not exist");

            }

            _context.Publishers.Remove(_publisher);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<IEnumerable<PublisherDto>> GetAllPublishersAsync()
        {
            return await _context.Publishers
                          .Include(g => g.Books)
                          .Select(b => new PublisherDto()
                          {
                              PublisherId = b.PublisherId,
                              Name = b.Name,
                              Books = b.Books.Select(b => b.Title).ToList()
                          }).ToListAsync();
        }

        public Task<IEnumerable<Book>> GetBooksAsync(int publisherId)
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher> GetPublisherByIdAsync(int publisherId)
        {
            var _publisherData = await _context.Publishers.Where(p => p.PublisherId == publisherId)
                                     .Include(p => p.Books)
                                     .FirstOrDefaultAsync();

            return _publisherData;
        }

        public async Task<Publisher> GetPublisherByNameAsync(string name)
        {
            var _publisherData = await _context.Publishers.Where(p => p.Name.Contains(name))
                                     .Include(p => p.Books)
                                     .FirstOrDefaultAsync();

            return _publisherData;
        }

        public async Task<bool> UpdatePublisherAsync(Publisher newPublisher)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.PublisherId == newPublisher.PublisherId);

            if (_publisher == null)
            {
                throw new ArgumentNullException(nameof(_publisher));

            }

            _publisher.Name = newPublisher.Name;
            //_context.Publishers.Update(_publisher);
            _context.Entry(_publisher).State = EntityState.Modified;
            bool resp = await _context.SaveChangesAsync() >= 1;

            return (resp);
        }
    }
}
