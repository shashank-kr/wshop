using WShop.MarsRover.Application.Common.Models;
using System.Collections.Generic;

namespace WShop.MarsRover.Application.Common.Models
{
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}