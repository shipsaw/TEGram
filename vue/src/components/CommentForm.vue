<template>
 <form action="http://localhost:44315/api/Photo/comment" method="POST">> <!-- Need axios? Check what the endpoint will be. -->
    <div>
        <p style="white-space: pre-line;">{{ message }}</p>
        <br>
        <textarea v-model="comment" placeholder="Add a comment..."></textarea> <!-- Does this have to bind to Photo.Comments?-->
    <div>
        <button type="submit" class="btn btn-success">Submit</button>
    </div>
    </div>
 </form>
</template>

<script>
export default {
   data() {
     return{
       comment: "",
    };
  }
}
</script>

<style>

</style>
