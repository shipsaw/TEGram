<template>


<div class="card" > 

<!-- //grab sample of pics and v-for through to render -->
<!-- 
<div class="picCard" v-for="pic in picFeed" v-bind:key="pic.id">
{{pic.url}}
{{pic.comments}}
 <i class="fa fa-dribbble fa-4x"></i>
</div> -->




    <img src="@/images/logo.png" alt="">
    <img src="@/images/cat0.png" alt="">
    <img src="@/images/cutekitten.png" alt="">
      <img src="@/images/cat0.png" alt="">
    <img src="@/images/cutekitten.png" alt="">
      <img src="@/images/cat0.png" alt="">
    <img src="@/images/cutekitten.png" alt="">
    <div>caption goes here-ish</div> 
    
</div>
  <!-- in feed: pic, who posted it, first two comments
  like icon, add to favorites icon -->
</template>

<script>
export default {
 name: 'pics-list',
  props: ['pics']
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



