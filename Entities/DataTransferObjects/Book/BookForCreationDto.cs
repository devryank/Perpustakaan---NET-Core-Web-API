using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
    public class BookForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name can't be longer than 255 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string AuthorId { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        public string PublisherId { get; set; }
    }
}
