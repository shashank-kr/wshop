import './RoversUi.scss';
import React from 'react';
import LandingHUD from "./LandingHUD";
import MovementHUD from "./MovementHUD";
import TransitionGroup from 'react-transition-group/TransitionGroup';
import CSSTransition from 'react-transition-group/CSSTransition';

const RoversUi = (props) => {


  const activeRover = { ...props.rovers[props.activeRoverNum] };

  const updateRoverHandler = (rover) => {
    console.log('RoverUI::Update roverhandler called', rover);
    props.updateRover(rover);
  }

  const switchRoverHandler = (index) => {
    console.log('RoverUI::switchRoverHandler called', index);
    props.switchRover(index);
  }

  console.log('RoverUI:: render');

  return (
    <div>
      <div className="RoversUi">
        <h3>Select rover</h3>
        <ul>
          {
            props.rovers.map((rover, index) => {
              return (
                <li key={index} className={(props.activeRoverNum === index) ? "active" : ""}>
                  <button
                    onClick={switchRoverHandler.bind(null, index)}>
                    {index}
                  </button>
                </li>)
            })
          }
        </ul>

        <TransitionGroup component={null} name="expandable">
          {props.rovers.map((rover, index) => (
            (index === props.activeRoverNum && !activeRover.hasLanded) &&
            (<CSSTransition timeout={500} className="fade" key={index} >
              <LandingHUD
                rover={rover}
                key={index}
                land={updateRoverHandler}
              ></LandingHUD>
            </CSSTransition>)
          )
          )}
        </TransitionGroup>

        <TransitionGroup component={null} name="expandable">
          {props.rovers.map((rover, index) => (
            (index === props.activeRoverNum && rover.hasLanded) &&
            (<CSSTransition timeout={50000} className="fade" key={index} >
              <MovementHUD
                rover={rover}
                key={index}
                updateSequence={updateRoverHandler}
              ></MovementHUD>
            </CSSTransition>)
          )
          )}
        </TransitionGroup>
      </div >
    </div >
  )
};

export default RoversUi;

