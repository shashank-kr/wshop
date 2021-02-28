using System.Linq;
using System.Threading.Tasks;
using WShop.MarsRover.Application.Common.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace WShop.MarsRover.Api.Filters
{
    /// <summary>
    /// Centralized validation Error Response for Input Data.
    /// </summary>
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {           
            if (!context.ModelState.IsValid)
            {                
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage));

                //var errorResponse = new ErrorResponse();
                var errorResponse = new BaseResponse<object>();

                // Populate the errors in error response
                foreach (var error in errorsInModelState)
                {
                    errorResponse.AddErrorResponse(error.Key, error.Value.ToArray());
                }

                // return the error to the end users.
                context.Result = new BadRequestObjectResult(errorResponse);                
                return;
            }

            await next();

            // after controller
            //...
        }
    }
}