<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
    <v-btn>test btn</v-btn>
  </div>
</template>

<script>
import { VBtn } from 'vuetify/lib';
import { HelloWorld } from '@components';

export default {
  name: 'Home',
  components: {
    HelloWorld,
    VBtn
  }
};
</script>
