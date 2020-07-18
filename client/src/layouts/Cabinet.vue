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
import { FdwHeader, FdwFooter } from '@components';

export default {
  components: {
    FdwHeader,
    FdwFooter
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
    position: relative;
    z-index: 10;
    display: flex;
    margin: 100px auto;
    max-width: 1480px;
    min-height: calc(100vh - 95px);
    padding: 0 60px;
    @media (max-width: 857px) {
      flex-direction: column;
    }
  }
  @media (max-width: 767px) {
  .body-content {
    padding: 0 10px;
  }
}
</style>
