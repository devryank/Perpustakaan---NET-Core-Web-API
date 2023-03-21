using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks(PaginationParameters paginationParameters);
        Book GetBookById(Guid id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
