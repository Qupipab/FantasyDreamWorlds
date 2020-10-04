/* eslint-disable */
import { FdwSelect, FdwShopGameServer, FdwShopCategory, FdwShopItem } from '@components';
import Magnify from '@icons/Magnify';
import { mapActions } from 'vuex';

export default {
  components: {
    FdwShopGameServer,
    FdwShopCategory,
    FdwShopItem,
    FdwSelect,
    Magnify
  },
  data () {
    return {
      gameServers: [],
      categories: [],
      items: [],
      getItemsPayload: {
        serverId: 0,
        categoryId: 0,
        itemsForSearch: "",
        sortType: 0,
        language: 0,
        paginationQuery: {
          pageNumber: 1,
          pageSize: 5
        }
      },
      sortTypes: [
        { ruTitle: 'По возрастанию цены', enTitle: 'Ascending Price', index: 0 },
        { ruTitle: 'По убыванию цены', enTitle: 'Descending Price', index: 1 },
        { ruTitle: 'Сначала скидки', enTitle: 'Discount', index: 2 }
      ]
    };
  },
  methods: {
    ...mapActions('shop/', [
      'getGameServersRequest',
      'getCategoriesRequest',
      'getItemsRequest'
    ]),
    async selectServer (server) {
      this.getItemsPayload.serverId = server.id;
      await this.getCategoriesRequest({ gameServerId: server.id });
      this.categories = this.$store.state.shop.categories;
      await this.getQueryItems();
    },
    async selectCategory (category) {
      this.getItemsPayload.categoryId = category.id;
      await this.getQueryItems();
    },
    async setSortType (sortType) {
      this.getItemsPayload.sortType = sortType.index;
      await this.getQueryItems();
    },
    async getQueryItems () {
      await this.getItemsRequest(this.getItemsPayload);
      this.items = this.$store.state.shop.items;
    },
    async instantGetItemsQuery () {
      if(this.getItemsPayload.itemsForSearch.length > 3 || this.getItemsPayload.itemsForSearch === "") {
        await this.getItemsRequest(this.getItemsPayload);
        this.items = this.$store.state.shop.items;
      }
    }
  },
  async mounted () {
    await this.getGameServersRequest();
    this.gameServers = this.$store.state.shop.gameServers;
  }
};
