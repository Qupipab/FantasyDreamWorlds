import { VSelect } from 'vuetify/lib';
import { supportedLocalesUtil } from '@utils';

export default {
  components: {
    VSelect
  },
  data () {
    return {
      locales: supportedLocalesUtil.getSupportedLocales()
    };
  },
  methods: {
    changeLocale (l) {
      const index = this.locales.findIndex(loc => loc.name === l),
            locale = this.locales[index].code;
      if (this.$route.path !== `/${locale}`) {
        this.$router.push(`/${locale}`);
      }
    }
  }
};
