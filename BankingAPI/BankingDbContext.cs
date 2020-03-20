using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI
{
    public class BankingDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public string ConnectionString { get; set; }

        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Account>()
                .HasOne(t => t.Bank)
                .WithMany(a => a.Accounts)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .OnDelete(DeleteBehavior.Cascade);

            modelbuilder.Entity<Bank>()
                .HasMany(b => b.Accounts)
                .WithOne(a => a.Bank)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
