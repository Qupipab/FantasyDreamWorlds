import { mapActions } from 'vuex';

export const itemMixin = {
  data () {
    return {
      items: []
    };
  },
  methods: {
    ...mapActions('shop/', [
      'getGameServers'
    ]),
    async getAllItems () {
      await this.getGameServers();
      this.items = this.$store.state.shop.items;
    }
  },
  async mounted () {
    this.getAllItems();
  }
};
