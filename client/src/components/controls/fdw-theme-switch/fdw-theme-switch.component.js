import FdwSun from '@icons/WhiteBalanceSunny';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

export default {
  components: {
    FdwSun,
    FontAwesomeIcon
  },
  methods: {
    switchTheme () {
      if (this.$store.state.themeMode === 'light') {
        localStorage.setItem('themeMode', 'dark');
      } else {
        localStorage.setItem('themeMode', 'light');
      }
      this.$store.state.themeMode = localStorage.getItem('themeMode');
    }
  }
};
