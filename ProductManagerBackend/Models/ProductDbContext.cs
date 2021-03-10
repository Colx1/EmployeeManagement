using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Company> Tbl_Companies { get; set; }
        public DbSet<Brand> Tbl_Brands { get; set; }
        public DbSet<Product> Tbl_Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ProductManagerBackendDB;Integrated Security=True");
        }
    }
}
