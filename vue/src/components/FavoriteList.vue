<template>
  <div>
    <h1>{{ this.$store.state.user.username }}'s Favorite Photos</h1>
    <div class="big-parent">
      <div
        class="parent"
        v-for="pic in this.$store.state.user.photos"
        v-bind:key="pic.url"
      >
        <div id="grid-tile">
          <img :src="pic.url" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {

methods:{

//delete photo on-click?

}

};
</script>

<style>
.big-parent {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: space-between;
  margin-top: 50px;
}

h1 {
  text-align: center;
  text-shadow: 2px 2px rgba(0, 0, 0, 0.4);
}

#grid-tile {
  height: 200px;
  width: 200px;
  display: flex;
  background-color: white;
  border-radius: 1%;
  margin: 3px;
  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
}
img {
  height: 100%;
  width: auto;
  margin: auto;
  overflow: hidden;
}
</style>