import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import Root from './Root';
import i18n, { loadLocaleMessagesAsync } from '@/plugins/i18n';

import { i18nDocumentUtil } from '@utils';

Vue.use(VueRouter);

const { locale } = i18n,
      routes = [
        {
          path: '/',
          redirect: locale
        },
        {
          path: '/:locale',
          component: Root,
          children: [
            {
              path: '',
              name: 'home',
              component: Home
            }
          ]
        }
      ];
/* eslint-disable */
const router = new VueRouter({
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
  if (to.params.locale === from.params.locale) {
    next();
    return;
  }

  const { locale } = to.params;

  loadLocaleMessagesAsync(locale)
    .then(() => {
      i18nDocumentUtil.setDocumentLang(locale);
    });

  next();
});

export default router;
