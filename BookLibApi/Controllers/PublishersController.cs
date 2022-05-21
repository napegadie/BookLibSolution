using AutoMapper;
using BookLibApi.Core.Entities;
using BookLibApi.Dtos;
using BookLibApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookLibApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class PublishersController : Controller
    {
        private readonly IPublisherRepo _repo;
        private readonly IMapper _mapper;

        public PublishersController(IPublisherRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: PublishersController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> GetPublishersAsync()
        {

            var publisherDto = await _repo.GetAllPublishersAsync();

            return Ok(publisherDto);
        }

        // GET: PublishersController/Details/5
        [ActionName(nameof(GetPublisherByIdAsync))]
        [HttpGet("id")]
        public async Task<ActionResult<PublisherDto>> GetPublisherByIdAsync(int id)
        {
            var publisher = await _repo.GetPublisherByIdAsync(id);

            if (publisher == null)
                return NotFound();

            var newPublisherDto = new PublisherDto()
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name
            };

            return Ok(newPublisherDto);

        }

        // GET: PublishersController/Details/as
        [HttpGet("name")]
        public async Task<ActionResult<PublisherDto>> GetPublisherByNameAsync(string name)
        {
            var publisher = await _repo.GetPublisherByNameAsync(name);

            if (publisher == null)
                return NotFound();

            var newPublisherDto = new PublisherDto()
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name
            };

            return Ok(newPublisherDto);

        }

        // POST: PublishersController/Create
        [HttpPost]
        public async Task<ActionResult> AddPublisherAsync([FromBody] PublisherDto pDto)
        {

            if (pDto == null)
            {
                return BadRequest();
            }


            var publisher = new Publisher()
            {
                PublisherId = pDto.PublisherId,
                Name = pDto.Name
            };

            bool resp = await _repo.AddPublisherAsync(publisher);

            if (resp)
            {
                return CreatedAtAction(nameof(GetPublisherByIdAsync), new { id = pDto.PublisherId }, pDto);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdatePublisherAsync([FromBody] PublisherDto pDto)
        {

            if (pDto == null)
            {
                return BadRequest();
            }

            //if (id != pDto.PublisherId)
            //    return BadRequest();

            var publisher = new Publisher()
            {
                PublisherId = pDto.PublisherId,
                Name = pDto.Name
            };

            bool resp = await _repo.UpdatePublisherAsync(publisher);

            if (resp)
            {
                return CreatedAtAction(nameof(GetPublisherByIdAsync), new { id = pDto.PublisherId }, pDto);
            }
            else
            {
                return BadRequest();
            }

        }

        // DELETE: PublishersController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisherAsync(int id)
        {
            var publisher = await _repo.GetPublisherByIdAsync(id);
            if (publisher == null) return NotFound();

            bool resp = await _repo.DeletePublisherSync(id);


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
