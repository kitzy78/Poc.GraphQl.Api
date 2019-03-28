using GraphQL.Types;

namespace Poc.GraphQl.Api.Models
{
    public class DataType : ObjectGraphType<Data.Models.Data>
    {
        public DataType()
        {
            Field(f => f.Id, type: typeof(StringGraphType)).Name("id").Description("Data Identifier");
            Field(f => f.Description).Name("description").Description("Data Description");
            Field<StringGraphType>(
                "calculatedField",
                resolve: context => $"{context.Source.Description} is the description");
        }
    }
}
