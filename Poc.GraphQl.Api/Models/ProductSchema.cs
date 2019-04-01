using GraphQL;
using GraphQL.Types;

namespace Poc.GraphQl.Api.Models
{
    public class ProductSchema : Schema
    {
        public ProductSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<ProductQuery>();
            Mutation = resolver.Resolve<ProductMutation>();
        }
    }
}
