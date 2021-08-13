<template>
  <div>
    <nav class="nav-div">
      <router-link v-bind:to="{ name: 'pic-feed' }">
        <img src="@/images/logo.png" class="logo-pic" /> </router-link
      >&nbsp;&nbsp;
      <!-- user's profile photo -->
      <router-link
        v-bind:to="{
          name: this.pathOrLogin('friends-gallery'),
          params: { data: $store.state.user.userId },
        }"
      >
        <img
          v-bind:src="this.profileURL"
          class="profile-photo"
        />
      </router-link>
      <b-container>
        <b-dropdown class="dropdown">
          <b-dropdown-item id="button-style"></b-dropdown-item>
          <b-dropdown-item>
            <router-link v-bind:to="{ name: 'home' }"
              >Home</router-link
            ></b-dropdown-item
          >

          <b-dropdown-item
            ><router-link
              v-bind:to="{
                name: this.pathOrLogin('friends-gallery'),
                params: { data: $store.state.user.userId },
              }"
              >My Gallery</router-link
            >
          </b-dropdown-item>
          <b-dropdown-item>
            <router-link v-bind:to="{ name: this.pathOrLogin('user-faves') }"
              >My Favorites</router-link
            ></b-dropdown-item
          >
          <b-dropdown-item>
            <router-link v-bind:to="{ name: this.pathOrLogin('new-photo') }"
              >Add Photo</router-link
            ></b-dropdown-item
          >
          <b-dd-divider></b-dd-divider>
          <b-dropdown-item>
            <router-link
              v-bind:to="{ name: 'logout' }"
              v-if="$store.state.token != ''"
              >Logout</router-link
            ></b-dropdown-item
          >
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

  computed: {
    profileURL() {
      if(this.$store.state.user.userProfileUrl != undefined) {
      return this.$store.state.user.userProfileUrl;
      } else {
        return "https://tegramprofilephotobucket.s3.us-east-2.amazonaws.com/blankprofilephoto.png";
      }
    },
  },
  methods: {
    pathOrLogin: function(path) {
      if(this.$store.state.user.userProfileUrl != undefined) {
        return path;
      } else {
        return 'login';
      }
    }
  },
}
</script>

<style>
@media only screen and (max-width: 768px) {
  .logo-pic {
    border-radius: 90%;
    height: 150px;
    width: 150px;
    padding: 25px;
    margin-left: 0px;
  }
  .dropdown {
    height: 180px;
    width: 120px;
    padding: 10px;
    float: right;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
  }
  .container {
    display: flex;
    justify-content: center;
  }
}

@media only screen and (min-width: 769px) {
  .logo-pic {
    border-radius: 90%;
    height: 150px;
    width: 150px;
    padding: 25px;
    margin-left: 70px;
  }
  .dropdown {
    height: 100px;
    width: 100px;
    padding: 10px;
    float: right;
    width: 190px;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
  }
}

.profile-photo {
  border-radius: 50%;
  width: 100px;
  height: 100px;
}

.nav-div {
  display: flex;
  position: static;
  /* flex-direction: row; */
  /* justify-content: space-between; */
  align-items: center;
  background-color:rgba(255,255,255,0.4);
  height: 120px;
  width: 100%;
  border-bottom-style: solid;
  border-width: 4px;
  border-color: black;
}

.dropdown-toggle {
   background-image: linear-gradient(to bottom right, orange, brown);
  
}
.dropdown-toggle:hover {
  background-image: linear-gradient(to bottom right, orange, orange, brown);
  
}
</style>