import {
  VBtn,
  VIcon
} from 'vuetify/lib';

import { FdwThemeSwitch, LocalizedLink } from '@components';

export default {
  components: {
    VBtn,
    VIcon,
    FdwThemeSwitch,
    LocalizedLink
  },
  computed: {
    lang () {
      return this.$route.params.lang;
    }
  },
  data () {
    return {
      authorized: true
    };
  }
};
