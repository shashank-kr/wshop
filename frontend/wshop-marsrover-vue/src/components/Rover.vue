<template>
  <div class="icon" :class="roverClasses" :style="orientationStyle">
    <span v-if="!rover.isDisabled">A</span>
    <span v-else class="error">X</span>
  </div>
</template>

<script>
export default {
  name: "Rover",
  props: {
    rover: Object
  },
  data: function() {
    return {
      orientationStyle: {}
    };
  },
  methods: {
    setOrientationStyle: function(suppressAnimation) {
      // because a css rotation from 270deg to 0deg
      // will rotate counterclockwise, we can't just
      // just set the rotation from the current orientation
      // via classes (left commented in, below). The rotation
      // has to be cumulative (360deg if we're coming from 270deg, etc)
      let deg = 0;
      switch (this.rover.startOrientation) {
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
      for (let i = 0; i < this.rover.sequence.length; i++) {
        if (this.rover.sequence[i] == "L") {
          deg -= 90;
        }
        if (this.rover.sequence[i] == "R") {
          deg += 90;
        }
      }
      let style = {
        transform: "rotate(" + deg + "deg)"
      };
      if (suppressAnimation) {
        style.transition = "none";
      }
      this.orientationStyle = style;
    }
  },
  computed: {
    orientation: function() {
      return this.rover.orientation;
    },
    roverClasses: function() {
      let classes = {
        active: this.rover.isActive,
        disabled: this.rover.isDisabled
      };
      // see note under the orientation watcher.
      // classes["orientation-" + this.rover.orientation] = true;
      return classes;
    }
  },
  watch: {
    orientation: function(newVal, oldVal) {
      this.setOrientationStyle();
    }
  },
  mounted: function() {
    const suppressAnimation = true;
    this.setOrientationStyle(suppressAnimation);
  }
};
</script>

<style scoped lang="scss">
@import "../styles/_variables.scss";
.icon {
  transition: transform 0.3s ease;
  color: $rover-colour;
}
.active {
  color: $rover-colour-active;
}
.disabled {
  color: $rover-colour-disabled;
}
// .orientation-N {
//   transform: rotate(0deg);
// }
// .orientation-E {
//   transform: rotate(90deg);
// }
// .orientation-S {
//   transform: rotate(180deg);
// }
// .orientation-W {
//   transform: rotate(270deg);
// }
</style>