using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Module1.Data;
using Module1.Services;
using Swashbuckle.AspNetCore.Swagger;
using WebApiWithAspnetCore.Extensions;

namespace Module1
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
            // default
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // built-in dependency injection
            services.AddScoped<IProduct, ProductRepository>();

            // versioning
            // it requires package named "Microsoft.AspNetCore.Mvc.Versioning"
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new MediaTypeApiVersionReader();

            });

            // contend negotiation(accept type should be matching with mime type)
            // to send xml type if client (browser) wants
            services.AddMvc().AddXmlSerializerFormatters();

            // entiry framework connection string            
            var connString = Configuration.GetConnectionString("ProductDbContext");
            services.AddDbContext<ProductDbContext>(option => option.UseSqlServer(connString));

            // documentation
            // ref: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
            // ref: https://code-maze.com/swagger-ui-asp-net-core-web-api/

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TripleJ LMS API", Version = "1.0" });
                c.AddSecurityDefinition("Bearer",
                       new ApiKeyScheme
                       {
                           In = "header",
                           Name = "Authorization",
                           Type = "apiKey"
                       });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
                    });
                //c.OperationFilter<FileUploadOperation>();
                c.OperationFilter<SwaggerParameterAttributeFilter>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) // , ProductDbContext productDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "API for product");
                    x.RoutePrefix = "swagger";
                }
            );

            // automatically, database is create based on class inherits from Dbcontext
            // productDbContext.Database.EnsureCreated();
        }
    }
}
