
import './Tile.scss';
import React from 'react';
import Rover from "./Rover";

const Tile = (props) => {

  const rover = props.rovers.find(rover => rover.x === props.x && rover.y === props.y);
  const hasRover = rover != null;
  const hasCrater = props.craters.find(crater => crater.x === props.x && crater.y === props.y) != null;

  console.log('Tile:: rendered.');

  return (
    <div className={"tile"} style={{ width: props.width + '%' }} >
      <div className="inner" >
        {(hasCrater) && <div className="crater">O</div>}
        {(hasRover) && <Rover rover={rover}></Rover>}
      </div>
    </div>
  );
}

export default Tile;