<template>
  <div class="card">
    <div class="picCard" v-for="pic in photoList" v-bind:key="pic" :class="{aciveclass: !pic.isLiked}">
      <div class="polaroid">

        <img class="photo-single" :src="pic.url"/> 
<!--          
         call click listener method that takes photo id and uses it to route to a new window -->
          
        <div class="icons">
          <b-icon
            icon="heart-fill"
            title="like photo"
            @click="updateLikes(pic.PhotoId)"
     
            class="heartGray"
            :class="isLiked ? 'heartRed' : 'heartGray'"
          ></b-icon>
          <b-icon
            icon="star-fill"
            title="add to favorites"
            @click="addToFavorites()"
            class="starGray"
            :class="isFavorited ? 'starYellow' : 'starGray'"
          ></b-icon>
       </div>
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
  name: "pics-list",
  data() {
    return {
      photoList: [],
      // isLiked: false,
      isFavorited: false,
    };
  },

  created() {
    photoService.getPhotos().then((response) => {
      this.photoList = response.data;
    });
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
  },
};
</script>

<style>

.polaroid{
  height: 100%;
  margin-top:5px;
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
  margin-top:5px;
  
}

.photo-single {
  height: auto;
  width:100%;
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
  overflow-y: auto;
}
.card::-webkit-scrollbar {
  display: none;
}
</style>



