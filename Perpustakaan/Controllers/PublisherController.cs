using Contracts;
using Entities.DataTransferObjects.Publisher;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Perpustakaan.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublisherController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public PublisherController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetPublishers([FromQuery] PaginationParameters paginationParameters)
        {
            var publishers = _repository.Publisher.GetPublishers(paginationParameters);
            return Ok(publishers);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "PublisherById")]
        public IActionResult GetPublisherById(Guid id)
        {
            try
            {
                var publisher = _repository.Publisher.GetPublisherById(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                else
                {
                    var publisherResult = MappingFunctions.GetPublisherById(publisher);
                    return Ok(publisherResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}/books")]
        public IActionResult GetPublisherWithBooks(Guid id)
        {
            try
            {
                var publisher = _repository.Publisher.GetPublisherWithBooks(id);
                if (publisher == null)
                {
                    return NotFound();
                }
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] PublisherForCreationDto publisher)
        {
            try
            {
                if (publisher is null)
                {
                    return BadRequest("Publisher object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var publisherEntity = MappingFunctions.CreatePublisher(publisher);

                _repository.Publisher.CreatePublisher(publisherEntity);
                _repository.Save();

                return Ok(publisherEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PublisherForUpdateDto publisherUpdateDto)
        {
            try
            {

                if (publisherUpdateDto is null)
                {
                    return BadRequest("Publisher object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var publisherEntity = _repository.Publisher.GetPublisherById(id);
                publisherEntity = MappingFunctions.ReplacePublisher(publisherUpdateDto, publisherEntity);
                _repository.Publisher.UpdatePublisher(publisherEntity);
                _repository.Save();

                return Ok(publisherEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var publisher = _repository.Publisher.GetPublisherWithBooks(id);
                if(publisher.Books.Count > 0)
                {
                    return StatusCode(500, "Publisher tidak dapat dihapus karena memiliki data buku");
                } 
                if (publisher == null)
                {
                    return NotFound();
                }

                _repository.Publisher.DeletePublisher(publisher);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
