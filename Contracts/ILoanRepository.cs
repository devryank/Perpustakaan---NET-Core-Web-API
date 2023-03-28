using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetLoans(PaginationParameters paginationParameters);
        Loan GetLoanById(Guid id);
        Loan GetLoanByIdWithRelation(Guid id);
        void CreateLoan(Loan loan);
        void UpdateLoan(Loan loan);
        void DeleteLoan(Loan loan);
    }
}
