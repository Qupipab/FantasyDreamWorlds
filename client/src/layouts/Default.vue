<template>
  <cabinet>
    <div class="body-content">
      <slot></slot>
    </div>
    <fdw-sidebar></fdw-sidebar>
  </cabinet>
</template>

<script>
import { FdwSidebar } from '@components';
import { Cabinet } from '@layouts';

export default {
  components: {
    Cabinet,
    FdwSidebar
  }
};
</script>

<style lang="scss">
  .body-content {
    display: flex;
    flex: 4 4 1px;
  }
</style>
