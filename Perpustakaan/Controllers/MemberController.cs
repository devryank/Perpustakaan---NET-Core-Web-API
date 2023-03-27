using Contracts;
using Entities.DataTransferObjects.Book;
using Entities.DataTransferObjects.Member;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Perpustakaan.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        public static IWebHostEnvironment _environment;

        public MemberController(IRepositoryWrapper repository, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _repository = repository;
            _configuration = configuration;
            _environment = environment;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetMembers([FromQuery] PaginationParameters paginationParameters)
        {
            var members = _repository.Member.GetMembers(paginationParameters);
            return Ok(members);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetMemberById(Guid id)
        {
            var member = _repository.Member.GetMemberById(id);
            return Ok(member);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create([FromForm] MemberForCreationDto member, [FromForm(Name = "Photo")] IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                member.Photo = ms.ToArray();
            }

            try
            {
                if (member is null)
                {
                    return BadRequest("Member object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var memberEntity = member.Adapt<Member>();
                _repository.Member.CreateMember(memberEntity);
                _repository.Save();

                return Ok(memberEntity);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromForm] MemberForUpdateDto member, [FromForm(Name = "Photo")] IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                member.Photo = ms.ToArray();
            }

            try
            {
                if (member is null)
                {
                    return BadRequest("Member object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var memberMap = member.Adapt<Member>();
                memberMap.Id = id;

                _repository.Member.UpdateMember(memberMap);
                _repository.Save();

                return Ok(memberMap);
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
                var member = _repository.Member.GetMemberById(id);
                if(member == null)
                {
                    return NotFound();
                }
                _repository.Member.DeleteMember(member);
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
