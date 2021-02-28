using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.ValueTypes;

namespace WShop.MarsRover.Core.Domain.Commands
{
    public class TurnRightCommand : Command<RoverAggregate, Identity, IExecutionResult>
    {
        public TurnRightCommand(
            Identity id) 
            : base(id)
        {
        }
    }
}