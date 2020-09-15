import api from '@api';
import Vue from 'vue';

const shopSuffix = 'Shop';

export default {
  namespaced: true,
  actions: {
    async getGameServersRequest ({ commit }) {
      return await api.get(`/${shopSuffix}/GetGameServers`)
        .then(r => {
          commit('INIT_GAMESERVERS', r.data);
        });
    },
    async getCategoriesRequest ({ commit }, payload) {
      return await api.post(`/${shopSuffix}/GetCategories`, payload)
        .then(r => {
          commit('INIT_CATEGORIES', r.data);
        });
    },
    async getItemsRequest ({ commit }, payload) {
      return await api.post(`/${shopSuffix}/GetItems`, payload)
        .then(r => {
          commit('INIT_ITEMS', r.data);
        });
    },
    async uploadItemFile ({ commit }, payload) {
      return await api.postFile(`/${shopSuffix}/SetItemImage`, payload)
        .then(r => {

        });
    },
    async addGameServer ({ commit }, payload) {
      const title = 'Добавление игрового сервера';
      return await api.post(`/${shopSuffix}/AddGameServer`, payload)
        .then(r => {
          if (r.status === 200) {
            Vue.notify({
              group: 'fdw',
              title: title,
              type: 'success',
              text: 'Успешно!'
            });
          }
        })
        .catch(e => {
          if (e.status === 400) {
            Vue.notify({
              group: 'fdw',
              title: title,
              type: 'error',
              text: 'Такой сервер уже существует.'
            });
          }
        });
    },
    async editGameServer ({ commit }, payload) {
      const title = 'Редактирование игрового сервера';
      return await api.put(`/${shopSuffix}/EditGameServer`, payload)
        .then(r => {
          if (r.status === 200) {
            Vue.notify({
              group: 'fdw',
              title: title,
              type: 'success',
              text: 'Успешно!'
            });
          }
        })
        .catch(e => {
          if (e.status === 400) {
            Vue.notify({
              group: 'fdw',
              title: title,
              type: 'error',
              text: 'Сервер не найден.'
            });
          }
        });
    },
    async deleteGameServer ({ commit }, payload) {
      const title = 'Удаление игрового сервера';
      return await api.delete(`/${shopSuffix}/DeleteGameServer`, payload)
        .then(r => {
          if (r.status === 200) {
            Vue.notify({
              group: 'fdw',
              title: title,
              type: 'success',
              text: 'Успешно!'
            });
          }
        })
        .catch(e => {
          if (e.status === 400) {
            Vue.notify({
              group: 'fdw',
              title: title,
              type: 'error',
              text: 'Сервер не найден.'
            });
          }
        });
    },
    async addCategoryRequest ({ commit }, payload) {
      return await api.post(`/${shopSuffix}/AddCategory`, payload)
        .then(r => {
        })
        .catch(e => {
        });
    },
    async editCategoryRequest ({ commit }, payload) {
      return await api.put(`/${shopSuffix}/EditCategory`, payload)
        .then(r => {
        })
        .catch(e => {
        });
    },
    async deleteCategoryRequest ({ commit }, payload) {
      return await api.delete(`/${shopSuffix}/DeleteCategory`, payload)
        .then(r => {
        })
        .catch(e => {
        });
    },
    async addItemRequest ({ commit }, payload) {
      return await api.postFile(`/${shopSuffix}/AddItem`, payload)
        .then(r => {
        })
        .catch(e => {
        });
    },
    async editItemRequest ({ commit }, payload) {
      return await api.put(`/${shopSuffix}/EditItem`, payload)
        .then(r => {
        })
        .catch(e => {
        });
    },
    async deleteItemRequest ({ commit }, payload) {
      return await api.delete(`/${shopSuffix}/DeleteItem`, payload)
        .then(r => {
        })
        .catch(e => {
        });
    },
    async test ({ commit }, payload) {
      return await api.postFile('/Test', payload)
        .then(r => {
        })
        .catch(e => {
        });
    }
  },
  mutations: {
    INIT_GAMESERVERS: (state, gameServers) => { state.gameServers = gameServers; },
    INIT_CATEGORIES: (state, categories) => {
      state.categories = categories;
      state.categories.unshift({
        id: 0,
        ruTitle: 'Все категории',
        enTitle: 'All Categories'
      });
    },
    INIT_ITEMS: (state, items) => { state.items = items; }
  },
  state: {
    gameServers: [],
    categories: [],
    items: []
  },
  getters: {
    getAllGameServers: state => state.gameServers,
    getAllCategories: state => state.categories,
    getAllItems: state => state.items
  }
};
