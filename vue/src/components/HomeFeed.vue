<template>
  <!-- should we add a shuffle in case of spammers? -->
  <div class="home-div">
<photo-card />
  </div>
</template>

<script>
import PhotoCard from "@/components/PhotoCard.vue";

export default {
  components: {
    PhotoCard,
  },
  name:'photo-list',

};
</script>

<style>
.home-div {
  background: rgba(25, 153, 46, 0);
  height: 910px;
  width: 80%;
  margin: auto;
  padding-top: 50px;
  padding-bottom: 50px;
  border-radius: 1%;

  display: flex;

}
</style>