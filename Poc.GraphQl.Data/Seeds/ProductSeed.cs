using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Poc.GraphQl.Data.Models;

namespace Poc.GraphQl.Data.Seeds
{
    public class ProductSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductManagementContext(serviceProvider.GetRequiredService<DbContextOptions<ProductManagementContext>>()))
            {
                if (context.Products.Any()) return;

                var randomizer = new Random();
                for (int i = 0; i < 10; i++)
                {
                    context.Products.Add(new Product { Id = Guid.NewGuid(), Name = $"Test{i}", Description = $"Test{i} Product", Quantity = randomizer.Next(1, 100), Touched = DateTime.UtcNow });
                    Task.Delay(10);
                }
                context.SaveChanges();
            }
        }
    }
}
