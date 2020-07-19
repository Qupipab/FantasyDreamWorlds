<template>
  <header>
    <fdw-squares
      height="350px"
      min-size="20px"
      max-size="40px"
      :count="15"
    ></fdw-squares>
    <fdw-desktop-header></fdw-desktop-header>
    <fdw-mobile-header></fdw-mobile-header>
  </header>
</template>

<script>
import { FdwSquares } from '@components';
import FdwDesktopHeader from './desktop-header/fdw-header-desktop.component.vue';
import FdwMobileHeader from './mobile-header/fdw-header-mobile.component.vue';

export default {
  components: {
    FdwDesktopHeader,
    FdwMobileHeader,
    FdwSquares
  }
};

</script>

<style>
header {
  position: relative;
  height: 95px;
}
</style>
