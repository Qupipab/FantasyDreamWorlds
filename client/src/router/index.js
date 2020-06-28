/* eslint-disable */
import { Home } from '@views';
import { SUPPORTED_LOCALES } from '@constants';
import Vue from 'vue';
import VueRouter from 'vue-router';
import store from '@store';

Vue.use(VueRouter);

// function load (component) {
//   return () => import(`@views/${component}.vue`)
// }

function getLocale(lang = 'ru') {
  const locale = SUPPORTED_LOCALES.find(locale => locale.code === lang);
  return locale ? locale.code : 'ru';
}


const routes = [
  {
    path: '/:lang?',
    component: {
      template: '<router-view></router-view>'
    },
    beforeEnter (to) {
      if (store.state.locale.language !== to.params.lang) {
        store.commit('locale/CHANGE_LANGUAGE', getLocale(to.params.lang));
      }
    },
    children: [
      {
        path: 'home',
        name: 'Home',
        component: Home
      }
    ]
  }
],
      router = new VueRouter({
        mode: 'history',
        base: process.env.BASE_URL,
        routes
      });

export default router;
// {
//   path: '/about',
//   name: 'About',
//   // route level code-splitting
//   // this generates a separate chunk (about.[hash].js) for this route
//   // which is lazy-loaded when the route is visited.
//   component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
// }
