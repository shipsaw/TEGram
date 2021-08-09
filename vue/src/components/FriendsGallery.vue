<template>
  <div id="background">
    <h1>'s Photo Gallery</h1>
    <div class="big-parent">
    
    </div>
  </div>
</template>

<script>
// import photoService from "@/services/PhotoService.js";
export default {
    name: 'friends-gallery',
  data() {
    return {
      userObject: {},
      userId: 0,
    };
  },

  // import user info by userId
  //make call to server to get user object -- loop thru feed and filter out pic by userId?


  created() {
    this.userId = this.$route.params.data;

    // photoService.get(this.userId).then((response) => {
    //   this.userObject = response.data;
    // });
  },
};
</script>

<style>
/* 
.gallery-grid {
  display: flex;
  background-color: lightgreen;
} */

.big-parent {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: space-between;
  margin-top: 50px;
}

#grid-tile {
  height: 200px;
  width: 200px;
  display: flex;
  background-color: white;
  border-radius: 1%;
  margin: 3px;
  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
}
img {
  height: 100%;
  width: auto;
  margin: auto;
  overflow: hidden;
}
</style>