<template>
  <v-app id="app">
    <fdw-header></fdw-header>
    <div class="temp"></div>
    <fdw-footer></fdw-footer>
  </v-app>
</template>

<script>
import {
  VApp
} from 'vuetify/lib';
import { FdwHeader, FdwFooter } from '@components';

export default {
  name: 'App',
  components: {
    VApp,
    FdwHeader,
    FdwFooter
  }
};
</script>

<style lang="scss">
@import "@styles/common.scss";
.temp {
  height: 1000px;
}

</style>
