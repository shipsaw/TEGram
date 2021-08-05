<template>
  <!-- should we add a shuffle in case of spammers? -->
  <div class="home-div">
<!-- 
       <div class="photo-list">
    <div v-for="photo in photos" v-bind:key="photo.url" class="photo">
        <img src: photos.url >
       <p>{{photos.caption}}</p> 
        {{photos.likes}}
       <p>{{photos.comments}}</p> 
    </div> -->



<photo-card />
  <!-- </div> -->
     
 
    
    <!--       
       use get method to loop through whole database to diaplay top 50 posts -->
  </div>
</template>

<script>
import PhotoCard from "@/components/PhotoCard.vue";
import photoService from "../services/PhotoService.js";

export default {
  components: {
    PhotoCard,
  },
  name:'photo-list',
  data(){
      return {
          photos: [{
              url: '',
              caption:'',
              likes: 0,
              comments: ['']
          }]
      }
  },

  created() {
      photoService.getPhotos().then((response) => {
        this.photos = response.data;
      });
    },

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
  border-radius: 1%;

  display: flex;

}
</style>