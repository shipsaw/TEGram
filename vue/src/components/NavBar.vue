<template>

 <div >
<nav class="nav-div">
  <img src="@/images/logo.png" class="logo-pic">



<!-- todo replace extra logo with call to user profile pic-->

<div class="dropdown">
  <a class="btn btn-secondary dropdown-toggle" type="image"  id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">

    <img v-bind:to="{name:'picById'} " :src="profileURL" class="profile-pic"> 
  </a>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <a class="dropdown-item" href="#">Action</a>
    <a class="dropdown-item" href="#">Another action</a>
    <a class="dropdown-item" href="#">Something else here</a>
  </div>

  
</div>
  </nav>
 </div> <!-- can we make this button the proilfe pic? -->
</template>
<script>
import imgService from '@/services/PhotoService.js';

export default {



created(){
  imgService.get().then(response=>{
    this.$store.commit('SET_PIC', response.data);
  })
},

computed:{
  profileURL(){
    return this.$store.state.user.userProfileURL;
  }
}

}


</script>

<style>
.nav-div {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
    background-color: black;
    opacity: .6; 

    height: 120px;
    width: 100%;
        
}


.profile-pic {
   border-radius: 90%;
   height: 100px;
   width: 100px;
   padding: 25px;
  }

.logo-pic{
  border-radius: 90%;
     height: 100px;
   width: 100px;
      padding: 25px;
}
</style>