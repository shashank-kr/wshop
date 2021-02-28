using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.ValueTypes;

namespace WShop.MarsRover.Core.Domain.Commands
{
    public class CreatePlateauSurfaceCommand : Command<PlateauAggregate, Identity, IExecutionResult>
    {
        public CreatePlateauSurfaceCommand(
            Identity id,
            string surfaceSizeInput) 
            : base(id)
        {
            SurfaceSizeInput = surfaceSizeInput;
        }

        public string SurfaceSizeInput { get; }
    }
}