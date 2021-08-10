<template>
  <div class="container">
    <div class="large-12 medium-12 small-12 cell">
      <div class="upload">
        <!-- 
          alternate input and button options are commented out in the following few lines
          -->
        <!-- <input type="file" id="file-chooser" accept="image/*" @change="uploadFile" ref="file" />
       -->
        <!-- <br />
        <textarea
          id="target-drag-drop"
          rows="3"
          @drop.prevent="uploadFile"
          v-bind="fileDrop"
        >
        Drag and Drop</textarea> -->
        <!--
          copy Paste not currently functional -->
        <!-- <br />
        <textarea id="target-paste" @paste="uploadFile" v-bind="fileDrop">
Paste</textarea
        > -->
        <br />
        <input class="button" type="file" id="file-chooser" />
        <br />
        <!-- <button id="upload-button">Upload to S3</button> -->
        <button class="button button-upload" @click="uploadFile">
          Upload Photo
        </button>
        <br />
        <div class="flexy">
          <input
            type="checkbox"
            id="profile-photo"
            name="profile-photo"
            value="profilePic"
            v-model="checked"
          />
          <label class="checkbox-label" for="profile-photo">Make Profile Photo</label>
          <p>- provide square image for best experience -</p>
        </div>
        <div id="results"></div>
        <br />
        <div>
          <!--the below image tag will display the photo if it is uploaded -->
          <img id="output" />
        </div>
      </div>
    </div>
  </div>
</template>




<script src="https://sdk.amazonaws.com/js/aws-sdk-2.961.0.min.js"></script>

<script>
import photoService from '../services/PhotoService.js';

export default {
  data() {
    return {
      checked: false,
      fileDrop: null,
      newUrl: "",
    };
  },
  methods: {
    updateProfilePic(newUrl) {
      this.$store.commit('NEW_PROFILE_PICTURE', newUrl);
    },
    uploadFile() {
      let fileChooser = document.getElementById("file-chooser");
      //var button = document.getElementById("upload-button");
      let results = document.getElementById("results");
      let file = null;
      if (this.fileDrop) {
        if (this.fileDrop[i].type.match("image.*")) {
          file = this.fileDrop[0];
        }
      } else {
        if (fileChooser.files[0].type.match("image.*")) {
          file = fileChooser.files[0];
        } else {
          results.innerHTML = "Please select an Image";
        }
        //var file = fileChooser.files[0];
      }
      if (file) {
        const bucketRegion = "us-east-2";
        const userName = this.$store.state.user.username;
        const fileName = file.name;
        const photoId = this.$store.state.user.photos.length;
        const userId = this.$store.state.user.userId;
        // generate a long file name that is difficult to guess
        const length = 50;
        let randomString = "";
        const characters =
          "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const charactersLength = characters.length;
        for (let i = 0; i < length; i++) {
          randomString += characters.charAt(
            Math.floor(Math.random() * charactersLength)
          );
        }

        const photoKey =
          userName + "/" + photoId + "-" + randomString + "-" + fileName;

        AWS.config.region = "us-east-1"; // not us-east-2 ???

        AWS.config.credentials = new AWS.CognitoIdentityCredentials({
          IdentityPoolId: "us-east-1:eb060943-1a5a-45a8-b66c-a8245dc242e7",
        });

        AWS.config.credentials.get(function (err) {
          if (err) alert(err);
          console.log(AWS.config.credentials);
        });

        const bucketName = "tegramphotobucket";
        const bucket = new AWS.S3({
          params: {
            Bucket: bucketName,
          },
        });

        if (file) {
          results.innerHTML = "";
          var params = {
            Key: photoKey,
            ContentType: file.type,
            Body: file,
            ACL: "public-read",
          };
          bucket.putObject(params, function (err, data) {
            if (err) {
              results.innerHTML = "ERROR: " + err;
            } else {
              // display uploaded photo
              output.src = URL.createObjectURL(file);
              // generate the upload URL for the photo
              const uploadURL = "https://" + bucketName + ".s3." + bucketRegion + ".amazonaws.com/" + photoKey;
              console.log("Upload URL: " + uploadURL);
              // update database with photo URL and whether checked is true or
              let profileCheckBox = document.getElementById("profile-photo");
              // update the profile photo scenario
              if (profileCheckBox.checked) {
                photoService.addProfilePhoto(uploadURL, userId).then(response => {
                  if (true)  //change later maybe
                  {
                    this.newUrl = uploadURL;
                    updateProfilePic(this.newUrl);
                    console.log("Database updated! Added Photo to Profile");
                  }
                }).catch(error => {
                  if(error.response){
                    console.log("Error updating database for new profile photo. Response:" + error.response.statusText);
                  } else if (error.request){
                    console.log("Error contacting the server:" + error.request.statusText);
                  } else {
                    console.log("ERROR");
                  }
                });               
              } 
              // update the photo gallery scenario
              else {
                photoService.addGalleryPhoto(uploadURL).then(response => {
                  if (true)  //change later maybe
                  {
                    console.log("Database updated! Added Photo to Gallery");
                  }
                }).catch(error => {
                  if(error.response){
                    console.log("Error updating database for new photo. Response:" + error.response.statusText);
                  } else if (error.request){
                    console.log("Error contacting the server:" + error.request.statusText);
                  } else {
                    console.log("ERROR");
                  }
                });                               
              }
            }
          });
        } else {
          results.innerHTML = "Nothing to upload.";
        }
      }
    },
  },
};
</script>

<style>

.output {
  max-width: 1000px;
}

.upload {
  display: grid;
  margin-left: 15%;
  margin-right: 15%;
}

.flexy {
  display: inline-block;
}

.target-drag-drop {
  height: auto;
}

.button {
  width: 225px;
  background-image: linear-gradient(yellow, orange);
  opacity: 0.8;
  border-radius: 2px;
}

.button:hover {
  background-image: linear-gradient(yellow, orange, orange);
}

label {
  margin: 3px;
}

input[type="checkbox"] {
  margin-right: 5px;
}

.button-upload {
  background-image: linear-gradient(to right, orange, yellow, yellow, yellow, green);
}

.button-upload:hover {
  background-image: linear-gradient(to right, orange, yellow, green);
}

.checkbox-label {
  font: large;
}

.checkbox-label:hover {
  color: green;
}

</style>