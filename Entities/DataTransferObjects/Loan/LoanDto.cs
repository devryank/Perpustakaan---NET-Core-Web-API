using Entities.DataTransferObjects.Book;
using Entities.DataTransferObjects.Member;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Loan
{
    public class LoanDto
    {
        public Guid Id { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int Fine { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid MemberId { get; set; }
        public MemberDto Member { get; set; }

        public Guid BookId { get; set; }
        public BookDto Book { get; set; }
    }
}
