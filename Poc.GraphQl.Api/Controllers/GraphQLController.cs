using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Poc.GraphQl.Api.Models;

namespace Poc.GraphQl.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter documentExecutor;
        private readonly ISchema schema;

        public GraphQLController(IDocumentExecuter documentExecutor,
            ISchema schema)
        {
            this.documentExecutor = documentExecutor;
            this.schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQueryRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var executeOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = request.Query,
                Inputs = request.Variables.ToInputs()
            };

            var result = await documentExecutor.ExecuteAsync(executeOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0) return BadRequest(result.Errors.Select(e => e.Message));

            return Ok(result.Data);
        }
    }
}