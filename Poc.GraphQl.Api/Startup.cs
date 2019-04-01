using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.GraphQl.Api.Models;
using Poc.GraphQl.Api.Services;
using Poc.GraphQl.Data;
using Poc.GraphQl.Data.Repositories;

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
            services.AddMvc();

            services.AddDbContext<ProductManagementContext>(options => options.UseInMemoryDatabase("ProductStore"));

            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ProductQuery>();
            services.AddSingleton<ProductMutation>();
            services.AddSingleton<ProductType>();
            /*
            var connection = @"Server=localhost;Database=productstore;User=tester;Password=testing";
            services.AddDbContext<ProductManagementContext>(options => 
                options.UseMySql(connection, mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(5, 7, 25), ServerType.MySql);
                }));
            */

            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ProductSchema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
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
