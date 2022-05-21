using AutoMapper;
using BookLibApi.Core.Entities;
using BookLibApi.Dtos;
using BookLibApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookLibApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepo _repo;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: AuthorsController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorsAsync()
        {

            var authorDto = await _repo.GetAllAuthorsAsync();

            return Ok(authorDto);
        }

        // GET: AuthorsController/Details/5
        [ActionName(nameof(GetAuthorByIdAsync))]
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorByIdAsync(int id)
        {
            var author = await _repo.GetAuthorByIdAsync(id);

            if (author == null)
                return NotFound();

            var newAuthorDto = new AuthorDto()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return Ok(newAuthorDto);

        }

        // GET: AuthorsController/Details/as
        [HttpGet("name")]
        public async Task<ActionResult<AuthorDto>> GetAuthorByNameAsync(string name)
        {
            var author = await _repo.GetAuthorByNameAsync(name);

            if (author == null)
                return NotFound();

            var newAuthorDto = new AuthorDto()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return Ok(newAuthorDto); ;

        }

        // POST: AuthorsController/Create
        [HttpPost]
        public async Task<ActionResult> AddAuthorAsync([FromBody] AuthorDto aDto)
        {

            if (aDto == null)
            {
                return BadRequest();
            }

            var author = new Author()
            {
                AuthorId = aDto.AuthorId,
                FirstName = aDto.FirstName,
                LastName = aDto.LastName
            };

            bool resp = await _repo.AddAuthorAsync(author);

            if (resp)
            {
                return CreatedAtAction(nameof(GetAuthorByIdAsync), new { id = author.AuthorId }, author);
            }
            else
            {
                return BadRequest();
            }

        }

        // PUT: AuthorsController/Create
        [HttpPut]
        public async Task<ActionResult> UpdateAuthorAsync([FromBody] AuthorDto aDto)
        {

            if (aDto == null)
            {
                return BadRequest();
            }

            var author = new Author()
            {
                AuthorId = aDto.AuthorId,
                FirstName = aDto.FirstName,
                LastName = aDto.LastName
            };

            bool resp = await _repo.UpdateAuthorAsync(author);

            if (resp)
            {
                return CreatedAtAction(nameof(GetAuthorByIdAsync), new { id = aDto.AuthorId }, aDto);
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE: AuthorsController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            var author = await _repo.GetAuthorByIdAsync(id);
            if (author == null) return NotFound();

            bool resp = await _repo.DeleteAuthorSync(id);


            if (resp)
            {
                return Ok("Delete successful.");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
