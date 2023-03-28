using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Loan
{
    public class LoanForCreationDto
    {
        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int Fine { get; set; }

        [Required]
        public Guid MemberId { get; set; }

        public string? BookId { get; set; }
    }
}
