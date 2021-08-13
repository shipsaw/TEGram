<template>
  <div class="photo-details">
    <div class="photo-url">
      <img @click="shareUserId(currentPhoto.userId)" :src="currentPhoto.url" />
    </div>

    <div class="comments">


      <div
        v-for="comment in commentsList"
        v-bind:key="comment.commentId"
      >
        
          {{ comment.username }} :
            {{ comment.content }}
     

        <hr />
      </div>
    </div>

    <div>
      <form v-on:submit.prevent class="commentForm">
        <p style="white-space: pre-line"></p>
        <br />
        <textarea
          v-model="content"
          class="commentBox"
          placeholder="Add a comment..."
        ></textarea>
        <div>
          <button
            v-on:click="submitForm()"
            type="submit"
            class="btn btn-success"
          >
            Submit Comment
          </button>

              <button
            v-on:click="deletePhoto(currentPhoto.photoId)"
            type="submit"
            class="btn btn-danger"
            v-show="isMyPhoto"
          >
            Delete This Photo
          </button>
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
      photoList: [],
      commentsList: [],
      content: "",
    };
  },
  name: "full-details",
  computed: {
    isMyPhoto: function () {
      return this.$store.state.user.userId == this.currentPhoto.userId;
    }
  },

  methods: {
    getCurrentPhoto() {
      photoService.getPhotoById(this.photoIdNumber).then((response) => {
        this.currentPhoto = response.data;
      });
    },

    submitForm() {
      let id = this.photoIdNumber;
      photoService.addNewComment(this.content, id).then((response) => {
        if (response.status === 200) {
          // this.currentPhoto.comments.push(this.content)
          //push to home
          this.$router.go();
        }
      });
    },

    shareUserId(id) {
      this.$router.push({ name: "friends-gallery", params: { data: id } });
    },

    deletePhoto(id) {
      photoService.deletePhoto(id).then((response) => {
        if (response.status === 200) {
          this.$router.push({ name: "home" });
        }
      });
    },
    loadComments(){
      this.photoList.forEach(pic => {
        if(pic.photoId === this.photoIdNumber){
         this.commentsList = pic.comments;
        }
      });
    }
  },

  created() {
    this.photoIdNumber = this.$route.params.data;
    this.getCurrentPhoto();

    photoService.getPhotos().then((response) => {
      this.photoList = response.data;

      this.loadComments();
    });
  },
};
</script>

<style>

.btn{
  margin-right: 10px;
   background-image: linear-gradient(to bottom right, orange, brown);
}
.btn:hover{
   background-image: linear-gradient(to bottom right, orange, orange, brown);
  
}
.app {
     overflow: auto;
}
.photo-details {
  display: flex;
  flex-direction: column;
  align-items: center;
  height: 100%;
  min-height: 100vh;
}
.photo-url {
  height: 400px;

  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
  margin-top: 60px;
}
.comments {
  background-color: rgb(255, 255, 250);
  border-radius: 2%;
  padding: 20px;
  border: 2px solid black;
  margin-top: 70px;
  width: 500px;
}

.commentBox {
  width: 500px;
  height: 100px;
  margin-bottom: 15px;
  
}

</style>

