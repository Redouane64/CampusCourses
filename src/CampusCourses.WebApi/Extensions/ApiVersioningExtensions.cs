using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace CampusCourses.WebApi.Extensions
{
    public static class ApiVersioningExtensions
    {
        public static void AddApiMetadataConfiguration(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
        }
    }
}
