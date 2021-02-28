import httpClient from './httpClient';

const END_POINT = '/MarsRover/MoveRover';

const moveRover = (roverCommand, roverId, plateauAggregateId, roverPosition, plateauSurfaceSize) =>
    httpClient.post(END_POINT, {
        roverCommand: roverCommand,
        roverId: roverId,
        plateauAggregateId: plateauAggregateId,
        roverPosition: roverPosition,
        plateauSurfaceSize: plateauSurfaceSize
    });

export {
    moveRover
    //   deployRover
}
