using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Entities.Models;
using System.Data;

namespace Perpustakaan.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserController(IRepositoryWrapper repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {

                var users = _repository.User.GetAllUsers();
                return Ok(users);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("{id}", Name = "UserById")]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var userResult = _mapper.Map<UserDto>(user);
                    return Ok(userResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var hash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
                user.Password = hash;

                var userEntity = _mapper.Map<User>(user);
                _repository.User.CreateUser(userEntity);
                _repository.Save();

                var createdUser = _mapper.Map<UserDto>(userEntity);

                return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "error");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserForUpdateDto user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var userEntity = _repository.User.GetUserById(id);
                if (userEntity is null)
                {
                    return NotFound();
                }

                _mapper.Map(user, userEntity);

                _repository.User.UpdateUser(userEntity);
                _repository.Save();

                return Ok(userEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                _repository.User.DeleteUser(user);
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
