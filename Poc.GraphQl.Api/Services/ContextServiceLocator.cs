using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Poc.GraphQl.Data;

namespace Poc.GraphQl.Api.Services
{
    public class ContextServiceLocator
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public IDataRepository DataRepository => httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IDataRepository>();
    }
}
