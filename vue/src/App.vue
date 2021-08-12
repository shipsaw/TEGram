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
  background-size: cover;
  padding-bottom: 50px;
  /* opacity: 90%; */
  position: fixed;
  width: 100%;
  height: 100%;
}

/* for tablet */
@media only screen and (min-width: 600px) {


}

/* for desktop */
@media only screen and (min-width: 768px) {



}


</style>