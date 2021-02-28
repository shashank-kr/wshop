using EventFlow.Aggregates;
using EventFlow.EventStores;
using WShop.MarsRover.Core.Domain.Aggregates;
using WShop.MarsRover.Core.Domain.Enums;
using WShop.MarsRover.Core.Domain.ValueTypes;

namespace WShop.MarsRover.Core.Domain.Events
{
    [EventVersion("MoveRover", 1)]
    public class MoveRoverEvent : AggregateEvent<RoverAggregate, Identity>
    {
        public MoveRoverEvent(Movement movement)
        {
            MoveRover = movement;
        }

        public Movement MoveRover { get; set; }
    }
}