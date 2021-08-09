<template>
  <div class="photo-details">
      <div class="photo-url">

    <img
      @click="shareUserId(currentPhoto.userId)"
      
      :src="currentPhoto.url"
    />

      </div>

<div class="comments">

    <div
     
      v-for="comment in currentPhoto.comments"
      v-bind:key="comment.commentId"
    >
      {{ comment.username }} : 

      {{ comment.content }}
      <hr>
    </div>

</div>


    <div>
      <form
   
        action="https://capstonetegram.azurewebsites.net/api/photo/{photoId}/comments"
        method="POST"
      >
        <!-- fix dis action link!! -->
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

    shareUserId(id) {
      this.$router.push({ name: "friends-gallery", params: { data: id } });
    },
  },

  created() {
    this.photoIdNumber = this.$route.params.data;
    this.getCurrentPhoto();
  },
};
</script>

<style>


.photo-details{
    display: flex;
    flex-direction: column;
    align-items: center;
    height: 100%;
}
.photo-url{
    height: 400px;

box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
    margin-top:60px;
    
}
.comments{
    background-color:rgb(255, 255, 250);
    border-radius: 2%;
    padding: 20px;
    border: 2px solid black;
    margin-top: 70px;
}
</style>

<!--this.$router.push({ name: "user", params: { username: "dan" } });
this.$router.push({ path: "register", query: { plan: "private" } });

we may have to use the photoId to make a get request to the database-->