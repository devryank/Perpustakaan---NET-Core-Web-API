using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
    public class BookForUpdateDto
    {
        [Required]
        [StringLength(255, ErrorMessage = "Name can't be longer than 255 characters")]
        public string Title { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public byte[]? Image { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [StringLength(17, ErrorMessage = "ISBN can't be longer than 13")]
        public string ISBN { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string PublisherId { get; set; }
    }
}
