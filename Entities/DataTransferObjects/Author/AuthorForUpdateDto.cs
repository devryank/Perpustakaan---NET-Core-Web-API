using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Author
{
    public class AuthorForUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(13, ErrorMessage = "Phone can't be longer than 13 characters")]
        public string Phone { get; set; }
    }
}
