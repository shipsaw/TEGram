<template>
  <div id="app">

    
    <div id="nav">

     <nav-bar/>
      <router-view />
    </div>
  </div>
</template>

<script>
import NavBar from "@/components/NavBar.vue";

export default {
  components: {
    NavBar
  }
}
 </script>


<style>

#app{ 
  background-image:url("images/yellow.jpg"), url("images/yellow2.jpg");
    background-size: cover;
    height: 100%;
    padding-bottom: 50px;
}
</style>