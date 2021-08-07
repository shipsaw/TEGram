<template>
  <!-- <div>
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
  </div> -->
  <!-- <div>
        File Input:
        <br>
        <input type="file" accept="image/*" id="file-input">       
  </div> -->
  <div class="container">
    <div class="large-12 medium-12 small-12 cell">
      <label
        >File
        <input
          type="file"
          id="file"
          ref="file"
          v-on:change="handleFileUpload()"
        />
      </label>
      <button v-on:click="submitFile()">Submit</button>
    </div>
  </div>
</template>

<script>
//import photoService from "@/services/PhotoService.js";
//import axios from "axios";
//import express from "express";

export default {
  data() {
    return {
      file: "",
    };
  },
  methods: {
    handleFileUpload() {
      // will only get the first photo
      this.file = this.$refs.file.files[0];
      console.log("selected file: " + this.file.name);
    },
    submitFile() {
      const bucketName = "tegramphotobucket";
      const bucketRegion = "us-east-2";
      const userName = this.$store.state.user.username;
      const fileName = this.file.name;
      const photoId = this.$store.state.user.photos.length;
      const photoKey = userName + "/" + photoId + "-" + fileName;
      const uploadURL =
        "https://" +
        bucketName +
        ".s3." +
        bucketRegion +
        ".amazonaws.com/" +
        photoKey;
      console.log(uploadURL);
      // let options = {
      //   headers: {
      //     "Content-Type": "multipart/form-data",
      //   }
      // }
      // let file = this.file;
      // let formData = new FormData();

      // const AWS = require("aws-sdk");

      // const s3 = new AWS.S3({
      //   accessKeyId: "AKIA47LN56X3N4QKKMAE",
      //   secretAccessKey: "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",
      // });

      
    }
  }
};
</script>