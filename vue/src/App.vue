<template>
  <div id="app">
    <div id="nav">

        <nav-bar/>

      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />




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
}
</style>