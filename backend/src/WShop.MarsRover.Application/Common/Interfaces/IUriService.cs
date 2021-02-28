
using WShop.MarsRover.Application.Common.Models;
using System;

namespace WShop.MarsRover.Application.Common.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
