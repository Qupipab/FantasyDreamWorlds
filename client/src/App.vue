<template>
  <v-app id="app" :class="$store.state.themeMode">
    <component :is="layout">
      <router-view/>
    </component>
  </v-app>
</template>

<script>
import {
  VApp
} from 'vuetify/lib';

export default {
  name: 'App',
  components: {
    VApp
  },
  computed: {
    layout () {
      return 'default-layout';
    }
  }
};
</script>

<style lang="scss">
@import "@styles/common.scss";
@import "@styles/variables.scss";
</style>
