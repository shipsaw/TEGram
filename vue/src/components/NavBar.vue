<template>
  <div>
    <nav class="nav-div">
      <router-link v-bind:to="{ name: 'home' }" >  <img src="@/images/logo.png" class="logo-pic" />   </router-link>&nbsp;&nbsp;
      

      <b-container >
        <b-dropdown class="dropdown ">
          <b-dropdown-item>  <router-link v-bind:to="{name: 'user-gallery'}">My Profile Gallery</router-link>     </b-dropdown-item>
          <b-dropdown-item>  <router-link v-bind:to="{name: 'user-faves'}">My Favorites</router-link></b-dropdown-item>
        <b-dd-divider></b-dd-divider>
          <b-dropdown-item>  <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link></b-dropdown-item>

        </b-dropdown>
      </b-container>
    </nav>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },

  // computed: {
  //   profileURL() {
  //     return this.$store.state.user.userProfileUrl;
  //   },
  // },
};
</script>

<style>
.nav-div {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  background: rgba(25, 153, 46, 0.25);
  height: 120px;
  width: 100%;
}

.dropdown {
  height: 100px;
  width: 100px;
  padding: 10px;
  float: right;
   width:190px;
    display:flex;
    flex-direction:row;
    justify-content:center;
    align-items:center;
}

.logo-pic {
  border-radius: 90%;
  height: 150px;
  width: 150px;
  padding: 25px;
  margin-left: 70px;
  
 
}
</style>