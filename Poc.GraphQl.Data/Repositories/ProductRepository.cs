using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poc.GraphQl.Data.Models;

namespace Poc.GraphQl.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagementContext context;

        public ProductRepository(ProductManagementContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> GetQuery()
        {
            var query = context.Products.AsQueryable();
            return query;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var results = await context.Products.ToListAsync();
            return results;
        }

        public async Task<Product> Get(string id)
        {
            var parsed = Guid.TryParse(id, out var outGuid);
            if (!parsed) throw new ArgumentException($"Product {id} not found", nameof(id));
            var result = await context.Products.FirstOrDefaultAsync(p => p.Id == outGuid);
            return result;
        }

        public async Task<Product> Set(Product product)
        {
            var findParams = new Dictionary<string, Guid> {{"Id", product.Id}};
            var result = await context.Products.FindAsync(findParams);
            if (result == null) throw new Exception($"Product {product.Id} not found");
            result.Quantity = product.Quantity;
            result.Touched = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return await context.Products.FindAsync(findParams);
        }

        public async Task<Product> Create(Product product)
        {
            var result = await context.Products.AddAsync(product);
            return result.Entity;
        }
    }
}
