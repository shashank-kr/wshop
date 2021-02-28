let mapNavService = (mapWidth, mapHeight) => {
  const width = mapWidth;
  const height = mapHeight;
  const orientations = ["N", "E", "S", "W"];

  let isOutOfBounds = ({ x, y }) => {
    if (x < 0 || y < 0 || x > width - 1 || y > height - 1) {
      return true;
    }
    return false;
  };

  let hasCollided = ({ x, y }, collidableObjArray) => {
    return (
      collidableObjArray.find(
        collidableObj => collidableObj.x === x && collidableObj.y === y
      ) != null
    );
  };

  let getPositionFromSequence = (sequence, start) => {
    let newPosition = { ...start };

    for (var i = 0; i < sequence.length; i++) {
      if (sequence[i] == "M") {
        // process Move
        newPosition = _moveForwards(newPosition);
      }
      if (sequence[i] == "L" || sequence[i] == "R") {
        // rotate
        newPosition.orientation = _rotate(sequence[i], newPosition.orientation);
      }
    }
    return newPosition;
  };

  let _moveForwards = ({ x, y, orientation }) => {
    let newPos = { x, y, orientation };
    switch (orientation) {
      case "N":
        newPos.y = y + 1;
        break;
      case "S":
        newPos.y = y - 1;
        break;
      case "E":
        newPos.x = x + 1;
        break;
      case "W":
        newPos.x = x - 1;
        break;
    }
    return newPos;
  };

  let _rotate = (direction, currentOrientation) => {
    let currentOrientationIndex = orientations.indexOf(currentOrientation);
    let mod = direction === "L" ? -1 : 1;
    let newIndex = currentOrientationIndex + mod;
    if (newIndex < 0) {
      newIndex = orientations.length - 1;
    } else if (newIndex == orientations.length) {
      newIndex = 0;
    }

    return orientations[newIndex];
  };

  return {
    isOutOfBounds: isOutOfBounds,
    hasCollided: hasCollided,
    getPositionFromSequence: getPositionFromSequence
  };
};

export default mapNavService;
