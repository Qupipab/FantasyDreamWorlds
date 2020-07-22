import FdwSun from '@icons/WhiteBalanceSunny';
import FdwMoon from '@icons/WeatherNight';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

export default {
  components: {
    FdwSun,
    FdwMoon,
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
