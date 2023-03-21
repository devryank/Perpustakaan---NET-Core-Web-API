using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Author;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Perpustakaan.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public AuthorController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAuthors([FromQuery] PaginationParameters paginationParameters)
        {
            var authors = _repository.Author.GetAuthors(paginationParameters);
            return Ok(authors);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "AuthorById")]
        public IActionResult GetAuthorById(Guid id)
        {
            try
            {
                var author = _repository.Author.GetAuthorById(id);
                if(author == null)
                {
                    return NotFound();
                } else
                {
                    var authorResult = MappingFunctions.GetAuthorById(author);
                    return Ok(authorResult);
                }
            }catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}/books")]
        public IActionResult GetAuthorWithBooks(Guid id)
        {
            try
            {
                var author = _repository.Author.GetAuthorWithBooks(id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] AuthorForCreationDto author)
        {
            try
            {
                if(author is null)
                {
                    return BadRequest("Author object is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var authorEntity = MappingFunctions.CreateAuthor(author);

                _repository.Author.CreateAuthor(authorEntity);
                _repository.Save();

                return Ok(authorEntity);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] AuthorForUpdateDto authorUpdateDto)
        {
            try
            {

                if(authorUpdateDto is null)
                {
                    return BadRequest("Author object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var authorEntity = _repository.Author.GetAuthorById(id);
                authorEntity = MappingFunctions.ReplaceAuthor(authorUpdateDto, authorEntity);
                _repository.Author.UpdateAuthor(authorEntity);
                _repository.Save();

                return Ok(authorEntity);
            } catch(Exception ex)
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
                var author = _repository.Author.GetAuthorById(id);
                if(author == null)
                {
                    return NotFound();
                }

                _repository.Author.DeleteAuthor(author);
                _repository.Save();

                return NoContent();
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
