<template>
  <div class="home">
    <h1>Home</h1>
    <p>This is the Home view </p>
<home-feed/>

  </div>
</template>

<script>

import HomeFeed from "@/components/HomeFeed.vue";


export default {
  name: "home",
  components:{
    HomeFeed
  }
 
};
</script>

<style>

.home{
  background-color: rgba(0, 0, 0, 0.5);
  width: 80%;
  margin: auto;
}
</style>