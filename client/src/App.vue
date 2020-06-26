<template>
  <v-app id="app">
    <fdw-header></fdw-header>
    <fdw-sidebar></fdw-sidebar>
    <div class="temp"></div>
  </v-app>
</template>

<script>
import {
  VApp
} from 'vuetify/lib';
import { FdwHeader, FdwSidebar } from '@components';

export default {
  name: 'App',
  components: {
    VApp,
    FdwHeader,
    FdwSidebar
  },
  computed: {}
};
</script>

<style lang="scss">
@import "@styles/common.scss";
.temp {
  height: 3000px;
}
</style>
