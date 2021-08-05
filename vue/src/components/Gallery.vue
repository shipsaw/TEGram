<template>
  <div>
    <!-- 
  grid full of pics by user id -->
  
    <div class="gallery-grid" v-for="pic in this.$store.state.user.photos" v-bind:key="pic.Url">


    <img :src= pic.url> 
    <p>{{pic.comments}}</p>


    </div>
    <div class="test">this is a test div</div>
  </div>
</template>

<script>
export default {
  computed: {
    getPics() {
      let picUrl;
      this.$store.state.user.photos.forEach((pic) => {
        picUrl = pic.url;
      });
      return picUrl;
    },
  },
};
</script>

<style>

img{
height: 300px;
width: 300px;
}

.gallery-grid {
  display: flex;
  background-color: lightgreen;
}
.test {
  background-color: pink;
  height: 500px;
}
</style>