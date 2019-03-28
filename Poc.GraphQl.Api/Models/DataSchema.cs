using GraphQL;
using GraphQL.Types;

namespace Poc.GraphQl.Api.Models
{
    public class DataSchema : Schema
    {
        public DataSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<DataQuery>();
            //Mutation = resolver.Resolve<FooMutation>();
        }
    }
}
