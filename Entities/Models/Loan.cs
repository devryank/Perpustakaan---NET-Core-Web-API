﻿using System;
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

        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
