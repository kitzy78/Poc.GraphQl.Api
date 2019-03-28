using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc.GraphQl.Data
{
    public interface IDataRepository
    {
        Task<IEnumerable<Models.Data>> Get();
        Task<Models.Data> Get(string id);
    }
}