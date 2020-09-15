import Vue from 'vue';
import Vuex from 'vuex';
import auth from './modules/auth.store';
import locale from './modules/locale.store';
import shop from './modules/shop.store';
import user from './modules/user.store';

Vue.use(Vuex);

export default new Vuex.Store({
  namespaced: true,
  state: {
    themeMode: localStorage.getItem('themeMode')
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    locale,
    shop,
    user,
    auth
  }
});
