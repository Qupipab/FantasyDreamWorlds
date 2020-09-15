import { mapActions } from 'vuex';

export const categoryMixin = {
  data () {
    return {
      categories: []
    };
  },
  methods: {
    ...mapActions('shop/', [
      'getCategoriesRequest'
    ]),
    async getAllCategories () {
      await this.getCategoriesRequest();
      this.categories = this.$store.state.shop.categories;
    }
  }
};
