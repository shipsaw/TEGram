<template>
  <!-- should we add a shuffle in case of spammers? -->
  <div class="home-div" >
    <div v-for="pic in photoList" v-bind:key="pic.photoId">
      <photo-card v-bind:pic="pic" />
    </div>

  </div>
</template>

<script>
import PhotoCard from "@/components/PhotoCard.vue";
import photoService from "@/services/PhotoService.js";

export default {
  components: {
    PhotoCard,
  },
  name:'photo-list',
data(){
  return{
     photoList: [
      ]
  }
},


  created() {
    photoService.getPhotos().then((response) => {
      this.photoList = response.data;
    });
  },
};
</script>

<style>
.home-div {
  background: rgba(25, 153, 46, 0);
  height: 910px;
  width: 80%;
  margin: auto;
  padding-top: 50px;
  padding-bottom: 50px;
  border-radius: 1%;
  overflow-y: auto;
  display: flex;
  flex-direction: column;
}

.home-div::-webkit-scrollbar {
  display: none;
} 
</style>