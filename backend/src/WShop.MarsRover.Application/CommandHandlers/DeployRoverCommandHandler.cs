using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.Commands;
using WShop.MarsRover.Core.Domain.ValueTypes;
using System.Threading;
using System.Threading.Tasks;

namespace WShop.MarsRover.Application.CommandHandlers
{
    public class DeployRoverCommandHandler :
         CommandHandler<RoverAggregate, Identity, IExecutionResult, DeployRoverCommand>
    {
        public override async Task<IExecutionResult> ExecuteCommandAsync(
            RoverAggregate aggregate,
            DeployRoverCommand command,
            CancellationToken cancellationToken)
        {
            IExecutionResult executionResult = aggregate.DeployRover(command.RoverPositionInput, command.PlateauSurfaceId);

            return await Task.FromResult(executionResult);
        }
    }
}