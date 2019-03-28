using Newtonsoft.Json.Linq;

namespace Poc.GraphQl.Api.Models
{
    public class GraphQueryRequest
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
