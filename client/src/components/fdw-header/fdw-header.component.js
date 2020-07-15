import {
  VBtn,
  VIcon,
  VList,
  VListItem,
  VListItemTitle,
  VMenu
} from 'vuetify/lib';

import { FdwThemeSwitch, LocalizedLink } from '@components';

export default {
  components: {
    VBtn,
    VIcon,
    VMenu,
    VList,
    VListItem,
    VListItemTitle,
    FdwThemeSwitch,
    LocalizedLink
  },
  computed: {
    lang () {
      return this.$route.params.lang;
    }
  },
  data () {
    return {
      authorized: true,
      navList: [
        { title: 'header.forum', path: '/' },
        { title: 'header.services', path: '/' },
        {
          title: 'header.serversTitle',
          path: '/',
          content: [
            { title: 'header.servers.infinity', path: '/server/infinity' },
            { title: 'header.servers.arcmagic', path: '/server/arcmagic' },
            { title: 'header.servers.ozone', path: '/server/ozone' },
            { title: 'header.servers.aoe', path: '/server/aoe' }
          ]
        },
        {
          title: 'header.helpTitle',
          path: '/',
          content: [
            { title: 'header.helpList.rating', path: '/' },
            { title: 'header.helpList.rules', path: '/rules' },
            { title: 'header.helpList.banList', path: '/' },
            { title: 'header.helpList.FAQ', path: '/' },
            { title: 'header.helpList.team', path: '/' },
            { title: 'header.helpList.commands', path: '/' }
          ]
        }
      ]
    };
  }
};
