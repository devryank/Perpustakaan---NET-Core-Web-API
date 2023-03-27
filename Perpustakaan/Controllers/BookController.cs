using Contracts;
using Entities.DataTransferObjects.Book;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Mapster;

namespace Perpustakaan.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        public static IWebHostEnvironment _environment;

        public BookController(IRepositoryWrapper repository, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _repository = repository;
            _configuration = configuration;
            _environment = environment;
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
        [HttpPost("uploadBuku")]
        public IActionResult Create([FromForm] BookForCreationDto book, [FromForm(Name = "Image")] IFormFile file)
        {
            //var filePath = Path.GetTempFileName();
            //using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + file.FileName))
            //{
            //    file.CopyTo(fileStream);
            //    return Ok(fileStream);
            //    fileStream.Flush();
            //}
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                book.Image = ms.ToArray();
            }
            //    return Ok(file);
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
        public IActionResult Update(Guid id, [FromForm] BookForUpdateDto bookUpdateDto, [FromForm(Name = "Image")] IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                bookUpdateDto.Image = ms.ToArray();
            }
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

                //var bookEntity = _repository.Book.GetBookById(id);
                //return Ok(bookEntity);
                var bookMap = bookUpdateDto.Adapt<Book>();
                bookMap.Id = id;
                //return Ok(bookMap);
                //return Ok(bookUpdateDto);
                //var bookUpdateDtoMapToModel = bookUpdateDto.Adapt<Book>();
                //bookUpdateDtoMapToModel.Id = bookEntity.Id;
                //return Ok(bookUpdateDtoMapToModel);
                _repository.Book.UpdateBook(bookMap);
                _repository.Save();

                return Ok(bookMap);
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
