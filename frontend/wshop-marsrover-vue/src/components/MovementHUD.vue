<template>
  <div>
    <h4>
      Move Rover
      <br>==========
    </h4>
    <div v-if="!rover.isDisabled">
      <div class="input-block">
        <p>Rotate</p>
        <button @click="issueCommand('L')">L</button>
        <button @click="issueCommand('R')">R</button>
      </div>

      <div class="input-block">
        <p>Move Forward</p>
        <button @click="issueCommand('M')">GO!</button>
      </div>

      <div class="input-block">
        <p>Sequence</p>
        <input
          type="text"
          @input="sequence = $event.target.value"
          :value="sequenceUpper"
          class="sequence-input"
        >
      </div>
    </div>
    <div v-else>
      <p class="error">Alert: Communication error. Rover Disabled</p>
    </div>
    <div class="input-block">
      <p>Position:</p>
      <p>{{ coordinateOutput }}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "MovementHUD",
  props: {
    rover: Object
  },
  data: function() {
    return {
      sequence: ""
    };
  },
  computed: {
    coordinateOutput: function() {
      return this.rover.x + " " + this.rover.y + " " + this.rover.orientation;
    },
    sequenceUpper: function() {
      return this.sequence.toUpperCase().replace(/[A-KN-QS-Z0-9]/gi, "");
    }
  },
  methods: {
    issueCommand: function(command) {
      this.sequence += command;
    }
  },
  watch: {
    sequenceUpper: function() {
      this.$emit("update-sequence", { sequence: this.sequenceUpper });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
@import "../styles/_variables.scss";
label {
  display: block;
}
.error {
  color: $monochrome-error;
}
.sequence-input {
  width: 100%;
}
button {
  margin-right: 20px;
}
</style>
