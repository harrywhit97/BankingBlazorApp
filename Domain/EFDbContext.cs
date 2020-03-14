using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class EFDbContext : DbContext 
    {
        DbSet<PressureReading> PressureReadings { get; set; }
        public string ConnectionString { get; set; }

        public EFDbContext(string connectionString)
        {
            ConnectionString = connectionString;   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
