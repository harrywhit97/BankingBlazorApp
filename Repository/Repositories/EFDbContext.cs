using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class EFDbContext : DbContext
    {
        DbSet<PressureReading> Readings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=Pressure;Integrated Security=True");
        }
    }
}
