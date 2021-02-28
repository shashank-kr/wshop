using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.Commands;
using WShop.MarsRover.Core.Domain.ValueTypes;
using System.Threading;
using System.Threading.Tasks;

namespace WShop.MarsRover.Application.CommandHandlers
{
    public class TurnRightCommandHandler :
         CommandHandler<RoverAggregate, Identity, IExecutionResult, TurnRightCommand>
    {
        public override async Task<IExecutionResult> ExecuteCommandAsync(
            RoverAggregate aggregate,
            TurnRightCommand command,
            CancellationToken cancellationToken)
        {
            IExecutionResult executionResult = aggregate.TurnRight();

            return await Task.FromResult(executionResult);
        }
    }
}