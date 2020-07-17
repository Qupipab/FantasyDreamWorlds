import './registerServiceWorker';

import App from './App.vue';
import { Default } from '@layout';
import Vue from 'vue';
import api from '@api';
import i18n from './plugins/i18n';
import router from '@router';
import store from '@store';
import vuetify from './plugins/vuetify';

Vue.component('default-layout', Default);

Vue.config.productionTip = false;
Vue.prototype.$api = api;

new Vue({
  vuetify,
  router,
  store,
  i18n,
  render: h => h(App)
}).$mount('#app');
