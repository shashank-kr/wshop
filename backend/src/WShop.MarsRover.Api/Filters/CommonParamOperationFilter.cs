using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WShop.MarsRover.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace WShop.MarsRover.Api.Filters
{
    public class CommonParamOperationFilter : IOperationFilter
    {        

        public CommonParamOperationFilter()
        {
            
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

            var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            
            // Add api_key header param for all actions except 'CheckMailExists'            
            if (descriptor != null && !descriptor.ActionName.StartsWith("CheckMailExists"))
            {
                operation.Parameters.Add(new OpenApiParameter()
                {
                    Name = "",
                    In = ParameterLocation.Header,
                    Description = "Your api key",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Description = "Api Key"
                    }
                });
            }
        }
    }

}