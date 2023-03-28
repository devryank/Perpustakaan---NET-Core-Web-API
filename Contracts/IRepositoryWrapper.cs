using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAuthorRepository Author { get; }
        IPublisherRepository Publisher { get; }
        IBookRepository Book { get; }
        IMemberRepository Member { get; }
        ILoanRepository Loan { get; } 
        void Save();
    }
}
