import { LocalizedLink } from '@components';
import i18n from '../../plugins/i18n.js';

export default {
  components: {
    LocalizedLink
  },
  computed: {
    lang () {
      return this.$route.params.locale;
    }
  },
  data () {
    return {
      authorized: true,
      checkedServerGroup: null,
      serversGroupList: [
        {
          groupTitle: 'Infinity',
          serverVersion: '1.7.10',
          link: '/server/infinity',
          serversList: [
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            }
          ]
        },
        {
          groupTitle: 'Ozone',
          serverVersion: '1.7.10',
          link: '/server/ozone',
          serversList: [
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            }
          ]
        },
        {
          groupTitle: 'Arcmagic',
          serverVersion: '1.7.10',
          link: '/server/arcmagic',
          serversList: [
            {
              onlineCount: 50,
              maxSlotCount: 100
            }
          ]
        },
        {
          groupTitle: 'AOE',
          serverVersion: '1.7.10',
          link: '/server/aoe',
          serversList: [
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            },
            {
              onlineCount: 50,
              maxSlotCount: 100
            }
          ]
        }
      ]
    };
  },
  methods: {
    showServerGroup (i) {
      if (this.checkedServerGroup && this.checkedServerGroup === i + 1) {
        this.checkedServerGroup = null;
        return;
      }
      this.checkedServerGroup = i + 1;
    }
  },
  filters: {
    serversCount (val) {
      if (val === 1) {
        return `${val + i18n.t('sidebar.pluralServer1')}`;
      } else if (val > 1 && val < 5) {
        return `${val + i18n.t('sidebar.pluralServer2')}`;
      } else {
        return `${val + i18n.t('sidebar.pluralServer3')}`;
      }
    },
    getGeneralOnlineCount (val) {
      return val.reduce((res, el) => res + el.onlineCount, 0);
    },
    getGeneralSlotsCount (val) {
      return val.reduce((res, el) => res + el.maxSlotCount, 0);
    },
    setServerNumber (val, i, serversLength) {
      return serversLength > 1 ? `${val + ' #' + i}` : val;
    }
  }
};
