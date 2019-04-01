using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poc.GraphQl.Data.Models;

namespace Poc.GraphQl.Data.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> GetQuery();
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(string id);
        Task<Product> Set(Product product);
        Task<Product> Create(Product product);
    }
}