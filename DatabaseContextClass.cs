using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostgre
{
    public class DatabaseContextClass:DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public DatabaseContextClass()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=productsdb;Username=postgres;Password=root");
        }
    }
}
