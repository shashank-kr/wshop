using WShop.MarsRover.Application.Common.Bases;
using System;
using Newtonsoft.Json;

namespace WShop.MarsRover.Application.Common.Models
{
    public class PagedResponse<TOutput> : BaseResponse<TOutput>
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("firstPage")]
        public Uri FirstPage { get; set; }
        [JsonProperty("lastPage")]
        public Uri LastPage { get; set; }
        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
        [JsonProperty("totalRecords")]
        public int TotalRecords { get; set; }
        [JsonProperty("nextPage")]
        public Uri NextPage { get; set; }
        [JsonProperty("previousPage")]
        public Uri PreviousPage { get; set; }


        public PagedResponse() { }

        public PagedResponse(TOutput data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.Errors = null;
        }
    }
}
