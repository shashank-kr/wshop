using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;
using WShop.MarsRover.Api.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WShop.MarsRover.Api.Installers
{
    public class SwagerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "WShop Mars Rover  REST APIs",
                    Version = "v1",
                    Description = "WShop Mars Rover  REST APIs",
                    TermsOfService = new Uri("https://example.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "For any information, contact us:",
                        Email = "info@example.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "WShop Mars Rover ",
                        Url = new Uri("https://example.com")
                    }
                });

                x.ExampleFilters();

                // Add common headers here to appear in ui
                x.OperationFilter<CommonParamOperationFilter>();

                // Add JWT authentication support for swagger also.
                //var security = new Dictionary<string, IEnumerable<string>>
                //{
                //    {"Bearer", new string[0] }
                //};

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authentication header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //x.IncludeXmlComments(xmlPath, true);
                AddSwaggerXml(x);
            });

            // Add dynamically created examples from contracts.
            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }

        // Add swagger xml from other projects as well. else other projects model comments 
        // will not be displayed.
        private static void AddSwaggerXml(SwaggerGenOptions c)
        {
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var xmlFile in xmlFiles)
            {
                c.IncludeXmlComments(xmlFile, true);
            }
        }
    }
}






