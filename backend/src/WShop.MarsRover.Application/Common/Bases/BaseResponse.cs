using WShop.MarsRover.Application.Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WShop.MarsRover.Application.Common.Bases
{
    public class BaseResponse<TOutput>
    {
        public BaseResponse()
        {

        }

        public BaseResponse(TOutput output)
        {
            Data = output;
            Message = string.Empty;
        }
        [JsonProperty("data")]
        public TOutput Data { get; set; }
        [JsonProperty("errors")]
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        /// <summary>
        /// global validation message. It is used as a success message if Success is false, 
        /// otherwise it is an error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; } = true;

        public BaseResponse<TOutput> AddErrorResponse(string key, string[] errorMessages)
        {
            Errors.Add(new ErrorModel(key, errorMessages));
            Success = false;
            return this;
        }
        
    }
}