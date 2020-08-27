/* eslint-disable no-unused-vars */

import { FdwThemeSwitch, LocalizedLink } from '@components';
import { mapActions, mapGetters, mapState } from 'vuex';

export default {
  components: {
    FdwThemeSwitch,
    LocalizedLink
  },
  computed: {
    ...mapState([ 'token' ]),
    ...mapGetters([
      'userInfo',
      'authorized'
    ]),
    lang () {
      return this.$route.params.lang;
    }
  },
  data () {
    return {
    };
  },
  methods: {
    ...mapActions([ 'logout' ])
  }
};
