using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.Commands;
using WShop.MarsRover.Core.Domain.ValueTypes;
using System.Threading;
using System.Threading.Tasks;

namespace WShop.MarsRover.Application.CommandHandlers
{
    public class MoveCommandHandler :
         CommandHandler<RoverAggregate, Identity, IExecutionResult, MoveCommand>
    {
        public override async Task<IExecutionResult> ExecuteCommandAsync(
            RoverAggregate aggregate,
            MoveCommand command,
            CancellationToken cancellationToken)
        {
            IExecutionResult executionResult = aggregate.MoveAsync();

            return executionResult;
        }
    }
}