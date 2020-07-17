<template>
  <cabinet>
    <slot></slot>
    <fdw-sidebar></fdw-sidebar>
  </cabinet>
</template>

<script>
import { Cabinet } from '@layouts';
import { FdwSidebar } from '@components';

export default {
  components: {
    Cabinet,
    FdwSidebar
  }
};
</script>
