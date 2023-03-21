using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers(PaginationParameters paginationParameters);
        Publisher GetPublisherById(Guid id);
        Publisher GetPublisherWithBooks(Guid id);
        void CreatePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
    }
}
