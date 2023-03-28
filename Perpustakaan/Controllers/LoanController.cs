using Contracts;
using Entities.DataTransferObjects.Loan;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Perpustakaan.Controllers
{
    [Route("api/loan")]
    [ApiController]
    public class LoanController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        public static IWebHostEnvironment _environment;

        public LoanController(IRepositoryWrapper repository, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _repository = repository;
            _configuration = configuration;
            _environment = environment;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetLoans([FromQuery] PaginationParameters paginationParameters)
        {
            var loans = _repository.Loan.GetLoans(paginationParameters);
            return Ok(loans);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetLoanById(Guid id)
        {
            var loan = _repository.Loan.GetLoanByIdWithRelation(id);
            var loanDto = loan.Adapt<LoanDto>();
            return Ok(loanDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public  IActionResult Create([FromBody] LoanForCreationDto loan)
        {
            try
            {
                if (loan is null)
                {
                    return BadRequest("Loan object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var loanEntity = loan.Adapt<Loan>();
                loanEntity.MemberId = loan.MemberId;
                _repository.Loan.CreateLoan(loanEntity);
                _repository.Save();

                return Ok(loanEntity);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] LoanForUpdateDto loan)
        {
            try
            {

                if (loan is null)
                {
                    return BadRequest("Book object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var loanEntity = _repository.Loan.GetLoanById(id);
                var loanReplace = loan.Adapt(loanEntity);

                _repository.Loan.UpdateLoan(loanReplace);
                _repository.Save();

                return Ok(loanReplace);
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
                var loanEntity = _repository.Loan.GetLoanById(id);
                _repository.Loan.DeleteLoan(loanEntity);
                _repository.Save();

                return NoContent();
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
