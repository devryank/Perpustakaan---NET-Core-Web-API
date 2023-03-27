using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Member
{
    public class MemberForUpdateDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public byte[]? Photo { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(13, ErrorMessage = "Phone can't be longer than 13 characters")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date Birth is required")]
        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
