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
    public class AuthorRepository :  RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : 
            base(repositoryContext) 
        {
        }
        public IEnumerable<Author> GetAuthors(PaginationParameters paginationParameters)
        {
            return FindAll()
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }

        public Author GetAuthorById(Guid authorId)
        {
            return FindByCondition(author => author.Id.Equals(authorId)).FirstOrDefault();
        }

        public Author GetAuthorWithBooks(Guid authorId)
        {
            return FindByCondition(author => author.Id.Equals(authorId))
                .Include(a => a.Books)
                .FirstOrDefault();
        }

        public void CreateAuthor(Author author) => Create(author);

        public void UpdateAuthor(Author author) => Update(author);

        public void DeleteAuthor(Author author) => Delete(author);
    }
}
