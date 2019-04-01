using GraphQL.Types;
using Poc.GraphQl.Data.Models;

namespace Poc.GraphQl.Api.Models
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Name = "product";

            //Field(f => f.Id.ToString()).Name("id").Description("ID of product");
            Field(f => f.Name).Description("Name of product");
            Field(f => f.Description).Description("Description of product");
            Field(f => f.Quantity).Description("Quantity of product");
            Field(f => f.Touched).Description("Last modified time of product");
        }
    }
}
