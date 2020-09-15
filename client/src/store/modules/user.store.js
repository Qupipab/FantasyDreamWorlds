export default {
  actions: {
    setUserInfo ({ commit }) {
      if (localStorage.getItem('token')) {
        const token = localStorage.getItem('token'),
              userInfo = JSON.parse(atob(token.split('.')[1]));

        commit('COMMIT_USERINFO', userInfo);
        if (userInfo.role) {
          commit('COMMIT_USERROLES', userInfo.role);
        }
      }
    }
  },
  mutations: {
    COMMIT_USERINFO: (state, userInfo) => { state.userInfo = userInfo; },
    COMMIT_USERROLES: (state, userRoles) => { state.userRoles = userRoles; }
  },
  state: {
    userInfo: [],
    userRoles: []
  }
};
