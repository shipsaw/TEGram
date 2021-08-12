<template>
  <div class="inter">
    <!-- should we add a shuffle in case of spammers? -->
    <div class="home-div">
      <h2>Welcome, {{ this.$store.state.user.username }}!</h2>
      <h3>See what's new:</h3>
      <div class="loading" v-if="isLoading">
        <img class="load-image" src="../images/matrix.gif" />
      </div>
      <div v-for="pic in photoList" v-bind:key="pic.photoId" class="feedItem">
        <photo-card v-bind:pic="pic" />
      </div>
    </div>
  </div>
</template>

<script>
import PhotoCard from "@/components/PhotoCard.vue";
import photoService from "@/services/PhotoService.js";

export default {
  components: {
    PhotoCard,
  },
  name: "photo-list",
  data() {
    return {
      photoList: [],
      isLoading: true,
    };
  },

  created() {
    photoService.getPhotos().then((response) => {
      this.photoList = response.data;
      this.isLoading = false;
    });
  },
};
</script>

<style>
.home-div {
  background: rgba(25, 153, 46, 0);
  height: 100vh;
  width: 100%;
  margin: auto;
  padding-top: 5px;
  padding-bottom: 5px;
  border-radius: 1%;
  overflow-y: auto;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.home-div::-webkit-scrollbar {
  display: none;
}

.load-image {
  border-radius: 15px;
}

@media only screen and (max-width: 768px) {
  .feedItem {
    width: 100%;
    display: flex;
    align-content: center;
  }
}

@media only screen and (min-width: 769px) {
  .feedItem {
    width: 35%;
  }
}

h2,
h3 {
  color: white;
  text-align: center;
  text-shadow: 2px 2px rgba(0, 0, 0, 0.4);
}
</style>