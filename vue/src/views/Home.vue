<template>
  <div class="home">
    <h2>Welcome, {{ this.$store.state.user.username }}!</h2>
    <h4>See what's new: </h4>
    
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
h2, h4{
  color: white;
  text-align: center;
  text-shadow: 2px 2px rgba(0, 0, 0, 0.4) ;
}

h2{
  padding: 15px;
}

.home{
  background: rgba(25, 153, 46, 0.25);
  width: 70%;
  margin: auto;
  text-align: center;
  border-radius: 1%;
  margin-top:25px;
  padding-bottom: 50px;
}
</style>