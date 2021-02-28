import './Rover.scss';
import React, { useEffect, useState } from 'react';

const Rover = (props) => {

  const [orientationStyleState, setOrientationStyleState] = useState({});

  const setOrientationStyle = (suppressAnimation) => {
    // because a css rotation from 270deg to 0deg
    // will rotate counterclockwise, we can't just
    // just set the rotation from the current orientation
    // via classes (left commented in, below). The rotation
    // has to be cumulative (360deg if we're coming from 270deg, etc)
    let deg = 0;
    switch (props.rover.startOrientation) {
      case "N":
        deg = 0;
        break;
      case "E":
        deg = 90;
        break;
      case "S":
        deg = 180;
        break;
      case "W":
        deg = 270;
        break;
    }
    for (let i = 0; i < props.rover.sequence.length; i++) {
      if (props.rover.sequence[i] == "L") {
        deg -= 90;
      }
      if (props.rover.sequence[i] == "R") {
        deg += 90;
      }
    }
    let style = {
      transform: "rotate(" + deg + "deg)"
    };
    if (suppressAnimation) {
      style.transition = "none";
    }

    setOrientationStyleState({ style })
  }

  const orientation = props.rover.orientation;

  useEffect(() => {
    console.log('Rover: Useeffect Setting setOrientationStyle for orientation', orientation)
    setOrientationStyle();
  }, [orientation]);

  useEffect(() => {
    console.log('Rover: Useeffect setOrientationStyle with suppressAnimation', suppressAnimation);
    const suppressAnimation = true;
    setOrientationStyle(suppressAnimation);
  }, []);


  console.log('Rover: rendered')
  return (
    <div>
      <div className={`icon ${props.rover.isActive ? "active" : ""} ${props.rover.isDisabled ? "disabled" : ""}`} style={{ orientationStyleState }} >
        {(!props.rover.isDisabled) ? <span>A</span> : <span className="error">X</span>}
      </div>
    </div >
  )
}

export default Rover;
