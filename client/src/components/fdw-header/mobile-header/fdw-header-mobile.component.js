import { FdwThemeSwitch, LocalizedLink, FdwLocaleSelect } from '@components';

export default {
  components: {
    FdwThemeSwitch,
    FdwLocaleSelect,
    LocalizedLink
  },
  data () {
    return {
      authorized: false,
      mobileActive: false
    };
  }
};
