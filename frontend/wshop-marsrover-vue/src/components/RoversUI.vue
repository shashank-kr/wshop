<template>
  <div class="RoversUI">
    <h3>Select rover</h3>
    <ul>
      <li
        v-for="(rover, index) in rovers"
        :key="index"
        :class="{ active: activeRoverNum === index }"
      >
        <button @click="$emit('switch-rover', index)">{{ index }}</button>
      </li>
    </ul>

    <transition-group name="expandable">
      <LandingHUD
        v-for="(rover, index) in rovers"
        :rover="rover"
        :key="index"
        @land="updateRover"
        v-show="index === activeRoverNum && !activeRover.hasLanded"
      ></LandingHUD>
    </transition-group>

    <transition-group name="expandable">
      <MovementHUD
        v-for="(rover, index) in rovers"
        :rover="rover"
        :key="index"
        v-show="index === activeRoverNum && rover.hasLanded"
        @update-sequence="updateRover"
      ></MovementHUD>
    </transition-group>
  </div>
</template>

<script>
import LandingHUD from "./LandingHUD.vue";
import MovementHUD from "./MovementHUD.vue";

export default {
  name: "RoversUI",
  components: { LandingHUD, MovementHUD },
  props: {
    rovers: Array,
    activeRoverNum: Number
  },
  computed: {
    activeRover: function() {
      return { ...this.rovers[this.activeRoverNum] };
    }
  },
  methods: {
    updateRover: function(props) {
      this.$emit("update-rover", props);
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
@import "../styles/_variables.scss";
.RoversUI {
  padding: 20px;
  border: 1px solid $monochrome-dark;
}
ul {
  list-style-type: none;
  padding: 0;
  li {
    display: inline-block;
    border: 1px solid $monochrome;

    &.active {
      border-bottom: none;
      button {
        color: $monochrome-active;
      }
    }
    button {
      border: none;
      background: none;
      padding: 10px;
    }
  }
}
</style>
