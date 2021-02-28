const gameConfig = {
    gridWidth: 31,
    gridHeight: 25,
    numRovers: 4,
    activeRoverNum: 0,
    rovers: [],
    craters: [
        {
            x: 5,
            y: 7
        },
        {
            x: 12,
            y: 19
        },
        {
            x: 22,
            y: 2
        },
        {
            x: 30,
            y: 20
        }
    ]
};

const roverConfig = {
    hasLanded: false,
    startX: null,
    startY: null,
    startOrientation: "",
    x: null,
    y: null,
    orientation: "",
    sequence: "",
    isDisabled: false,
    isActive: false
};

export { gameConfig, roverConfig };
