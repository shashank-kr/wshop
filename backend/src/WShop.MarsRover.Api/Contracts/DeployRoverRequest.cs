using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WShop.MarsRover.Api.Contracts
{
    public class DeployRoverRequest
    {
        public string RoverPosition { get; set; }
        public string PlateauAggregateId { get; set; }
        public string RoverId { get; set; }
    }
}
