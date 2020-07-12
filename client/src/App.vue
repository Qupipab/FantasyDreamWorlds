<template>
  <v-app id="app" :class="$store.state.themeMode">
    <div v-if="isLoading">Loading...</div>
    <component v-else :is="layout">
      <router-view/>
    </component>
  </v-app>
</template>

<script>
import {
  VApp,
  VSwitch
} from 'vuetify/lib';
import { FdwSidebar } from '@components';
import EventBus from '@/EventBus';

export default {
  name: 'App',
  components: {
    VApp,
    VSwitch,
    FdwSidebar
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
@import "@styles/variables.scss";
</style>
