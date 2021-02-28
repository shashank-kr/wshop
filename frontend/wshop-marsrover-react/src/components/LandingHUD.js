import './LandingHUD.scss';
import React, { useState } from 'react';

const LandingHUD = (props) => {

  const [landingState, setLandingState] = useState({
    x: props.rover.x,
    y: props.rover.y,
    orientation: props.rover.orientation
  });


  const handleInputChange = (event) => {
    setLandingState((prevState) => {
      return { ...prevState, [event.target.name]: event.target.value };
    });
  }

  const onLandClickHandler = () => {

    console.log('LandingHUD: onLandClickHandler called')
    // Pass data to parent
    props.land({
      startX: landingState.x,
      startY: landingState.y,
      startOrientation: landingState.orientation,
      x: landingState.x,
      y: landingState.y,
      orientation: landingState.orientation,
      hasLanded: true
    });
  }

  const invalidData = landingState.x == null || landingState.x == "" || landingState.y == "" || landingState.y == null ||
    (landingState.orientation !== "N" &&
      landingState.orientation !== "S" &&
      landingState.orientation !== "E" &&
      landingState.orientation !== "W");

  console.log('LandingHUD: rendered')

  return (
    <div>
      <div>
        <h4>Land rover<br />========== </h4>
        <div className="coords">
          <div className="input-group--column">
            <label htmlFor="LandingHUD-x">X</label>
            <input id="LandingHUD-x" type="number" name="x" min="0" max="99" value={landingState.x || ''} onChange={handleInputChange} />
          </div>
          <div className="input-group--column">
            <label htmlFor="LandingHUD-y">Y</label>
            <input id="LandingHUD-y" type="number" name="y" min="0" max="99" value={landingState.y || ''} onChange={handleInputChange} />
          </div>
        </div>

        <label htmlFor="LandingHUD-orientation">Direction</label>
        <select id="LandingHUD-orientation" name="orientation" value={landingState.orientation} onChange={handleInputChange}>
          <option></option>
          <option value="N">N</option>
          <option value="E">E</option>
          <option value="S">S</option>
          <option value="W">W</option>
        </select>

        <div className="input-group--row button-land-container">
          {
            (!props.rover.hasLanded) &&
            <button className="button-land"
              onClick={onLandClickHandler}
              disabled={invalidData}>
              Land
              </button>}
        </div>
      </div>
    </div >
  );
}

export default LandingHUD;
