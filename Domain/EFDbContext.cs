using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class EFDbContext : DbContext 
    {
        DbSet<PressureReading> PressureReadings { get; set; }
        DbSet<Bank> Banks { get; set; }
        DbSet<Account> Accounts { get; set; }

        public string ConnectionString { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) :base(options)
        {
        }
    }
}
