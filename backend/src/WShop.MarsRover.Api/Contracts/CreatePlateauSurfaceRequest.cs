using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WShop.MarsRover.Api.Contracts
{
    public class CreatePlateauSurfaceRequest
    {
        public string PlateauSurfaceSize { get; set; }
        public string PlateauAggregateId { get; set; }
    }
}
