<template>
  <div class="grid" style="{ 'min-width': (12 * width) + 'px' }">
    <Tile
      v-for="tile in gridTiles"
      :key="tile.id"
      :width="(100/width)"
      :x="tile.x"
      :y="tile.y"
      :rovers="rovers"
      :craters="craters"
    ></Tile>
  </div>
</template>

<script>
import Tile from "./Tile";

export default {
  name: "Grid",
  components: {
    Tile
  },
  props: {
    rovers: Array,
    craters: Array,
    width: Number,
    height: Number
  },
  computed: {
    gridTiles: function() {
      let tiles = [];
      for (let row = 0; row < this.height; row++) {
        for (let column = 0; column < this.width; column++) {
          tiles.push({
            id: row * this.width + column,
            x: column,
            y: row
          });
        }
      }
      return tiles;
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
@import "../styles/_variables.scss";
.grid {
  border: 1px solid $monochrome-dark;
  display: flex;
  flex-wrap: wrap-reverse;
  .tile {
    min-width: 10px;
  }
}
</style>
