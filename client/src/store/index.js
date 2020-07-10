import Vue from 'vue';
import Vuex from 'vuex';
import locale from './modules/locale.store';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    themeMode: localStorage.getItem('themeMode')
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    locale
  }
});
