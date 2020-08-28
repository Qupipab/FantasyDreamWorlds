import './registerServiceWorker';

import { Cabinet, Default } from '@layouts';

import App from './App.vue';
import { BootstrapVue } from 'bootstrap-vue';
import Notifications from 'vue-notification';
import Vue from 'vue';
import Vuelidate from 'vuelidate';
import i18n from './plugins/i18n';
import router from '@router';
import store from '@store';

Vue.use(BootstrapVue);
Vue.use(Notifications);
Vue.use(Vuelidate);

Vue.component('cabinet-layout', Cabinet);
Vue.component('default-layout', Default);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  i18n,
  render: h => h(App)
}).$mount('#app');
