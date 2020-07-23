<template>
  <header>
    <fdw-squares
      height="350px"
      :min-size="20"
      :max-size="40"
      :count="15"
    ></fdw-squares>
    <fdw-desktop-header></fdw-desktop-header>
    <fdw-mobile-header></fdw-mobile-header>
    <b-modal id="sign-in-modal" hide-header hide-footer centered>
      <p class="my-4"><fdw-sign-in></fdw-sign-in></p>
    </b-modal>
    <b-modal id="sign-up-modal" hide-header hide-footer centered>
      <p class="my-4"><fdw-sign-up></fdw-sign-up></p>
    </b-modal>
  </header>
</template>

<script>
import { FdwSquares, FdwSignIn, FdwSignUp } from '@components';
import FdwDesktopHeader from './desktop-header/fdw-header-desktop.component.vue';
import FdwMobileHeader from './mobile-header/fdw-header-mobile.component.vue';

export default {
  components: {
    FdwDesktopHeader,
    FdwMobileHeader,
    FdwSquares,
    FdwSignIn,
    FdwSignUp
  }
};

</script>

<style>
header {
  position: relative;
  height: 95px;
}
</style>
