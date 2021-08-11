<template>
  <div>
    <!-- should we add a shuffle in case of spammers? -->
    
    <div class="home-div">
      <div class="loading" v-if="isLoading">
      <img src="../images/yellow2.jpg" />
    </div>
      <div v-for="pic in photoList" v-bind:key="pic.photoId">
        <photo-card v-bind:pic="pic" />
      </div>
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
      ],
      isLoading: true
  };
},

  created() {    
    photoService.getPhotos().then(response => {
      this.photoList = response.data;
      this.isLoading = false;        
    }); 
  }
};
</script>

<style>
.home-div {
  background: rgba(25, 153, 46, 0);
  height: 100vh;
  width: 80%;
  margin: auto;
  padding-top: 5px;
  padding-bottom: 5px;
  border-radius: 1%;
  overflow-y: auto;
  display: flex;
  flex-direction: column;
}

.home-div::-webkit-scrollbar {
  display: none;
}
</style>