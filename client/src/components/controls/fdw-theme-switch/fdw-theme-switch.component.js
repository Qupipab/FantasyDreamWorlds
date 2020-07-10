import { VIcon } from 'vuetify/lib';

export default {
  components: {
    VIcon
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
