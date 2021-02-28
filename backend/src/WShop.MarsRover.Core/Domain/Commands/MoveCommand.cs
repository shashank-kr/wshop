using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.ValueTypes;

namespace WShop.MarsRover.Core.Domain.Commands
{
    public class MoveCommand : Command<RoverAggregate, Identity, IExecutionResult>
    {
        public MoveCommand(
            Identity id) 
            : base(id)
        {
        }
    }
}