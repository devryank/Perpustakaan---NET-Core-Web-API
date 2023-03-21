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
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public IEnumerable<Publisher> GetPublishers(PaginationParameters paginationParameters)
        {
            return FindAll()
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }

        public Publisher GetPublisherById(Guid id)
        {
            return FindByCondition(publisher => publisher.Id.Equals(id)).FirstOrDefault();
        }

        public Publisher GetPublisherWithBooks(Guid id)
        {
            return FindByCondition(publisher => publisher.Id.Equals(id))
                .Include(p => p.Books)
                .FirstOrDefault();
        }

        public void CreatePublisher(Publisher publisher) => Create(publisher);
        public void UpdatePublisher(Publisher publisher) => Update(publisher);
        public void DeletePublisher(Publisher publisher) => Delete(publisher);
    }
}
