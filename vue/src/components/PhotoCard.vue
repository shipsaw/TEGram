<template>
  <div class="card">
    <div class="polaroid">

      <router-link v-bind:to="{name: 'full-details', params: {id: pic.photoId}}">
      <img class="photo-single" :src="pic.url" />
</router-link >
      <div class="icons">
        <b-icon
        id="heartIcon"
          icon="heart-fill"
          title="like photo"
             class="heartGray"
          @click="updateLikes(pic.photoId)"
        
          :class="isLiked ? 'heartRed' : 'heartGray'"
        ></b-icon>
        <b-icon
          icon="star-fill"
          title="add to favorites"
          @click="updateFavorites(pic.photoId)"
          class="starGray"
          :class="isFavorited ? 'starYellow' : 'starGray'"
        ></b-icon>
      </div>

      <!-- update to see # of likes -->

      {{ pic.comments }}
    </div>
  </div>
  <!-- in feed: pic, who posted it, first two comments -->
</template>

<script>
import photoService from "@/services/PhotoService.js";

export default {
  name: "photo-card",
  props: {
    pic: Object,    
  },
  data() {
   return {
     isLiked: false,
     isFavorited: false
   }
  },

  methods: {

    updateLikes(id) {
      photoService.updateUserLikes(id).then((response) => {
        if (response.data) {
          this.isLiked = true;
        } else {
          this.isLiked = false;
        }
      });
    },
  

  updateFavorites(id) {
    photoService.updateUserFavorites(id).then((response) => {
      if (response.data) {
        this.isFavorited = true;
      } else {
        this.isFavorited = false;
      }
    });
  },


},
mounted(){
  
    if(this.pic.likes.includes(this.$store.state.user.userId)){
    this.isLiked = true;
    }
    else{
       this.isLiked = false;
    }
    
    if(this.pic.favorites.includes(this.$store.state.user.userId)){
      this.isFavorited = true;
    }
    else{
     this.isFavorited = false;
    }
  
}
};
</script>

<style>
.polaroid {
  height: 100%;
  margin-top: 5px;
}

.heartGray,
.starGray {
  color: gray;
  float: left;
  height: 30px;
  width: auto;
  margin: 10px;
}

.heartRed {
  color: gold;
}
.starYellow {
  color: yellow;
}

.icons {
  border-top: 2px solid gray;
  background-image: linear-gradient(to bottom right, lightgray, gray);
  height: 55px;
  margin-top: 5px;
}

.photo-single {
  height: auto;
  width: 100%;
  max-width: 650px;
  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
}

.picCard {
  width: 100%;
  border: 2px solid gray;
}
.card {
  display: flex;
  flex-direction: column;
  margin: auto;
  height: 100%;
  width: 95%;
  margin-bottom: 40px;
}

</style>



