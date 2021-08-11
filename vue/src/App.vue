<template>
  <div class="app">

    
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

img{
opacity: 1;
}
img:hover{
  opacity: 0.7;
}

.app{ 
  background-image:url("images/yellow.jpg"), url("images/yellow2.jpg");
  height: 950px;
  padding-bottom: 50px;
  opacity: .9;
}

</style>