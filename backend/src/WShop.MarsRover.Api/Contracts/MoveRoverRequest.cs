namespace WShop.MarsRover.Api.Contracts
{
    public class MoveRoverRequest
    {
        public string RoverCommand { get; set; }
        public string RoverId { get; set; }

        // TEMP
        public string PlateauAggregateId { get; set; }
        public string RoverPosition { get; set; }
        public string PlateauSurfaceSize { get; set; }

    }
}
