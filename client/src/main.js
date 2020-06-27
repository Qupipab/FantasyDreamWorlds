import './registerServiceWorker';

import App from './App.vue';
import Default from './layouts/Default.vue';
import Vue from 'vue';
import router from '@router';
import store from '@store';
import vuetify from './plugins/vuetify';

Vue.config.productionTip = false;

Vue.component('default-layout', Default);

new Vue({
  router,
  vuetify,
  store,
  render: h => h(App)
}).$mount('#app');
