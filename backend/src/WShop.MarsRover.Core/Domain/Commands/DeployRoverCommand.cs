using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.ValueTypes;

namespace WShop.MarsRover.Core.Domain.Commands
{
    public class DeployRoverCommand : Command<RoverAggregate, Identity, IExecutionResult>
    {
        public DeployRoverCommand(
            Identity id,
            Identity plateauSurfaceId,
            string roverPositionInput) 
            : base(id)
        {
            PlateauSurfaceId = plateauSurfaceId;
            RoverPositionInput = roverPositionInput;
        }

        public string RoverPositionInput { get; }
        public Identity PlateauSurfaceId { get; }
    }
}