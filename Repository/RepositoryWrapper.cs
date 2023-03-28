using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _user;
        private IAuthorRepository _author;
        private IPublisherRepository _publisher;
        private IBookRepository _book;
        private IMemberRepository _member;
        private ILoanRepository _loan;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }
        public IAuthorRepository Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_repoContext);
                }

                return _author;
            }
        }

        public IPublisherRepository Publisher
        {
            get
            {
                if(_publisher == null)
                {
                    _publisher = new PublisherRepository(_repoContext);
                }

                return _publisher;
            }
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_repoContext);
                }

                return _book;
            }
        }

        public IMemberRepository Member
        {
            get
            {
                if (_member == null)
                {
                    _member = new MemberRepository(_repoContext);
                }

                return _member;
            }
        }

        public ILoanRepository Loan
        {
            get
            {
                if (_loan == null)
                {
                    _loan = new LoanRepository(_repoContext);
                }

                return _loan;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}