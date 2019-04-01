using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Poc.GraphQl.Api.Services;

namespace Poc.GraphQl.Api.Models
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(ContextServiceLocator contextServiceLocator)
        {
            Name = "productQuery";

            FieldAsync<ListGraphType<ProductType>>("productList",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> {Name = "name"},
                    new QueryArgument<StringGraphType> {Name = "description"},
                    new QueryArgument<IntGraphType> {Name = "quantity"}),
                resolve: async context =>
                {
                    var name = context.GetArgument<string>("name");
                    var description = context.GetArgument<string>("description");
                    var quantity = context.GetArgument<int?>("quantity");
                    var query = contextServiceLocator.ProductRepository.GetQuery();

                    if (!string.IsNullOrEmpty(name)) query = query.Where(q => q.Name == name);
                    if (!string.IsNullOrEmpty(description)) query = query.Where(q => q.Description == description);
                    if (quantity.HasValue) query = query.Where(q => q.Quantity == quantity);

                    var results = await query.ToListAsync();
                    return results;
                });

            FieldAsync<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "id"}),
                resolve: async context => await contextServiceLocator.ProductRepository.Get(context.GetArgument<string>("id")));
        }
    }
}
