<template>


<div class="card" > 


<div class="picCard" v-for="pic in " v-bind:key="pic.id">
{{pic.url}}
{{pic.comments}}
 <i class="fa fa-dribbble fa-4x"></i>
</div>


</div>
  <!-- in feed: pic, who posted it, first two comments
  like icon, add to favorites icon -->
</template>

<script>

import photoService from '@/services/PhotoService.js'

export default {
 name: 'pics-list',
  props: ['pics'],


methods:{
  retrieveFeed(){
     photoService.getPhotos().then(response=>{
       
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



