<template>
  <div class="container">
    <div class="large-12 medium-12 small-12 cell">
      <div class="upload">
        <!-- alternate input and button options are commented out in the following few lines-->
        <!-- <input type="file" id="file-chooser" accept="image/*" @change="uploadFile" ref="file" />
       -->
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
          <label for="profile-photo">Make Profile Photo</label>
        </div>
        <div id="results"></div>
        <br />
        <div>
          <!--displays the photo if it is uploaded -->
          <img id="output" />
        </div>
      </div>
    </div>
  </div>
</template>

<style>
.upload {
  display: grid;
  margin-left: 20%;
}

.flexy {
  display: inline-block;
}

.button {
  width: 225px;
  background-image: linear-gradient(yellow, orange);
  opacity: 0.8;
  border-radius: 2px;
}

label {
  margin: 3px;
}

input[type="checkbox"] {
  margin-right: 5px;
}

.button-upload {
  background-image: linear-gradient(to right, orange, yellow, yellow, green);
}
</style>


<script src="https://sdk.amazonaws.com/js/aws-sdk-2.961.0.min.js"></script>

<script>
export default {
  data() {
    return {
      checked: "",
    };
  },
  methods: {
    uploadFile() {
      const fileChooser = document.getElementById("file-chooser");
      //var button = document.getElementById("upload-button");
      const results = document.getElementById("results");

      var file = fileChooser.files[0];

      if (file) {
        const bucketRegion = "us-east-2";
        const userName = this.$store.state.user.username;
        const fileName = file.name;
        const photoId = this.$store.state.user.photos.length;
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
              if (checked === true) {
                // TODO upload photoURL to User table in Database
              }
              else {
                // TODO upload photoURL to Photos table in Database
              }
            }
          });
        } else {
          results.innerHTML = "Nothing to upload.";
        }
      }
    },
    makeProfilePic() {
      //
    },
  },
};
</script>