import { VIcon } from 'vuetify/lib';

export default {
  components: {
    VIcon
  },
  data () {
    return {
      authorized: true,
      currentDate: new Date().getFullYear(),
      footerNavList: {
        titleInfo: [
          { title: this.$t('footer.titleInfo.team'), path: '#' },
          { title: this.$t('footer.titleInfo.feedback'), path: '#' },
          { title: this.$t('footer.titleInfo.vk'), path: '#' },
          { title: this.$t('footer.titleInfo.ds'), path: '#' }
        ],
        bodyInfo: [
          { title: this.$t('footer.bodyInfo.forum'), path: '#' },
          { title: this.$t('footer.bodyInfo.rules'), path: '#' },
          { title: this.$t('footer.bodyInfo.commands'), path: '#' },
          { title: this.$t('footer.bodyInfo.banList'), path: '#' },
          { title: this.$t('footer.bodyInfo.download'), path: '#' },
          { title: this.$t('footer.bodyInfo.support'), path: '#' }
        ]
      }
    };
  }
};
