using Microsoft.EntityFrameworkCore;
using AzureAPI.Entities;

namespace AzureAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

    }
    
}
