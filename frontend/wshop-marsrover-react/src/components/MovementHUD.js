import './MovementHUD.scss'

import React, { useEffect, useState } from 'react';

const MovementHUD = (props) => {

  const [sequenceState, setSequenceState] = useState("");

  console.log('Seq state', sequenceState);

  const coordinateOutput = props.rover.x + " " + props.rover.y + " " + props.rover.orientation;
  const sequenceUpper = sequenceState.toUpperCase().replace(/[A-KN-QS-Z0-9]/gi, "");

  const issueCommand = (command) => {
    console.log('MovementHUD:issueCommand:issue command', command)
    setSequenceState(prevState => {
      return prevState + command;
    })
  }

  useEffect(() => {
    console.log('MovementHUD:Useeffect:updating sequence', sequenceUpper)
    props.updateSequence(sequenceUpper);
  }, [sequenceState]);

  const handleSequence = ($event) => {
    setSequenceState($event.target.value);
  }

  console.log('MovementHUD: Rendered')

  return (
    <div>
      <div>
        <h4>
          Move Rover
      <br />==========
    </h4>
        {!(props.rover.isDisabled) &&
          <div>
            <div className="input-block">
              <p>Rotate</p>
              <button onClick={() => issueCommand('L')}>L</button>
              <button onClick={() => issueCommand('R')}>R</button>
            </div>

            <div className="input-block">
              <p>Move Forward</p>
              <button onClick={() => issueCommand('M')}>Go</button>
            </div>

            <div className="input-block">
              <p>Sequence</p>
              <input type="text" className="sequence-input" value={sequenceUpper} onChange={handleSequence} />
            </div>
          </div >
        }

        {
          (props.rover.isDisabled) &&
          <div>
            <p className="error">Alert: Communication error. Rover Disabled</p>
          </div>
        }

        <div className="input-block">
          <p>Position:</p>
          <p>{coordinateOutput}</p>
        </div>
      </div >
    </div >
  );
}


export default MovementHUD;