<template>
  <div class="home">
    <h1>Welcome, {{ this.$store.state.user.username }}!</h1>
    <h2>See what's new: </h2>
    
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

h1, h2{
  color: white;
  text-align: center;
  text-shadow: 2px 2px rgba(0, 0, 0, 0.4) ;
}
h1{
  padding: 15px;
}
.home{
  background: rgba(25, 153, 46, 0.25);
  width: 80%;
  margin: auto;
text-align: center;
border-radius: 1%;
 margin-top:25px;
 padding-bottom: 50px;

}


</style>