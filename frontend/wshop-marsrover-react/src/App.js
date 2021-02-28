import './App.scss';
import React, { useEffect, useRef, useState } from 'react';

import RoversUi from "./components/RoversUi";
import Grid from "./components/Grid";
import { gameConfig, roverConfig } from "./gameConfig.js";
import mapNavService from "./mapNavService.js";

const App = () => {
  let mapNav = mapNavService(gameConfig.gridWidth, gameConfig.gridHeight);

  const [gameConfigState, setGameConfigState] = useState({ ...gameConfig });
  const [roverConfigState, setRoverConfigState] = useState({ ...roverConfig });

  const hasLandedRef = useRef(false);

  // Init rovers
  useEffect(() => {
    console.log('App : useeffect: initialising rovers');
    for (let i = 0; i < gameConfigState.numRovers; i++) {
      setGameConfigState(prevState => {
        let tempGameState = { ...prevState, rovers: [...prevState.rovers, roverConfigState] };
        tempGameState.rovers[0].isActive = true;
        return tempGameState;
      });
    }
  }, []);

  const setActiveRover = (roverNum) => {
    console.log('App : setActiveRover called with roverNum', roverNum)
    setGameConfigState((prevState) => {
      return { ...prevState, activeRoverNum: roverNum }
    });
  }

  const updateRover = (props) => {
    console.log('App: updateRover called with props', props)
    let landingRover = gameConfigState.rovers[gameConfigState.activeRoverNum];
    // update rover with new values from props.

    for (var prop in props) {
      if (props.hasOwnProperty(prop)) {
        landingRover = { ...landingRover, [prop]: props[prop] }
      }
    }

    setGameConfigState((prevState) => {
      let tempGameConfigState = { ...gameConfigState };
      return tempGameConfigState.rovers[gameConfigState.activeRoverNum] = { ...landingRover };
    })
  }

  console.log('App: active rover is:', gameConfigState.rovers[gameConfigState.activeRoverNum]);
  const activeRover = () => gameConfigState.rovers[gameConfigState.activeRoverNum];
  const currentSequence = () => !activeRover() ? null : activeRover().sequence;
  const hasLanded = () => !activeRover() ? null : activeRover().hasLanded;

  const checkOutOfBounds = () => {
    if (mapNav.isOutOfBounds(activeRover())) {
      updateRover({ isDisabled: true });
    }
  }
  const checkCollision = () => {
    if (mapNav.hasCollided(activeRover(), gameConfigState.craters)) {
      updateRover({ isDisabled: true });
    }
  }

  useEffect(() => {
    /* currentSequence is the input sequence ('MLMMR' etc) of the
         current rover. We watch it for changes; any change is
         essentially a 'turn', so this is the game loop.
      */

    console.log('App : Useeffect currentSequence', currentSequence);
    if (activeRover() && currentSequence()) {
      let startPos = {
        x: activeRover().startX,
        y: activeRover().startY,
        orientation: activeRover().startOrientation
      };

      let newPos = mapNav.getPositionFromSequence(currentSequence(), startPos);
      updateRover(newPos);
      checkOutOfBounds();
      checkCollision();

    }

  }, [currentSequence()]);


  useEffect(() => {
    console.log('App : Useeffect : activeRoverNum changed: ', gameConfigState.activeRoverNum)
    gameConfigState.rovers.forEach((rover, index) => {
      if (index === gameConfigState.activeRoverNum) {
        rover.isActive = true;
      } else {
        rover.isActive = false;
      }
    });
  }, [gameConfigState.activeRoverNum]);


  useEffect(() => {
    console.log('App: Useeffect: checking hasLanded', hasLanded);
    hasLandedRef.current = hasLanded;
    // check out of bounds on landing.
    //if (hasLanded === true && hasLandedPrev === false) {
    if (hasLanded() === true && hasLandedRef.current === false) {
      // has just landed.
      checkOutOfBounds();
      checkCollision();
    }
    console.log('App:haslanded current: previous', hasLanded, hasLandedRef.current);

  }, [hasLanded()]);

  console.log('APP: rendered');

  return (
    <div id="app" className="container">
      <div className="row">
        <div className="col-md-8">
          <Grid
            width={gameConfigState.gridWidth}
            height={gameConfigState.gridHeight}
            rovers={gameConfigState.rovers}
            craters={gameConfigState.craters}>
          </Grid>
        </div>
        <div className="col-md-4">
          <RoversUi
            rovers={gameConfigState.rovers}
            activeRoverNum={gameConfigState.activeRoverNum}
            switchRover={setActiveRover}
            updateRover={updateRover}
          ></RoversUi>
        </div>
      </div >
    </div >
  );
}

export default App;

