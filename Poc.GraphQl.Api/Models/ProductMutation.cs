using GraphQL.Types;
using Poc.GraphQl.Api.Services;

namespace Poc.GraphQl.Api.Models
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(ContextServiceLocator contextServiceLocator)
        {
            Name = "productMutation";

            FieldAsync<ProductType>(
                "updateQuantity",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "id"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "quantity"}),
                resolve: async context =>
                {
                    var productId = context.GetArgument<string>("id");
                    var product = await contextServiceLocator.ProductRepository.Get(productId);
                    product.Quantity = context.GetArgument<int>("quantity");
                    var result = await contextServiceLocator.ProductRepository.Set(product);
                    return result;
                });
        }
    }
}
