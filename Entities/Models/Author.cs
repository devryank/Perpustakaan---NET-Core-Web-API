using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(13, ErrorMessage = "Name can't be longer than 13 characters")]
        public string phone { get; set; }
        public List<Book> Books { get; set; }
    }
}
