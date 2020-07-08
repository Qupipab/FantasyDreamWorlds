<template>
  <div class="locale-switcher">
    <select
      :value="$i18n.locale"
      @change.prevent="changeLocale"
    >
      <option
        :value="locale.code"
        v-for="locale in locales"
        :key="locale.code"
      >
        {{ locale.name }}
      </option>
    </select>
  </div>
</template>

<script>
import { supportedLocalesUtil } from '@utils';

export default {
  data: () => ({ locales: supportedLocalesUtil.getSupportedLocales() }),
  methods: {
    changeLocale (e) {
      const locale = e.target.value;

      this.$router.push(`/${locale}`);
    }
  }
};
</script>
