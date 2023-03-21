using Entities.DataTransferObjects.Author;
using Entities.DataTransferObjects.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
    public class BookWithRelationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}
