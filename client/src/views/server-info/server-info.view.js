export default {
  props: [ 'serverName' ],
  computed: {
    lang () {
      return this.$route.params.locale;
    }
  },
  data () {
    return {
      serversGroupList: [
        {
          groupTitle: 'Infinity',
          serverVersion: '1.7.10',
          link: '/',
          serversList: [
            {
              onlineCount: 50,
              maxSlotCount: 100,
              lastWipe: '01.01.2020'
            },
            {
              onlineCount: 50,
              maxSlotCount: 100,
              lastWipe: '02.01.2020'
            },
            {
              onlineCount: 50,
              maxSlotCount: 100,
              lastWipe: '03.01.2020'
            },
            {
              onlineCount: 50,
              maxSlotCount: 100,
              lastWipe: '04.01.2020'
            }
          ]
        }
      ]
    };
  },
  mounted () {
  },
  filters: {
    numberWithSpaces (val) {
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ' ');
    },
    getWikiLink (val, lang) {
      const wiki = lang === 'ru' ? 'вики' : 'wiki';
      return `https://www.google.com/search?q=minecraft+${val}+${wiki}`;
    }
  }
};
