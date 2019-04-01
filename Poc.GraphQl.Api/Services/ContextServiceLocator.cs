using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Poc.GraphQl.Data.Repositories;

namespace Poc.GraphQl.Api.Services
{
    public class ContextServiceLocator
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public IProductRepository ProductRepository => httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IProductRepository>();
    }
}
