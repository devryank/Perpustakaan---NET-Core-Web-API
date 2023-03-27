using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name can't be longer than 255 characters")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "Image is required")]
        //[FileExtensions(Extensions = "jpg,jpeg,png")]
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(17, ErrorMessage = "ISBN can't be longer than 13")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid PublisherId { get; set; }
        public  Publisher Publisher { get; set; } 
    }
}
