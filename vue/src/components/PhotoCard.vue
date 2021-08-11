<template>
  <div class="card">
    <div class="polaroid">
      <img
        @click="sharePhotoId(pic.photoId)"
        class="photo-single"
        :src="pic.url"
      />

      <div class="icons">
        <b-icon
          id="heartIcon"
          icon="heart-fill"
          title="like photo"
          class="heartGray"
          @click="updateLikes(pic.photoId)"
          :class="isLiked ? 'heartRed' : 'heartGray'"
        ></b-icon>
        <b-icon
          icon="star-fill"
          title="add to favorites"
          @click="updateFavorites(pic.photoId)"
          class="starGray"
          :class="isFavorited ? 'starYellow' : 'starGray'"
        ></b-icon>
      </div>
      <div class="likesBar">
        Likes: {{likesNumber}}
      </div>
      comments
<div class="comment-section" v-for="c in displayComments" :key="c.username">
         {{c.username}} : 
      {{ c.content }}
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
         commentArray.push(this.pic.comments[this.pic.comments.length - 1])
        // commentArray.push(this.pic.comments[this.pic.comments.length - 1].content);
       
      }

      if (this.pic.comments != [] && this.pic.comments.length >= 2) {
         commentArray.push(this.pic.comments[this.pic.comments.length - 2])
        // commentArray.push(this.pic.comments[this.pic.comments.length - 2].content);
      }

      return commentArray;
    }
  },

  methods: {
    sharePhotoId(id) {
      this.$router.push({ name: "full-details", params: { data: id } });
    },

    updateLikes(id) {
      photoService.updateUserLikes(id).then((response) => {
        if (response.data) {
          this.isLiked = true;
          this.likesNumber += 1;
        } else {
          this.isLiked = false;
          this.likesNumber -= 1;
        }
      });
    },

    updateFavorites(id) {
      photoService.updateUserFavorites(id).then((response) => {
        if (response.data) {
          this.isFavorited = true;
        } else {
          this.isFavorited = false;
        }
      });
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
    this.likesNumber = this.pic.likes.length
  },
};
</script>

<style>

.comment-section{
 font-family:'Arial Narrow', Arial, sans-serif;
 background-color: rgba(46, 59, 47, 0.055); 
 margin-bottom: 5px; 
 margin-top: 5px;
 border-bottom: 2px solid gray;
 text-align:left;
}

.polaroid {
  height: 100%;
}

.heartGray,
.starGray {
  color: gray;
  float: left;
  height: 30px;
  width: auto;
  margin: 10px;
}

.starGray:hover,
.heartGray:hover {
  color: pink;
}

.heartRed {
  color: gold;
}

.heartRed:hover {
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
  background-image: linear-gradient(to bottom right, lightgray, gray);
  height: 55px;
  margin-top: 5px;
}

.photo-single {
  height: auto;
  width: 80%;
  margin-left: 5px;
  margin-right: 5px;
  max-width: 650px;
  box-shadow: 3px 3px rgba(0, 0, 0, 0.4);
}

.picCard {
  width: 100%;
  border: 2px solid gray;
}
.card {
  display: flex;
  flex-direction: column;
  margin: auto;
  height: 100%;
  width: 80%;
  margin-bottom: 40px;
}

.likesBar{
  display:block;
  text-align: start;
  margin-left: 5px;
  font-family:'Arial Narrow', Arial, sans-serif;
}
</style>



