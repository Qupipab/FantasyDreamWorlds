import './registerServiceWorker';

import { Cabinet, Default } from '@layouts';

import Vue from 'vue';
import App from './App.vue';
import i18n from './plugins/i18n';
import router from '@router';
import store from '@store';
import vuetify from './plugins/vuetify';

Vue.component('cabinet-layout', Cabinet);
Vue.component('default-layout', Default);

Vue.config.productionTip = false;

new Vue({
  vuetify,
  router,
  store,
  i18n,
  render: h => h(App)
}).$mount('#app');
