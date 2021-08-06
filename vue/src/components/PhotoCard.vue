<template>
  <div class="card">
    <div class="picCard" v-for="pic in photoList" v-bind:key="pic.url">
      <img :src="pic.url" />
      <div class="icons">
        <b-icon
          icon="heart-fill"
          id="heart"
          title="look, it works!!!"
          @click="updateLikes($store.state.user.userId), (isLiked = false)"
        ></b-icon>
        <b-icon
          icon="star-fill"
          id="star"
          v-on:
          click="addToFavorites()"
        ></b-icon>
      </div>

      <!-- update to see # of likes -->

      {{ pic.comments }}
    </div>
  </div>
  <!-- in feed: pic, who posted it, first two comments
  like icon, add to favorites icon -->
</template>

<script>

import photoService from '@/services/PhotoService.js';

export default {
 name: 'pics-list',
 data(){
   return{
     photoList: []
     
   }
 },
  created(){
     photoService.getPhotos().then(response=>{
       this.photoList = response.data;
       
     })
  },
  methods:{
    
updateLikes(id){
  photoService.updateUserLikes(id).then(response=>{
    if(response.data){
      this.isLiked = true;
      this.classList.add('heart-red');

    }else{
      this.isLiked = false;
      this.classList.remove('heart-red');
    }
  })
}
  },
}

</script>

<style>
#heart-gray {
  color: gray;
}

#heart-red {
  color: red;
}

.icons {
  height: 55px;
  width: auto;
}

img {
  height: auto;
  width: 100%;
  padding-top: 25px;
  padding-bottom: 25px;
}

.picCard {
  display: flex;
  flex-direction: column;
}
.card {
  display: flex;
  flex-direction: column;
  margin: auto;
  height: 100%;
  width: 75%;
  margin-bottom: 50px;
  overflow-y: auto;
}
.heart,
.star {
  float: left;
  color: gray;
  height: 40px;
  width: auto;
  margin: 15px;
}
</style>



