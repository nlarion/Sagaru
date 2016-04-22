using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Sagaru.Models
{
    public class SagaruDbContext : DbContext
    {
        public DbSet<Shape> Shapes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Sagaru;integrated security = True");
        }

    }
}
