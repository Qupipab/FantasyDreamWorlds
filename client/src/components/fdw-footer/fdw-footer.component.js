import { FdwLocaleSelect, LocalizedLink } from '@components';

export default {
  components: {
    FdwLocaleSelect,
    LocalizedLink
  },
  data () {
    return {
      authorized: true,
      currentDate: new Date().getFullYear(),
      footerNavList: {
        titleInfo: [
          { title: 'footer.titleInfo.team', path: '#' },
          { title: 'footer.titleInfo.feedback', path: '#' },
          { title: 'footer.titleInfo.vk', path: '#' },
          { title: 'footer.titleInfo.ds', path: '#' }
        ],
        bodyInfo: [
          { title: 'footer.bodyInfo.forum', path: '#' },
          { title: 'footer.bodyInfo.rules', path: '#' },
          { title: 'footer.bodyInfo.commands', path: '#' },
          { title: 'footer.bodyInfo.banList', path: '#' },
          { title: 'footer.bodyInfo.download', path: '#' },
          { title: 'footer.bodyInfo.support', path: '#' }
        ]
      }
    };
  }
};
