import api from '@api';

const shopSuffix = 'Shop';

export default {
  actions: {
    async getGameServers ({ commit }) {
      return await api.get(`/${shopSuffix}/GetGameServers`)
        .then(r => {
          commit('INIT_GAMESERVERS', r.data);
        });
    }
  },
  mutations: {
    INIT_GAMESERVERS: (state, gameServers) => { state.gameServers = gameServers; }
  },
  state: {
    gameServers: []
  },
  getters: {
    getAllGameServers: state => state.gameServers
  }
};
