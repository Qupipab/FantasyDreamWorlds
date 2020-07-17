import Vue from 'vue';
import VueRouter from 'vue-router';
import Root from './Root';
import store from '@store';
import {
  ServerInfo,
  Rules,
  Commands,
  Page404
} from '@views';

Vue.use(VueRouter);

const routes = [
  {
    path: '*',
    name: 'Page404',
    component: Page404
  },
  {
    path: '/:lang(en|ru)?',
    component: Root,
    props: true,
    children: [
      {
        path: 'server/:serverName(infinity|ozone|arcmagic)',
        name: 'Server',
        component: ServerInfo,
        props: true
      },
      {
        path: 'rules',
        name: 'Rules',
        component: Rules
      },
      {
        path: 'commands',
        name: 'Commands',
        component: Commands
      }
    ]
  }
],
      router = new VueRouter({
        mode: 'history',
        base: process.env.BASE_URL,
        routes
      });

// meta: { layout: 'cabinet' }
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
