<template>
  <div id="app" :class="$store.state.themeMode">
    <component :is="layout">
      <router-view/>
    </component>
    <notifications group="fdw" />
  </div>
</template>

<script>
import { library } from '@fortawesome/fontawesome-svg-core';
import {
  faMoon,
  faQuestionCircle,
  faFileAlt
} from '@fortawesome/free-solid-svg-icons';

library.add(faMoon);
library.add(faQuestionCircle);
library.add(faFileAlt);

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
@import "@styles/variables.scss";
@import "@styles/common.scss";
.notification-title {
  margin-bottom: 10px;
  font-size: 15px;
}
.notification-content {
  font-weight: 400;
}
</style>
