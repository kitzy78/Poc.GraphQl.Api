using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poc.GraphQl.Data
{
    public class DataRepository : IDataRepository
    {
        public DataRepository()
        {
            var x = DateTime.Now.Millisecond; //Proof class is transient
        }

        public async Task<IEnumerable<Models.Data>> Get()
        {
            var results = new List<Models.Data>();
            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(10);
                results.Add(new Models.Data());
            }
            return results;
        }

        public async Task<Models.Data> Get(string id)
        {
            await Task.Delay(10);
            return new Models.Data(id);
        }
    }
}