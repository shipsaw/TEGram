<template>


<div class="card" > 


<div class="picCard" v-for="pic in photoList" v-bind:key="pic.url">

{{pic.url}}

<i class="fas fa-heart"></i>
<!-- update to see # of likes -->
<i></i>
{{pic.comments}}
</div>


</div>
  <!-- in feed: pic, who posted it, first two comments
  like icon, add to favorites icon -->
</template>

<script>

import photoService from '@/services/PhotoService.js'

export default {
 name: 'pics-list',
 data(){
   return{
     photoList: []
   }
 },


methods:{
  created(){
     photoService.getPhotos().then(response=>{
       this.photoList = response.data;
       
     })
  }


  }
}
</script>

<style>

img{
    height: auto;
    width: 100%;
    padding-top: 25px;
    padding-bottom: 25px;
}
.card{
    display: flex;
    flex-direction: column;
    align-items: center;
    margin:auto;
    height: 100%;
    width: 75%;
    margin-bottom: 50px;
    overflow-y:auto

}
</style>



