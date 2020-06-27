import { VIcon } from 'vuetify/lib';

export default {
  components: {
    VIcon
  },
  data () {
    return {
      authorized: true,
      currentDate: new Date().getFullYear(),
      footerNavList: {
        titleInfo: [
          { title: 'Команда проекта', path: '#' },
          { title: 'Обратная связь', path: '#' },
          { title: 'Мы в ВК', path: '#' },
          { title: 'Наш дискорд', path: '#' }
        ],
        bodyInfo: [
          { title: 'Форум', path: '#' },
          { title: 'Правила', path: '#' },
          { title: 'Команды', path: '#' },
          { title: 'Бан лист', path: '#' },
          { title: 'Скачать лаунчер', path: '#' },
          { title: 'Техническая поддержка', path: '#' }
        ]
      }
    };
  }
};
