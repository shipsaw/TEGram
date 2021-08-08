<template>
  <div class="photo-details">
  <img class="photo-single" :src="pic.url" />
{{pic.comments}}
{{pic.userId}}
 <!-- figure out how to display username -->
 <!-- do we want this bootstrap comment form  -->
<b-container fluid>
  <b-row>
    <b-col sm="2">
      <label for="textarea-small">Small:</label>
    </b-col>
    <b-col sm="10">
      <b-form-textarea
        id="textarea-small"
        size="sm"
        placeholder="Small textarea"
      ></b-form-textarea>
    </b-col>
  </b-row>
    <b-col lg="4" class="pb-2"><b-button type="submit" size="sm" variant="outline-warning">Small Button</b-button></b-col>
</b-container> 

<div>
 <form action="https://capstonetegram.azurewebsites.net/api/photo/comments" method="POST">>
        <p style="white-space: pre-line;">{{ message }}</p>
        <br>
        <textarea v-model="comment" placeholder="Add a comment..."></textarea> 
    <div>
        <button type="submit" class="btn btn-success">Submit</button>
    </div>
     </form>
    </div>



  </div>
</template>

<script>
export default {
 
  data() {
    return{
    comment: "",
    }
  },
 name: "photo-details", 
 props: {
    pic: Object,    
  },
}
</script>

<style>

</style>

<!--this.$router.push({ name: "user", params: { username: "dan" } });
this.$router.push({ path: "register", query: { plan: "private" } });-->