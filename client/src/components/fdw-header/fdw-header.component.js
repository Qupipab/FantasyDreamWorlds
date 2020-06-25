import {
  VBtn,
  VIcon,
  VList,
  VListItem,
  VListItemTitle,
  VMenu
} from 'vuetify/lib';

export default {
  components: {
    VBtn,
    VIcon,
    VMenu,
    VList,
    VListItem,
    VListItemTitle
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
          content: [
            { title: 'Infinity', path: '/' },
            { title: 'Arcmagic', path: '/' },
            { title: 'Ozone', path: '/' },
            { title: 'AOE', path: '/' }
          ]
        },
        {
          title: 'Помощь',
          path: '/',
          content: [
            { title: 'Рейтинг', path: '/' },
            { title: 'Бан лист', path: '/' },
            { title: 'Частые вопросы', path: '/' },
            { title: 'Команда проекта', path: '/' },
            { title: 'Команды', path: '/' }
          ]
        }
      ]
    };
  }
};
