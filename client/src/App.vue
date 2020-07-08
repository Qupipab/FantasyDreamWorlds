<template>
  <v-app id="app">
    <div v-if="isLoading">Loading...</div>
    <component v-else :is="layout">
      <router-view/>
    </component>
  </v-app>
</template>

<script>
import {
  VApp
} from 'vuetify/lib';
import EventBus from '@/EventBus';

export default {
  name: 'App',
  components: {
    VApp
  },
  data () {
    return {
      isLoading: true
    };
  },
  computed: {
    layout () {
      return 'default-layout';
    }
  },
  mounted () {
    EventBus.$on('i18n-load-start', () => { this.isLoading = true; });

    EventBus.$on('i18n-load-complete', () => { this.isLoading = false; });
  }
};
</script>

<style lang="scss">
@import "@styles/common.scss";
</style>
