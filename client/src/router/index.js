/* eslint-disable */
import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import Root from './Root';
import store from '@store';
import { ServerInfo } from '@views';
import { SUPPORTED_LOCALES } from '@constants';

Vue.use(VueRouter);

const lang = SUPPORTED_LOCALES.includes(store.state.locale.language) ? undefined : 'en',
      routes = [
        {
          path: '/',
          redirect: lang
        },
        {
          path: '/:lang?',
          component: Root,
          props: true,
          children: [
            {
              path: '',
              name: 'home',
              component: Home
            },
            {
              path: 'server/:serverName',
              name: 'server',
              component: ServerInfo,
              props: true
            }
          ]
        }
      ],
      router = new VueRouter({
        mode: 'history',
        base: process.env.BASE_URL,
        routes
      });

// {
//   path: "about",
//   name: "about",
//   // route level code-splitting
//   // this generates a separate chunk (about.[hash].js) for this route
//   // which is lazy-loaded when the route is visited.
//   component: () =>
//     import(/* webpackChunkName: "about" */ '../views/About.vue')
// }

router.beforeEach((to, from, next) => {
  const lang = to.params.lang || 'ru';
  if (lang === from.params.lang) {
    next();
    return;
  } else if (lang === 'en' || lang === 'ru') {
    store.commit('locale/INIT_OR_CHANGE_LANGUAGE', lang);
  }
  next();
});

export default router;
