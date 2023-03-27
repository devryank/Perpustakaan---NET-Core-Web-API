using Entities.DataTransferObjects.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public int Amount { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
    }
}
