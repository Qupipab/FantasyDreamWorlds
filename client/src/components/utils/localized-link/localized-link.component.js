export default {
  props: [ 'to' ],
  methods: {
    getTo () {
      if (typeof this.to !== 'string') {
        return this.to;
      }

      const lang = this.$route.params.lang;

      if (!lang) {
        return `/${this.to.replace(/^\/|\/$/g, '')}`;
      } else {
        return `/${lang}/${this.to.replace(/^\/|\/$/g, '')}`;
      }
    }
  }
};
