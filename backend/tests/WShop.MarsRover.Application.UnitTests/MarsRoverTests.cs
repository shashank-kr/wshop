
using EventFlow;
using EventFlow.Aggregates;
using EventFlow.Commands;
using EventFlow.Extensions;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.Commands;
using WShop.MarsRover.Core.Domain.Enums;
using WShop.MarsRover.Core.Domain.ValueTypes;
using WShop.MarsRover.Core.Helpers;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace WShop.MarsRover.Application.UnitTests
{
    public class MarsRoverTests
    {
        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", 1, 3, Orientation.N })]
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", 5, 1, Orientation.E })]
        public void GeneratePlataueAndExecuteRoverCommands(
            string plateauSurfaceSize,
            string roverPosition,
            string roverCommand,
            int expectedX,
            int exceptedY,
            Orientation expectedOrientation
            )
        {
            RoverAggregate rover;
            var roverId = Identity.New;

            using (var resolver = EventFlowOptions.New
                                                  .RegisterModule<RoverModule>()
                                                  .UseNullLog()
                                                  .CreateResolver())
            {
                Helpers.RootResolver = resolver;

                var commandBus = resolver.Resolve<ICommandBus>();

                var plateauAggregateId = Identity.New;

                var createPlateauSurfaceCommand = new CreatePlateauSurfaceCommand(plateauAggregateId, plateauSurfaceSize);
                var deployRoverCommand = new DeployRoverCommand(roverId, plateauAggregateId, roverPosition);

                var commands = new List<ICommand>
                {
                    createPlateauSurfaceCommand,
                    deployRoverCommand
                };
                commands.AddRange(roverCommand.ToRoverCommands(roverId));

                commandBus
                    .PublishMultipleAsync(commands.ToArray())
                    .GetAwaiter()
                    .GetResult();

                var aggregateStore = resolver.Resolve<IAggregateStore>();
                rover = aggregateStore.LoadAsync<RoverAggregate, Identity>(roverId, CancellationToken.None).Result;
            }

            Assert.NotNull(rover);
            Assert.NotNull(rover.RoverPosition);
            Assert.Equal(expectedX, rover.RoverPosition.X);
            Assert.Equal(exceptedY, rover.RoverPosition.Y);
            Assert.Equal(expectedOrientation, rover.RoverPosition.Orientation);
        }
    }
}

