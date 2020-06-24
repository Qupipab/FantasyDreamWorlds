import { VBtn, VIcon } from 'vuetify/lib';

export default {
  components: {
    VBtn,
    VIcon
  },
  data () {
    return {
      authorized: true,
      navList: [
        { title: 'Форум', path: '/' },
        { title: 'Правила', path: '/' },
        { title: 'Услуги', path: '/' },
        {
          title: 'Сервера',
          path: '/',
          content: [ 'abc' ]
        },
        {
          title: 'Помощь',
          path: '/',
          content: [ 'def' ]
        }
      ]
    };
  }
};
