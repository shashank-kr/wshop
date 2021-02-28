using EventFlow;
using EventFlow.Configuration;
using EventFlow.Extensions;
using WShop.MarsRover.Application.CommandHandlers;
using WShop.MarsRover.Core.Domain.Commands;

namespace WShop.MarsRover.Application
{
    public class RoverModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions.AddDefaults(typeof(CreatePlateauSurfaceCommandHandler).Assembly);
            eventFlowOptions.AddDefaults(typeof(CreatePlateauSurfaceCommand).Assembly);
        }
    }
}