using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCApp.Models
{
    public class OpravilaContext : DbContext
    {
        public OpravilaContext (DbContextOptions<OpravilaContext> options)
            : base(options)
        {
        }

        public DbSet<MVCApp.Models.Opravilo> Opravilo { get; set; }
        public DbSet<MVCApp.Models.Uporabnik> Uporabnik { get; set; }
    }
}
