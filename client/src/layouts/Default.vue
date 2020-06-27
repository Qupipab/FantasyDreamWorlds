<template>
  <div class="content">
    <fdw-header></fdw-header>
    <slot></slot>
    <fdw-footer></fdw-footer>
  </div>
</template>

<script>
import { FdwFooter, FdwHeader } from '@components';

export default {
  components: {
    FdwFooter,
    FdwHeader
  }
};
</script>
