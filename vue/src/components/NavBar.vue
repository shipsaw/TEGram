<template>
  <div>
    <nav class="nav-div">
      
      <img src="@/images/logo.png" class="logo-pic" />

      <b-container >
        <b-dropdown class="dropdown">
          <b-dropdown-item>My Profile</b-dropdown-item>
          <b-dropdown-item>My Favorites</b-dropdown-item>
        </b-dropdown>
      </b-container>

      
    </nav>
  </div>
</template>
<script>
import imgService from "../services/PhotoService";

export default {

data(){
  return {
    User: {
      id: 0,
      username:"",
    }
}
},

  created() {
    imgService.get(this.id).then((response) => {
      this.User = response.data
    });
  }

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
  background-color: black;
  opacity: 0.6;
  height: 120px;
  width: 100%;
}

.dropdown {
  height: 100px;
  width: 100px;
  padding: 10px;
  float: right;
}

.logo-pic {
  border-radius: 90%;
  height: 150px;
  width: 150px;
  padding: 25px;
  margin-left: 100px;
}
</style>