using Microsoft.EntityFrameworkCore;
using Poc.GraphQl.Data.Models;

namespace Poc.GraphQl.Data
{
    public class ProductManagementContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
            : base(options)
        {
        }
    }
}
