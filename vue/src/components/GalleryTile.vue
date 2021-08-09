<template>
<div id="background">
  <h1>{{this.$store.state.user.username}}'s Photo Gallery</h1>
  <div class="big-parent">
   
    <div class="parent" v-for="pic in this.$store.state.user.photos" v-bind:key="pic.url">
      <div id="grid-tile">
        <img :src= pic.url >
      </div>
    </div>

    </div>

  </div>
</template>

<script>
export default {
  
};
</script>

<style>
/* 
.gallery-grid {
  display: flex;
  background-color: lightgreen;
} */

.big-parent{
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: space-between;
  margin-top: 50px;
}


#grid-tile {
  height: 200px;
  width: 200px;
 display:flex;
  background-color: white;
  border-radius:1%;
  margin:3px;
box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
   
}
img {
  height: 100%;
  width: auto;
  margin: auto;
  overflow: hidden;
}

</style>