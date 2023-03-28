using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Publisher>? Publishers { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Member>? Members { get; set; }
        public DbSet<Loan>? Loans { get; set; }
    }
}
