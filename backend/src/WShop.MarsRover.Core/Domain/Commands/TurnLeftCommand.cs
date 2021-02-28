using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.ValueTypes;

namespace WShop.MarsRover.Core.Domain.Commands
{
    public class TurnLeftCommand : Command<RoverAggregate, Identity, IExecutionResult>
    {
        public TurnLeftCommand(
            Identity id) 
            : base(id)
        {
        }
    }
}