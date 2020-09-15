import { gameServerMixin, categoryMixin, itemMixin } from '@mixins';
import { FdwSelect, FdwFileUpload } from '@components';
import { mapActions } from 'vuex';

export default {
  mixins: [gameServerMixin, categoryMixin, itemMixin],
  components: {
    FdwFileUpload,
    FdwSelect
  },
  data () {
    return {
      addItemPayload: {
        categoryId: 2,
        ruTitle: 'something',
        enTitle: 'something',
        icon: '',
        count: 5,
        coins: 5,
        eCoins: 5,
        discount: 0,
        discountStartDate: null,
        discountEndDate: null
      },
      addItemFile: null,
      editItemPayload: {

      },
      deleteItemPayload: {

      }
    };
  },
  methods: {
    ...mapActions('shop/', [
      'addItemRequest',
      'editItemRequest',
      'deleteItemRequest',
      'uploadItemFile',
      'test'
    ]),
    async addItem () {
      const formData = new FormData();
      formData.append('file', this.addItemFile);
      console.log(this.addItemFile);
      this.addItemPayload.icon = formData;
      console.log(formData);
      await this.test(formData);
      // .then(r => {
      //   this.addItemRequest(this.addItemPayload);
      // });
    },
    async editItem () {
    },
    async deleteItem () {
    },
    async getCategories (val) {
      await this.getCategoriesRequest({ gameServerId: val });
      this.categories = this.$store.state.shop.categories;
    },
    setCategories () {

    },
    onChange (target) {
      this.addItemFile = target.files[0];
    }
  }
};
