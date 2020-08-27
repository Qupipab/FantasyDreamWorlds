import Vue from 'vue';
import api from '@api';

export default {
  state: {
    token: localStorage.getItem('token') || ''
  },
  mutations: {
    SET_TOKEN (state, userData) {
      localStorage.setItem('token', userData.token);
      state.token = userData.token;
    },
    CLEAR_TOKEN (state) {
      localStorage.removeItem('token');
      state.token = '';
      location.reload();
    }
  },
  actions: {
    async CheckByUserName ({ commit }, login) {
      return await api.post('/Auth/CheckByUserName', { userName: login })
        .then(r => {
          if (r.status === 200) {
            return true;
          }
        })
        .catch(err => {
          Vue.notify({
            group: 'fdw',
            title: `Error ${err.data.status}`,
            type: 'error',
            text: err.data.title
          });
          return false;
        });
    },
    async signUp ({ commit }, body) {
      return await api.post('/Auth/SignUp', body)
        .then(({ data }) => {
          commit('SET_TOKEN', data);
          return true;
        })
        .catch(err => {
          Vue.notify({
            group: 'fdw',
            title: 'Error',
            type: 'error',
            text: err.data.errors[0]
          });
          return false;
        });
    },
    async signIn ({ commit }, credentials) {
      return await api.post('/Auth/SignIn', credentials)
        .then(({ data }) => {
          commit('SET_TOKEN', data);
          return true;
        })
        .catch(err => {
          Vue.notify({
            group: 'fdw',
            title: 'Error',
            type: 'error',
            text: err.data.errors[0]
          });
          return false;
        });
    },
    async logout ({ commit }) {
      return await new Promise((resolve, reject) => {
        commit('CLEAR_TOKEN');
      });
    }
  },
  getters: {
    userInfo: state => {
      const userInfo = JSON.parse(atob(state.token.split('.')[1]));
      return userInfo;
    },
    authorized: state => !!state.token
  }
};
