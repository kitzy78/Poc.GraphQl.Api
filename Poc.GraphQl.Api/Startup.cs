using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.GraphQl.Api.Models;
using Poc.GraphQl.Api.Services;
using Poc.GraphQl.Data;

namespace Poc.GraphQl.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddTransient<IDataRepository, DataRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<DataQuery>();
            services.AddSingleton<DataType>();

            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new DataSchema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseGraphiQl();
            }

            app.UseMvc();
        }
    }
}
