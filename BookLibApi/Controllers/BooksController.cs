using AutoMapper;
using BookLibApi.Core.Entities;
using BookLibApi.Dtos;
using BookLibApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookLibApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepo _repo;
        private readonly IMapper _mapper;
        private readonly IBookAuthorRepo _barepo;

        public BooksController(IBookRepo repo, IMapper mapper, IBookAuthorRepo barepo)
        {
            _repo = repo;
            _mapper = mapper;
            _barepo = barepo;
        }

        // POST: BooksController/Create
        [HttpPost]
        public async Task<ActionResult> AddBookAsync([FromBody] BookDto bDto)
        {

            if (bDto == null)
            {
                return BadRequest();
            }

            var newBook = new Book()
            {
                Title = bDto.Title,
                Description = bDto.Description,
                DatePublished = bDto.DatePublished,
                CoverUrl = bDto.CoverUrl,
                PublisherId = bDto.PublisherId,
                GenreId = bDto.GenreId
            };

            var authorIds = bDto.AuthorIds;

            bool resp = await _repo.AddBookAsync(newBook);


            if (resp)
            {
                bool resp1 = await _barepo.AddBook_AuthorAsync(authorIds, newBook.BookId);
                if (!resp1)
                    return BadRequest();

                var book = await _repo.GetBookByIdAsync(newBook.BookId);

                if (book == null)
                    return NotFound();

                var newBookDto = new BookDto()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Description = book.Description,
                    DatePublished = book.DatePublished,
                    CoverUrl = book.CoverUrl,
                    PublisherId = book.PublisherId,
                    PublisherName = book.Publisher!.Name,
                    GenreId = book.GenreId,
                    GenreName = book.BookGenre!.GenreName,
                    AuthorIds = book.Book_Authors!.Select(author => author.AuthorId).ToList()
                };

                return CreatedAtAction(nameof(GetBookByIdAsync), new { id = newBookDto.BookId }, newBookDto);
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT: BooksController/Create
        [HttpPut]
        public async Task<ActionResult> UpdateBookAsync([FromBody] BookDto bDto)
        {

            if (bDto == null)
            {
                return BadRequest();
            }

            var newBook = new Book()
            {
                BookId = bDto.BookId,
                Title = bDto.Title,
                Description = bDto.Description,
                DatePublished = bDto.DatePublished,
                CoverUrl = bDto.CoverUrl,
                PublisherId = bDto.PublisherId,
                GenreId = bDto.GenreId
            };

            var authorIds = bDto.AuthorIds;

            bool resp = await _repo.UpdateBookAsync(newBook);

            if (resp)
            {
                bool resp1 = await _barepo.UpdateBook_AuthorAsync(authorIds, newBook.BookId);
                if (!resp1)
                    return BadRequest();

                return CreatedAtAction(nameof(GetBookByIdAsync), new { id = bDto.BookId }, bDto);
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE: Books/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var book = await _repo.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            bool resp = await _repo.DeleteBookSync(id);


            if (resp)
            {
                bool resp1 = await _barepo.DeleteBook_AuthorSync(id);
                if (!resp1)
                    return BadRequest();

                return Ok("Delete successful.");
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: BooksController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync()
        {

            var bookDtos = await _repo.GetAllBooksAsync();

            return Ok(bookDtos);
        }

        // GET: Api/Books/GetCreateDDown
        [HttpGet]
        [Route("[action]", Name = "GetCreateDDown")]
        public async Task<ActionResult<DropDownDto>> GetCreateDDownAsync()
        {

            DropDownDto createDtos = await _repo.GetCreateValuesForDropdowns();

            return Ok(createDtos);
        }

        // GET: Api/Books/GetUpdateDDown 
        [HttpGet]
        [Route("[action]", Name = "GetUpdateDDown")]
        public async Task<ActionResult<DropDownDto>> GetUpdateDDownAsync()
        {

            DropDownDto updateDtos = await _repo.GetUpdateValuesForDropdowns();

            return Ok(updateDtos);
        }

        // GET: BooksController/Details/5
        [ActionName(nameof(GetBookByIdAsync))]
        [HttpGet("id")]
        public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await _repo.GetBookByIdAsync(id);

            if (book == null)
                return NotFound();

            var newBookDto = new BookDto()
            {
                BookId = book.BookId,
                Title = book.Title,
                Description = book.Description,
                DatePublished = book.DatePublished,
                CoverUrl = book.CoverUrl,
                PublisherId = book.PublisherId,
                PublisherName = book.Publisher!.Name,
                GenreId = book.GenreId,
                GenreName = book.BookGenre!.GenreName,
                AuthorIds = book.Book_Authors!.Select(author => author.AuthorId).ToList()
            };


            return Ok(newBookDto);

        }

        // GET: BooksController/Details/as
        [HttpGet("name")]
        public async Task<ActionResult<BookDto>> GetBookByNameAsync(string name)
        {
            var book = await _repo.GetBookByNameAsync(name);

            if (book == null)
                return NotFound();

            var newBookDto = new BookDto()
            {
                BookId = book.BookId,
                Title = book.Title,
                Description = book.Description,
                DatePublished = book.DatePublished,
                CoverUrl = book.CoverUrl,
                PublisherId = book.PublisherId,
                PublisherName = book.Publisher!.Name,
                GenreId = book.GenreId,
                GenreName = book.BookGenre!.GenreName,
                AuthorIds = book.Book_Authors!.Select(author => author.AuthorId).ToList()
            };

            return Ok(newBookDto);

        }

    }
}
