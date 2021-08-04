<template>
  <div class="home">
    <h1>Welcome! {{ this.$store.state.user.username }}</h1>
    
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
text-align: center;

}

h1{
  padding: 15px;

}
</style>