import { FdwThemeSwitch, LocalizedLink } from '@components';

export default {
  components: {
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
