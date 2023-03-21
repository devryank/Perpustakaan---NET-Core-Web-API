using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public IEnumerable<Book> GetBooks(PaginationParameters paginationParameters)
        {
            return FindAll()
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }

        public Book GetBookById(Guid id)
        {
            //return FindByCondition(book => book.Id.Equals(id))
            //    .Include(b => b.Author)
            //    .FirstOrDefault();
            return RepositoryContext.Books
                .Where(book => book.Id.Equals(id))
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefault();
        }

        public void CreateBook(Book book) => Create(book);
        public void UpdateBook(Book book) => Update(book);
        public void DeleteBook(Book book) => Delete(book);
    }
}
