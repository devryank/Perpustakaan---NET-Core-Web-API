using Contracts;
using Entities.DataTransferObjects.Book;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Perpustakaan.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public BookController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetBooks([FromQuery] PaginationParameters paginationParameters)
        {
            var books = _repository.Book.GetBooks(paginationParameters);
            return Ok(books);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "BookById")]
        public IActionResult GetBookById(Guid id)
        {
            try
            {
                var book = _repository.Book.GetBookById(id);
                //JsonSerializerOptions options = new()
                //{
                //    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                //    WriteIndented = true
                //};
                //var text = JsonSerializer.Serialize(book, options);

                //return Ok(JsonSerializer.Deserialize<Book>(text, options));
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    var bookResult = MappingFunctions.GetBookWithRelationById(book);
                    return Ok(bookResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromBody] BookForCreationDto book)
        {
            //return Ok(book);
            try
            {
                if (book is null)
                {
                    return BadRequest("Book object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var bookEntity = MappingFunctions.CreateBook(book);
                //return Ok(bookEntity);
                _repository.Book.CreateBook(bookEntity);
                _repository.Save();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] BookForUpdateDto bookUpdateDto)
        {
            try
            {

                if (bookUpdateDto is null)
                {
                    return BadRequest("Book object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var bookEntity = _repository.Book.GetBookById(id);
                var bookMap = MappingFunctions.GetBookById(bookEntity);
                return Ok(bookMap);
                bookEntity = MappingFunctions.ReplaceBook(bookUpdateDto, bookEntity);
                _repository.Book.UpdateBook(bookEntity);
                _repository.Save();

                return Ok(bookEntity);
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
                var book = _repository.Book.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }

                _repository.Book.DeleteBook(book);
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
