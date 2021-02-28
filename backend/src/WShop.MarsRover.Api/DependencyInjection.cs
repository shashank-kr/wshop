using WShop.MarsRover.Api.Constants.Policy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WShop.MarsRover.Api
{    
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy(AuthorizationConsts.CorsPolicy,
                    builder => builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        //.AllowCredentials()
                        .AllowAnyOrigin());
            });

            services.AddHttpContextAccessor();
                       
            return services;
        }
    }
}

