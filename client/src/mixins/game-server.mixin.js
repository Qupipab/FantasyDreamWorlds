import { mapActions } from 'vuex';

export const gameServerMixin = {
  data () {
    return {
      gameServers: []
    };
  },
  methods: {
    ...mapActions('shop/', [
      'getGameServersRequest'
    ]),
    async getAllGameServers () {
      await this.getGameServersRequest();
      this.gameServers = this.$store.state.shop.gameServers;
    }
  },
  async mounted () {
    this.getAllGameServers();
  }
};
