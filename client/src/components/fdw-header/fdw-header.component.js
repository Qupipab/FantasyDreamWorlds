import {
  VBtn,
  VIcon,
  VList,
  VListItem,
  VListItemTitle,
  VMenu
} from 'vuetify/lib';

export default {
  components: {
    VBtn,
    VIcon,
    VMenu,
    VList,
    VListItem,
    VListItemTitle
  },
  data () {
    return {
      authorized: true,
      navList: [
        { title: this.$t('header.forum'), path: '/' },
        { title: this.$t('header.services'), path: '/' },
        {
          title: this.$t('header.serversTitle'),
          path: '/',
          content: [
            { title: 'Infinity', path: '/' },
            { title: 'Arcmagic', path: '/' },
            { title: 'Ozone', path: '/' },
            { title: 'AOE', path: '/' }
          ]
        },
        {
          title: this.$t('header.helpTitle'),
          path: '/',
          content: [
            { title: this.$t('header.helpList.rating'), path: '/' },
            { title: this.$t('header.helpList.rules'), path: '/' },
            { title: this.$t('header.helpList.banList'), path: '/' },
            { title: this.$t('header.helpList.FAQ'), path: '/' },
            { title: this.$t('header.helpList.team'), path: '/' },
            { title: this.$t('header.helpList.commands'), path: '/' }
          ]
        }
      ]
    };
  }
};
