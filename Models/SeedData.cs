using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MVCApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OpravilaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OpravilaContext>>()))
            {
                if (context.Uporabnik.Any())
                {
                    return;   // DB has been seeded
                }

                context.Uporabnik.Add(
                    new Uporabnik
                    {
                        Username = "admin",
                        Password = "admin"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}