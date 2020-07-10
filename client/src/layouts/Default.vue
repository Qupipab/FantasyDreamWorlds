<template>
  <div class="content">
    <fdw-header></fdw-header>
    <div class="body-content">
      <slot></slot>
    </div>
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

<style lang="scss" scoped>
  .content {
    background-color: var(--l-third-level-bgc-color);
  }
  .dark {
    .content {
      background-color: var(--d-third-level-bgc-color);
    }
  }
  .body-content {
    margin: 0 auto;
    max-width: 1480px;
    min-height: calc(100vh - 95px);
    padding: 0 60px;
  }
</style>
