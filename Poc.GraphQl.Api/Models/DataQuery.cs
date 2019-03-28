using GraphQL.Types;
using Poc.GraphQl.Api.Services;

namespace Poc.GraphQl.Api.Models
{
    public class DataQuery : ObjectGraphType
    {
        public DataQuery(ContextServiceLocator contextServiceLocator)
        {
            Name = "dataQuery";

            FieldAsync<ListGraphType<DataType>>(
                "dataList",
                resolve: async context => await contextServiceLocator.DataRepository.Get());

            FieldAsync<DataType>(
                "dataItem",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "id"}),
                resolve: async context => await contextServiceLocator.DataRepository.Get(context.GetArgument<string>("id")));
        }
    }
}
