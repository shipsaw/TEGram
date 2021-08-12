<template>
  <div>
    <h1>{{ this.$store.state.user.username }}'s Favorite Photos</h1>
    <div class="big-parent">
      <div 
        class="parent"
        v-for="pic in favoritesList"
        v-bind:key="pic.url">
        <div id="grid-tile">
          <img @click="sharePhotoId(pic.photoId)" :src="pic.url" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import photoService from '../services/PhotoService.js';

export default {
data(){
   return{
favoritesList:[]
   }
},

  created() {
    photoService.getPhotoFaves().then((response) => {
      this.favoritesList = response.data;
    });
  },
methods:{

 sharePhotoId(id) {
      this.$router.push({ name: "full-details", params: { data: id } });
    },

}

};
</script>

<style>


h1 {
  text-align: center;
  text-shadow: 2px 2px rgba(0, 0, 0, 0.4);
}

img {
  height: 100%;
  width: auto;
  margin: auto;
  overflow: hidden;
}
</style>