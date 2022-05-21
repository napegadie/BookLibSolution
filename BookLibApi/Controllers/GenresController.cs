using AutoMapper;
using BookLibApi.Core.Entities;
using BookLibApi.Dtos;
using BookLibApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookLibApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class GenresController : Controller
    {
        private readonly IGenreRepo _repo;
        private readonly IMapper _mapper;

        public GenresController(IGenreRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: GenreController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenresAsync()
        {

            var genreDtos = await _repo.GetAllGenresAsync();

            return Ok(genreDtos);
        }

        // GET: GenreController/Details/5
        [ActionName(nameof(GetGenreByIdAsync))]
        [HttpGet("id")]
        public async Task<ActionResult<GenreDto>> GetGenreByIdAsync(int id)
        {
            var genre = await _repo.GetGenreByIdAsync(id);

            if (genre == null)
                return NotFound();

            var newGenreDto = new GenreDto()
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName
            };

            return Ok(newGenreDto); 

        }

        // GET: GenreController/Details/5
        [HttpGet("name")]
        public async Task<ActionResult<GenreDto>> GetGenreByNameAsync(string name)
        {
            var genre = await _repo.GetGenreByNameAsync(name);

            if (genre == null)
                return NotFound();

            var newGenreDto = new GenreDto()
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName
            };

            return Ok(newGenreDto);

        }


        // POST: GenreController/Create
        [HttpPost]
        public async Task<ActionResult> AddGenreAsync(GenreDto gDto)
        {

            if (gDto == null)
            {
                return BadRequest();
            }

            var genre = new Genre()
            {
                GenreId = gDto.GenreId,
                GenreName = gDto.GenreName
            };

            bool resp = await _repo.AddGenreAsync(genre);

            if (resp)
            {
                return CreatedAtAction(nameof(GetGenreByIdAsync), new { id = gDto.GenreId }, gDto);
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut]
        public async Task<ActionResult> UpdateGenreAsync([FromBody] GenreDto gDto)
        {

            if (gDto == null)
            {
                return BadRequest();
            }

            //if (id != gDto.GenreId)
            //    return BadRequest();

            var genre = new Genre()
            {
                GenreId = gDto.GenreId,
                GenreName = gDto.GenreName
            };

            bool resp = await _repo.UpdateGenreAsync(genre);

            if (resp)
            {
                return CreatedAtAction(nameof(GetGenreByIdAsync), new { id = gDto.GenreId }, gDto);
            }
            else
            {
                return BadRequest();
            }

        }

        // GET: GenreController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenreAsync(int id)
        {
            var gene = await _repo.GetGenreByIdAsync(id);
            if (gene == null) return NotFound();

            bool resp = await _repo.DeleteGenreSync(id);


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
