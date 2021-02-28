import './Grid.scss';
import React from 'react';
import Tile from "./Tile";


const Grid = (props) => {

  const gridTiles = () => {
    let tiles = [];
    for (let row = 0; row < props.height; row++) {
      for (let column = 0; column < props.width; column++) {
        tiles.push({
          id: row * props.width + column,
          x: column,
          y: row
        });
      }
    }

    return tiles;
  }

  console.log('Grid : rendered');

  return (
    <div className="grid" style={{ 'minWidth': (12 * props.width) + 'px' }}>
      {gridTiles().map(tile => {
        return <Tile
          key={tile.id}
          width={(100 / props.width)}
          x={tile.x}
          y={tile.y}
          rovers={props.rovers}
          craters={props.craters}>
        </Tile>
      })}
    </div>
  );
}

export default Grid;
