using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WShop.MarsRover.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblyNamesToScan = new string[]
            {
                "WShop.MarsRover.Api",
                "WShop.MarsRover.Application",
                "WShop.MarsRover.Infrastructure"
            };

            var config = new MapperConfiguration(cfg =>
            {
                // Add all assemblies where mapping profiles present.
                cfg.AddMaps(assemblyNamesToScan);
            });

            var mapper = config.CreateMapper();

            // Make sure configuration is valid for all profiles to avoid runtime exceptions.
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
            services.AddSingleton(mapper);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());                       

            return services;
        }
    }
}

