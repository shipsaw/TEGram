<template>
  <div class="card">
    <div class="polaroid">
      <img
        @click="sharePhotoId(pic.photoId)"
        class="photo-single"
        :src="pic.url"
      />

      <div class="icons">
        <div class="heart-components">
          <b-icon
            id="heartIcon"
            icon="heart-fill"
            title="like photo"
            class="heartGray"
            @mousedown="updateLikes(pic.photoId)"
            :class="isLiked ? 'heartRed' : 'heartGray'"
          ></b-icon>
          {{ likesNumber }}
        </div>
        <b-icon
          icon="star-fill"
          title="add to favorites"
          @mousedown="updateFavorites(pic.photoId)"
          class="starGray"
          :class="isFavorited ? 'starYellow' : 'starGray'"
        ></b-icon>
      </div>

      <div class="likesBar">
        <div
          class="comment-section"
          v-for="c in displayComments"
          :key="c.commentID"
        >
          {{ c.username }} :
          {{ c.content }}
          <hr />
        </div>
      </div>
    </div>

    <!-- display first two comments from comment object inside photo obj -->
  </div>
  <!-- in feed: pic, who posted it, first two comments -->
</template>

<script>
import photoService from "@/services/PhotoService.js";

export default {
  name: "photo-card",
  props: {
    pic: Object,
  },
  data() {
    return {
      isLiked: false,
      isFavorited: false,
      likesNumber: Number,
    };
  },
  //target only the last two comments
  //if last comment is not null, push it to comment array

  computed: {
    displayComments() {
      let commentArray = [];

      if (this.pic.comments != [] && this.pic.comments.length >= 1) {
        commentArray.push(this.pic.comments[this.pic.comments.length - 1]);
        // commentArray.push(this.pic.comments[this.pic.comments.length - 1].content);
      }

      if (this.pic.comments != [] && this.pic.comments.length >= 2) {
        commentArray.push(this.pic.comments[this.pic.comments.length - 2]);
        // commentArray.push(this.pic.comments[this.pic.comments.length - 2].content);
      }

      return commentArray;
    },
  },

  methods: {
    sharePhotoId(id) {
      this.$router.push({ name: "full-details", params: { data: id } });
    },

    updateLikes(id) {
      if (this.$store.state.user.userId != undefined) {
        photoService.updateUserLikes(id).then((response) => {
          if (response.data) {
            this.isLiked = true;
            this.likesNumber += 1;
          } else {
            this.isLiked = false;
            this.likesNumber -= 1;
          }
        });
      }
    },

    updateFavorites(id) {
      if (this.$store.state.user.userId != undefined) {
        photoService.updateUserFavorites(id).then((response) => {
          if (response.data) {
            this.isFavorited = true;
          } else {
            this.isFavorited = false;
          }
        });
      }
    },
  },
  mounted() {
    if (this.pic.likes.includes(this.$store.state.user.userId)) {
      this.isLiked = true;
    } else {
      this.isLiked = false;
    }

    if (this.pic.favorites.includes(this.$store.state.user.userId)) {
      this.isFavorited = true;
    } else {
      this.isFavorited = false;
    }
    this.likesNumber = this.pic.likes.length;
  },
};
</script>

<style>
.comment-section {
  font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
    "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
  font-weight: 500;
  /* background-color: rgba(46, 59, 47, 0.055);  */
  margin-bottom: 5px;
  margin-top: 5px;
  margin-left: 5px;
  text-align: left;
}

.polaroid {
  height: 100%;
  margin: -1px -1px -1px -1px;
}

.heartGray {
  color: rgb(240, 224, 224);
  float: left;
  height: 30px;
  width: auto;
  margin: 10px;
}

.heart-components {
  font-size: 33px;
  font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
    "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
}
.starGray {
  color: rgb(240, 224, 224);
  float: left;
  height: 30px;
  width: auto;
  margin: 10px;
}

@media only screen and (min-width: 769px) {
  .starGray:hover,
  .heartGray:hover {
    color: pink;
  }
  .heartRed:hover {
    color: gold;
  }
}

.heartRed {
  color: gold;
}

.starYellow {
  color: yellow;
}

.starYellow:hover {
  color: yellow;
}

.icons {
  border-top: 2px solid gray;
  background-image: linear-gradient(to bottom right, orange, brown);
  height: 55px;
  margin-top: 5px;
  border-radius: 5px;
  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
  display: flex;
  justify-content: space-between;
}

.photo-single {
  height: auto;
  width: 100%;
  /* max-width: 850px; */
  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
}

.picCard {
  border: 2px solid gray;
}
.card {
  /* display: flex;
  flex-direction: column; */
  height: 0%;
  width: 100%;
  margin-top: 40px;
}

.likesBar {
  /* display:block; */
  margin-top: 5px;
  display: flex;
  flex-direction: column;
  text-align: start;
  font-family: "Arial Narrow", Arial, sans-serif;
  background-color: whitesmoke;
  border-radius: 6px;
  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
}

img {
  border-radius: 1%;
}
</style>



