using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using EventFlow.Core;
using EventFlow.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WShop.MarsRover.Api.Constants.Routes.V1;
using WShop.MarsRover.Api.Contracts;
using WShop.MarsRover.Application;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.Commands;
using WShop.MarsRover.Core.Domain.ValueTypes;
using WShop.MarsRover.Core.Helpers;

namespace WShop.MarsRover.Api.Controllers.V1
{
    [Produces("application/json")]
    public class MarsRoverController : ApiController
    {        
        [HttpPost(ApiRoutes.PlateauSurface.CreatePlateauSurface)]
        public async Task<IExecutionResult> CreatePlateauSurface([FromBody] CreatePlateauSurfaceRequest request)
        {                        
            using (var resolver = EventFlowOptions.New
                                                  .RegisterModule<RoverModule>()
                                                  .UseNullLog()
                                                  .CreateResolver())
            {
                Helpers.RootResolver = resolver;
                var commandBus = resolver.Resolve<ICommandBus>();
                var plateauAggregateId = new Identity(request.PlateauAggregateId);
                var createPlateauSurfaceCommand = new CreatePlateauSurfaceCommand(plateauAggregateId, request.PlateauSurfaceSize);                                                
                return await commandBus.PublishAsync(createPlateauSurfaceCommand, CancellationToken.None).ConfigureAwait(false);
            }
        }

        [HttpPost(ApiRoutes.PlateauSurface.DeployRover)]
        public async Task<IExecutionResult> DeployRover([FromBody] DeployRoverRequest request)
        {            
            var roverId = new Identity(request.RoverId);

            using (var resolver = EventFlowOptions.New
                                                  .RegisterModule<RoverModule>()
                                                  .UseNullLog()
                                                  .CreateResolver())
            {
                Helpers.RootResolver = resolver;
                var commandBus = resolver.Resolve<ICommandBus>();
                var plateauAggregateId = new Identity(request.PlateauAggregateId);                
                var deployRoverCommand = new DeployRoverCommand(roverId, plateauAggregateId, request.RoverPosition);               
                return await commandBus.PublishAsync(deployRoverCommand,CancellationToken.None).ConfigureAwait(false);                
            }
        }

        [HttpPost(ApiRoutes.PlateauSurface.MoveRover)]
        public async Task<RoverAggregate> MoveRover([FromBody] MoveRoverRequest request)
        {
            RoverAggregate rover;
            var roverId = new Identity(request.RoverId);
            var plateauAggregateId = new Identity(request.PlateauAggregateId);

            using (var resolver = EventFlowOptions.New
                                                  .RegisterModule<RoverModule>()
                                                  .UseNullLog()
                                                  .CreateResolver())
            {
                Helpers.RootResolver = resolver;
                var commandBus = resolver.Resolve<ICommandBus>();
                var createPlateauSurfaceCommand = new CreatePlateauSurfaceCommand(plateauAggregateId, request.PlateauSurfaceSize);
                var deployRoverCommand = new DeployRoverCommand(roverId, plateauAggregateId, request.RoverPosition);

                var commands = new List<ICommand>
                {
                    createPlateauSurfaceCommand,
                    deployRoverCommand
                };                
                commands.AddRange(request.RoverCommand.ToRoverCommands(roverId));
                await commandBus.PublishMultipleAsync(commands.ToArray());
                   
                var aggregateStore = resolver.Resolve<IAggregateStore>();
                return rover = await aggregateStore.LoadAsync<RoverAggregate, Identity>(roverId, CancellationToken.None);
            }
        }
    }
}