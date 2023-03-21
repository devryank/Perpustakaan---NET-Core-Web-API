using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors(PaginationParameters paginationParameters);
        Author GetAuthorById(Guid authorId);
        Author GetAuthorWithBooks(Guid authorId);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
