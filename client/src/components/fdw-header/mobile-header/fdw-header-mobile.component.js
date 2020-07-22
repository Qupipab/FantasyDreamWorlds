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
  },
  methods: {
    openMobileMenu () {
      const body = document.body;
      if (this.mobileActive) {
        body.classList.remove('fdw-modal');
      } else {
        body.classList.add('fdw-modal');
      }
      this.mobileActive = !this.mobileActive;
    }
  }
};
