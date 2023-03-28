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
    public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
    {
        public LoanRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public IEnumerable<Loan> GetLoans(PaginationParameters paginationParameters)
        {
            return FindAll()
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToList();
        }

        public Loan GetLoanById(Guid id)
        {
            return FindByCondition(loan => loan.Id.Equals(id))
                .FirstOrDefault();
        }

        public Loan GetLoanByIdWithRelation(Guid id)
        {
            return RepositoryContext.Loans
                .Where(loan => loan.Id.Equals(id))
                .Include(l => l.Member)
                .Include(l => l.Book)
                .FirstOrDefault();
        }

        public void CreateLoan(Loan loan) => Create(loan);
        public void UpdateLoan(Loan loan) => Update(loan);
        public void DeleteLoan(Loan loan) => Delete(loan);
    }
}
