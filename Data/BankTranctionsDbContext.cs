using BankTranctions.Models;
using BankTransaction.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTranctions.Data
{
    public class BankTranctionsDbContext : DbContext
    {
        public BankTranctionsDbContext(DbContextOptions options) : base(options)
        {
        }

        public  DbSet<User> Users { get; set; } 

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }


    }
}
