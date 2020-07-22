<template>
  <div id="app" :class="$store.state.themeMode">
    <component :is="layout">
      <router-view/>
    </component>
  </div>
</template>

<script>
const defaultLayout = 'default';

export default {
  name: 'App',
  computed: {
    layout () {
      return (this.$route.meta.layout || defaultLayout) + '-layout';
    }
  }
};
</script>

<style lang="scss">
@import "@styles/common.scss";
@import "@styles/variables.scss";
</style>
