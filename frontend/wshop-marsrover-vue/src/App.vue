<template>
  <div id="app" class="container">
    <div class="row">
      <div class="col-md-8">
        <Grid
          :width="gridWidth"
          :height="gridHeight"
          :rovers="rovers"
          :craters="craters"
        ></Grid>
      </div>
      <div class="col-md-4">
        <RoversUI
          :rovers="rovers"
          :activeRoverNum="activeRoverNum"
          @switch-rover="setActiveRover"
          @update-rover="updateRover"
        ></RoversUI>
      </div>
    </div>
  </div>
</template>

<script>
import Vue from "vue";
import RoversUI from "./components/RoversUI.vue";
import Grid from "./components/Grid.vue";
import { gameConfig, roverConfig } from "./gameConfig.js";
import mapNavService from "./mapNavService.js";
//import { moveRover } from "@/api/marsRover.api.js";
import axios from "axios";

let mapNav = mapNavService(gameConfig.gridWidth, gameConfig.gridHeight);

export default {
  name: "app",
  components: {
    Grid,
    RoversUI,
  },
  data: function () {
    return {
      ...gameConfig,
    };
  },
  created: function () {
    for (let i = 0; i < this.numRovers; i++) {
      this.rovers.push({
        ...roverConfig,
      });
      this.rovers[0].isActive = true;
    }
  },
  methods: {
    setActiveRover: function (roverNum) {
      this.activeRoverNum = roverNum;
    },
    updateRover: function (props) {
      console.log("props recv from child", props);
      // because of the UI, we're only ever updating the active rover.
      let landingRover = this.rovers[this.activeRoverNum];

      // update rover with new values from props.
      // need to use Vue.set because landingRover[prop] = ...
      // breaks Vue's setters.
      for (var prop in props) {
        if (props.hasOwnProperty(prop)) {
          Vue.set(landingRover, prop, props[prop]);
        }
      }
    },
    checkOutOfBounds: function () {
      if (mapNav.isOutOfBounds(this.activeRover)) {
        this.updateRover({ isDisabled: true });
      }
    },
    checkCollision: function () {
      if (mapNav.hasCollided(this.activeRover, this.craters)) {
        this.updateRover({ isDisabled: true });
      }
    },
  },
  computed: {
    currentSequence: function () {
      if (!this.activeRover) {
        return;
      }
      return this.activeRover.sequence;
    },
    activeRover: function () {
      return this.rovers[this.activeRoverNum];
    },
    hasLanded: function () {
      if (!this.activeRover) {
        return;
      }
      return this.activeRover.hasLanded;
    },
  },
  watch: {
    currentSequence: function (newVal) {
      /* currentSequence is the input sequence ('MLMMR' etc) of the
       current rover. We watch it for changes; any change is
       essentially a 'turn', so this is the game loop.
    */
      let startPos = {
        x: this.activeRover.startX,
        y: this.activeRover.startY,
        orientation: this.activeRover.startOrientation,
      };

      //let newPos = mapNav.getPositionFromSequence(newVal, startPos);
      let roverStartPos = `${this.activeRover.startX} ${this.activeRover.startY} ${this.activeRover.startOrientation}`;
      let roverCommand = newVal;
      let PlateauAggregateId = "identity-abcf1329-0ae1-42c0-8aa0-bcc8d95720f2";
      let PlateauSurfaceSize = "5 5";
      let roverId = "identity-d65f6880-ac9f-4f13-bbac-0e74f45f9ecb";

      console.log(
        "URL called",
        process.env.VUE_APP_BASE_URL + "/MarsRover/MoveRover"
      );

      axios
        .post("https://localhost:5001/api/v1/MarsRover/MoveRover", {
          roverCommand: roverCommand,
          roverId: roverId,
          plateauAggregateId: PlateauAggregateId,
          roverPosition: roverStartPos,
          plateauSurfaceSize: PlateauSurfaceSize,
        })
        .then((response) => {
          let newPos = response.data.roverPosition;

          console.log("New position fetched", newPos);

          this.updateRover(newPos);

          this.checkOutOfBounds();
          this.checkCollision();
        });
    },
    activeRoverNum: function (newVal) {
      this.rovers.forEach((rover, index) => {
        if (index === newVal) {
          rover.isActive = true;
        } else {
          rover.isActive = false;
        }
      });
    },
    hasLanded: function (newVal, oldVal) {
      // check out of bounds on landing.
      if (newVal === true && oldVal === false) {
        // has just landed.
        this.checkOutOfBounds();
        this.checkCollision();
      }
    },
  },
};
</script>

<style lang="scss">
@import "./styles/bootstrap.min.css";
@import "./styles/_variables.scss";

body {
  background: $background;
}
#app {
  margin: 0px;
  background: $background;
  color: $monochrome;
  font-family: "Press Start 2P", cursive;
}

#app,
h1,
h2,
h3,
h4,
h5 {
  font-size: 12px;
}

label {
  font-weight: normal;
  margin: 5px 0;
}
input,
button,
textarea {
  background: $background;
  border: 1px solid $monochrome-dark;
  color: $monochrome;
  font-family: $monofont;
  padding: 5px;
  &:focus {
    outline: none;
    color: $monochrome-active;
  }
  &[disabled] {
    border-color: $monochrome-disabled;
    color: $monochrome-disabled;
  }
}

.input-block {
  margin-top: 20px;
  margin-bottom: 10px;
}

.expandable-enter-active,
.expandable-leave-active {
  overflow: hidden;
  max-height: 500px;
  transition: all $menu-animation-duration linear;
}

.expandable-enter-active {
  transition: all $menu-animation-duration linear $menu-animation-duration;
}

.expandable-enter,
.expandable-leave-to {
  max-height: 0px;
}

@media (min-width: 768px) {
  #app {
    margin: 20px;
  }
}
</style>
