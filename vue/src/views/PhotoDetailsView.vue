<template>
  <photo-details v-bind:photoId="parseInt($route.params.pic.photoId)"/>
</template>

<script>
import PhotoDetails from "@/components/PhotoDetails.vue"
export default {
    components: {
        PhotoDetails
    }

}
</script>

<style>

</style>