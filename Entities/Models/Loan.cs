using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Loan
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int Fine { get; set; }

        public DateTime CreatedAt { get; set; } 

        public ICollection<Member> Members { get; set; }
    }
}
