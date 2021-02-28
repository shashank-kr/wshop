<template>
  <div class="tile" :style="{ width: width + '%'}">
    <div class="inner">
      <div class="crater" v-if="hasCrater">O</div>
      <Rover v-if="hasRover" :rover="rover"></Rover>
    </div>
  </div>
</template>

<script>
import Rover from "./Rover";

export default {
  name: "Tile",
  components: {
    Rover
  },
  props: {
    width: Number,
    x: Number,
    y: Number,
    rovers: Array,
    craters: Array
  },
  computed: {
    rover: function() {
      return this.rovers.find(
        rover => rover.x === this.x && rover.y === this.y
      );
    },
    hasRover: function() {
      return this.rover != null;
    },
    hasCrater: function() {
      return (
        this.craters.find(
          crater => crater.x === this.x && crater.y === this.y
        ) != null
      );
    }
  }
};
</script>

<style scoped lang="scss">
@import "../styles/_variables.scss";
.tile {
  border: 1px solid $monochrome-dark;
  .inner {
    position: relative;
    padding-top: 100%;
    & > div {
      position: absolute;
      top: 0;
      left: 0;
    }
  }
  @media (max-width: 767px) {
    font-size: 9px;
  }
}

.crater {
  color: $obstacle-colour;
}
</style>