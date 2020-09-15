import { FdwSelect } from '@components';
import { gameServerMixin } from '@mixins';
import { mapActions } from 'vuex';

export default {
  mixins: [ gameServerMixin ],
  components: {
    FdwSelect
  },
  data () {
    return {
      addGameServerPayload: {
        title: ''
      },
      editGameServerPayload: {
        oldTitle: '',
        newTitle: ''
      },
      deleteGameServerPayload: {
        title: ''
      }
    };
  },
  methods: {
    ...mapActions('shop/', [
      'addGameServer',
      'editGameServer',
      'deleteGameServer'
    ]),
    async addServer () {
      await this.addGameServer(this.addGameServerPayload)
        .then(() => this.clearAllFields());
    },
    async editServer () {
      await this.editGameServer(this.editGameServerPayload)
        .then(() => this.clearAllFields());
    },
    async deleteServer () {
      await this.deleteGameServer(this.deleteGameServerPayload);
    },
    clearAllFields () {
      this.addGameServerPayload.title = '';
      this.editGameServerPayload.newTitle = '';
    },
    setNewTitle (val) {
      this.editGameServerPayload.newTitle = val;
    }
  }
};
