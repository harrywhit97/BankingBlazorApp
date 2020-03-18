using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class EFDbContext : DbContext
    {
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Bank> Banks { get; set; }
        DbSet<Account> Accounts { get; set; }

        public string ConnectionString { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
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
