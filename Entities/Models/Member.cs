using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Member
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Photo is required")]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public byte[] Photo { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(13, ErrorMessage = "Phone can't be longer than 13 characters")]
        public string Phone{ get; set; }
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.Text)]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
