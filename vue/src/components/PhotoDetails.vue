<template>
  <div class="photo-details">
    <img class="photo-url" :src="currentPhoto.url" />

    <div class="comment-section" v-for="comment in currentPhoto.comments" v-bind:key="comment.commentId">
<router-link v-bind:to="{name:'pic-feed'}">{{comment.username}} </router-link>
    {{ comment.content }}

    </div>



    <!-- figure out how to display username -->

    <div>
      <form
        action="https://capstonetegram.azurewebsites.net/api/photo/comments"
        method="POST"
      >
        >
        <p style="white-space: pre-line"></p>
        <br />
        <textarea v-model="comment" placeholder="Add a comment..."></textarea>
        <div>
          <button type="submit" class="btn btn-success">Submit</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import photoService from "../services/PhotoService.js";
export default {
  data() {
    return {
      photoIdNumber: 0,
      currentPhoto: {},
      comment: "",
    };
  },
  name: "full-details",

  methods: {
    getCurrentPhoto() {
      photoService.getPhotoById(this.photoIdNumber).then((response) => {
        this.currentPhoto = response.data;
      });
    },
  },

  created() {
    this.photoIdNumber = this.$route.params.data;
    this.getCurrentPhoto();
  },
};
</script>

<style>
</style>

<!--this.$router.push({ name: "user", params: { username: "dan" } });
this.$router.push({ path: "register", query: { plan: "private" } });

we may have to use the photoId to make a get request to the database-->