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

h1{
  color: white;
}

.home{
  background-color: rgba(0, 10, 102, 0.596);
  width: 80%;
  margin: auto;
text-align: center;
border-radius: 1%;
 margin-top:25px;

}

h1{
 
  padding: 15px;

}
</style>