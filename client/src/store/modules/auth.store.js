import Vue from 'vue';
import api from '@api';

export default {
  state: {
    status: '',
    token: localStorage.getItem('token') || '',
    user: JSON.parse(localStorage.getItem('user')) || '',
    isLoginVisible: false,
    isConfirmationVisible: false
  },
  mutations: {
    SET_USER_DATA (state, userData) {
      state.user = userData;
      localStorage.setItem('user', JSON.stringify(userData));
    },
    CLEAR_USER_DATA (state) {
      localStorage.removeItem('user');
      state.user = null;
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
            title: err.data.status,
            type: 'error',
            text: err.data.title
          });
          return false;
        });
    },

    async signUp (ctx, body) {
      return await api.post('/Auth/SignUp', body);
    }
    // login ({ commit }, credentials) {
    //   return api.post('/Auth/SignIn', credentials)
    //     .then(({ data }) => {
    //       commit('SET_USER_DATA', data);
    //     });
    // }
  },
  getters: {
  }
};
