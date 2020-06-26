<template>
  <v-app id="app">
    <fdw-header></fdw-header>
  </v-app>
</template>

<script>
import {
  VApp
} from 'vuetify/lib';
import { FdwHeader } from '@components';

export default {
  name: 'App',
  components: {
    VApp,
    FdwHeader
  },
  computed: {}
};
</script>

<style lang="scss">
@import "@styles/common.scss";
</style>
