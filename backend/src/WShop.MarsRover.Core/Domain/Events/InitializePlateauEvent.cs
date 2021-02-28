using EventFlow.Aggregates;
using EventFlow.EventStores;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.ValueTypes;

namespace WShop.MarsRover.Core.Domain.Events
{
    [EventVersion("InitializePlateau", 1)]
    public class InitializePlateauEvent : AggregateEvent<PlateauAggregate, Identity>
    {
        public InitializePlateauEvent(SurfaceSize surfaceSize)
        {
            Size = surfaceSize;
        }

        public SurfaceSize Size { get; set; }
    }
}