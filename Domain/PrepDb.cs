using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<EFDbContext>());
            }
        }

        public static void SeedData(EFDbContext context)
        {
            Console.WriteLine("Migrating database...");
            context.Database.Migrate();

            if (!context.Set<PressureReading>().Any())
            {
                Console.WriteLine("No data in pressure readings");
            }
        }
    }
}
