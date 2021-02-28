using WShop.MarsRover.Application.Common.Configurations;
using WShop.MarsRover.Application.Common.Interfaces;
using WShop.MarsRover.Infrastructure.Configurations;
using WShop.MarsRover.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WShop.MarsRover.Infrastructure
{
    public static class DependencyInjection
    {
        public static IConfiguration Configuration { get; set; }
        public static IWebHostEnvironment WebHostEnvironment { get; set; }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
            
            services.AddSingleton<IUriService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                //var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });
                        

            var applicationConfiguration = configuration.GetSection(nameof(ApplicationConfiguration)).Get<ApplicationConfiguration>();            
            services.AddSingleton<IApplicationConfiguration>(applicationConfiguration);                  

            return services;
        }        
    }
}


