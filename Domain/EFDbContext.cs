using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class EFDbContext : DbContext 
    {
        DbSet<PressureReading> PressureReadings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=Pressure;Integrated Security=True");

        }
    }
}
