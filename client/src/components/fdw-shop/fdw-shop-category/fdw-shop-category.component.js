import { gameServerMixin, categoryMixin } from '@mixins';
import { FdwSelect } from '@components';
import { mapActions } from 'vuex';

export default {
  mixins: [gameServerMixin, categoryMixin],
  components: {
    FdwSelect
  },
  data () {
    return {
      categories: [],
      addCategoryPayload: {
        gameServerId: 0,
        ruTitle: '',
        enTitle: ''
      },
      editCategoryPayload: {
        categoryId: 0,
        newRuTitle: '',
        newEnTitle: ''
      },
      deleteCategoryPayload: {
        categoryId: 0
      }
    };
  },
  methods: {
    ...mapActions('shop/', [
      'addCategoryRequest',
      'editCategoryRequest',
      'deleteCategoryRequest',
      'getCategoriesRequest'
    ]),
    async addCategory () {
      await this.addCategoryRequest(this.addCategoryPayload)
        .then(() => this.clearAllFields());
    },
    async editCategory () {
      await this.editCategoryRequest(this.editCategoryPayload)
        .then(() => this.clearAllFields());
    },
    async deleteCategory () {
    },
    async getCategories (val) {
      await this.getCategoriesRequest({ gameServerId: val });
      this.categories = this.$store.state.shop.categories;
    },
    setEditCategory (categoryId) {
      const category = this.categories.find(c => c.id === categoryId);
      this.editCategoryPayload.newRuTitle = category.ruTitle;
      this.editCategoryPayload.newEnTitle = category.enTitle;
    },
    clearAllFields () {
      this.editCategoryPayload.ruTitle = '';
      this.editCategoryPayload.enTitle = '';
      this.editCategoryPayload.newRuTitle = '';
      this.editCategoryPayload.newEnTitle = '';
    }
  }
};
