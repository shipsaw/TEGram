<template>
  <!-- should we add a shuffle in case of spammers? -->
  <div class = "home-div">
      <photo-card/>
<!--       
       use get method to loop through whole database to diaplay top 50 posts -->

  </div>
</template>

<script>
import PhotoCard from "@/components/PhotoCard.vue";


export default {

    components:{
        PhotoCard
    }
};
</script>

<style>
.home-div { 
    
background: rgba(255, 255, 255, 255);
height: 900px;
width: 75%;
margin: auto;
padding-top: 50px;
padding-bottom: 50px;
}

</style>