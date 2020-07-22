export default {
  computed: {
    language () {
      return this.$store.state.language;
    }
  },
  data () {
    return {
      selectedLocale: this.$store.state.language
    };
  },
  methods: {
    setLocale (language) {
      if (language !== this.selectedLocale) {
        this.selectedLocale = language;
        this.$store.commit('locale/INIT_OR_CHANGE_LANGUAGE', language);
        const fullRoute = this.$route.fullPath,
              currentLang = this.$route.params.lang;
        if (currentLang === language) {
          return;
        }
        if (currentLang === 'en' || currentLang === 'ru') {
          this.$router.push(`/${fullRoute.substring(fullRoute.indexOf('/', 2) + 1)}`);
        } else {
          this.$router.push(`/en${fullRoute}`);
        }
      }
    }
  }
};
