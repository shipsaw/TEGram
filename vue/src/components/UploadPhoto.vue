<template>
  <div>
    <h1>Upload Photo</h1>
    File Input:
    <br />
    <input
      type="file"
      accept="image/*"
      id="fileInput"
      v-bind:value="fileList"
      v-on:change="uploadFile()"
    />
    <input
      type="checkbox"
      id="photoInputSelection"
      name="profilepic"
      v-bind:value="isProfilePhoto"
    />
    <label for="profilepic">Make Profile Pic</label>
  </div>
</template>

<script>
//import photoService from "@/services/PhotoService.js";
import axios from "axios";

export default {
  data() {
  },
  methods: {
    uploadFile(fileList, isProfilePhoto) {
      // since user could input multiple files iterate through to find the first image file
      let file = null;
      for (let i = 0; i < fileList.length; i++) {
        // check if the file is an image
        if (fileList[i].type.match("image.*")) {
          file = fileList[i];
          break;
        }
      }
      if (file !== null) {
        if (isProfilePhoto) {
          this.uploadProfilePhoto(file);
        } else {
          this.uploadUserPhoto(file);
        }
      }
    },
    uploadProfilePhoto(file) {
      const bucketName = "tegramprofilephotobucket";
      const bucketRegion = "us-east-2";
      const userName = this.$store.state.user.username;
      const fileName = file.name;
      // profile photo name only needs to include userName to be unique since there is only one active profile photo per user
      const photoKey = userName + "/" + fileName;
      const uploadURL =
        "https://" +
        bucketName +
        ".s3." +
        bucketRegion +
        ".amazonaws.com/" +
        photoKey;
      axios
        .put(uploadURL, file, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then(function (result) {
          // TO DO upload profile photo to database
          console.log(result);
          alert("Successful Profile Photo Upload to AWS!");
        })
        .catch(function (error) {
          console.log(error);
          alert("Failure to Upload Profile Photo to AWS!");
        });
    },
    uploadUserPhoto(file) {
      const bucketName = "tegramphotobucket";
      const bucketRegion = "us-east-2";
      const userName = this.$store.state.user.username;
      const photoId = this.$store.state.user.photos.length;
      const fileName = file.name;
      // unique photo name to upload to S3 bucket
      const photoKey = userName + "/" + photoId + "-" + fileName;
      const uploadURL =
        "https://" +
        bucketName +
        ".s3." +
        bucketRegion +
        ".amazonaws.com/" +
        photoKey;
      axios
        .put(uploadURL, file, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then(function (result) {
          // TO DO upload photo to database
          console.log(result);
          alert("Successful User Photo Upload to AWS!");
        })
        .catch(function (error) {
          console.log(error);
          alert("Failure to Upload User Photo to AWS!");
        });
    },
  },
};
</script>