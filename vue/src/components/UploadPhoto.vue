<template>
  <div>
    <h1>Upload Photo</h1>
    File Input:
    <br />
    <input
      type="file"
      accept="image/*"
      id="file-input"
      :value="fileList"
      v-on:change="uploadFile()"
    />
  </div>
</template>

<script>
export default {
  name: "upload",
  data() {
    return {
      file,
    };
  },
  methods: {
    uploadFile(fileList) {
      // since user could input multiple files iterate through to find the first image file
      let file = null;
      for (let i = 0; i < fileList.length; i++) {
        if (fileList[i].type.match(/^image\//)) {
          file = fileList[i];
          break;
        }
      }
      if (file !== null) {
        const bucketName = "tegramphotobucket";
        const bucketRegion = "us-east-2";
        let userName = this.$store.state.user.username;
        // TODO check if photoId on the line below needs a +1 to be a unique photoId
        let photoId = this.$store.state.user.photoFeedLength;
        // TODO remove hardcoded value below
        photoId = 9001;
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
          .put(uploadURL, formData, {
            headers: {
              "Content-Type": "multipart/form-data",
            },
          })
          // just checking if it works or not
          .then(function () {
            alert("Successful Upload!");
          })
          .catch(function () {
            alert("Failure!");
          });
      }
    },
  },
};
</script>