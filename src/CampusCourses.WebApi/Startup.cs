using CampusCourses.WebApi.Common.ViewModels;
using CampusCourses.WebApi.Extensions;
using CampusCourses.WebApi.Identity.Extensions;
using CampusCourses.WebApi.Infrastructure;

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System.Linq;

namespace CampusCourses.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
            {
                options.Filters.Add<JsonExceptionFilter>();
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    ErrorViewModel error = new ErrorViewModel("invalid_request", 401);

                    var actionExecutingContext = context as ActionExecutingContext;
                    if (context.ModelState.ErrorCount > 0 &&
                        (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                    {
                        var errors = context.ModelState.Select(m => m.Value);
                        error.Details = error.Details;

                        return new BadRequestObjectResult(error)
                        {
                            ContentTypes = { "application/problem+json" },
                        };
                    }

                    error.Details = new[] { "One or more validation problem occurred." };

                    return new BadRequestObjectResult(error)
                    {
                        ContentTypes = { "application/problem+json" },
                    };
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Compus Course API", Version = "v1" });
            });

            services.AddMediatR(this.GetType().Assembly);

            services.AddApiMetadataConfiguration();

            services.AddIdentityModule(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compus Course v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
