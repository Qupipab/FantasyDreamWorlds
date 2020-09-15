import './registerServiceWorker';

import { Cabinet, Default } from '@layouts';

import App from './App.vue';
import { BootstrapVue } from 'bootstrap-vue';
import Vue from 'vue';
import i18n from './plugins/i18n';
import router from '@router';
import store from '@store';
import vSelect from 'vue-select';
import Vuelidate from 'vuelidate';
import Notifications from 'vue-notification';

Vue.use(BootstrapVue);
Vue.use(Notifications);
Vue.use(Vuelidate);

Vue.component('cabinet-layout', Cabinet);
Vue.component('default-layout', Default);
Vue.component('v-select', vSelect);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  i18n,
  created () {
    this.$store.dispatch('setUserInfo');
  },
  render: h => h(App)
}).$mount('#app');
