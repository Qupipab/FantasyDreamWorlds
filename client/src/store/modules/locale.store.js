import i18n from '../../plugins/i18n';
import { getBrowserLocaleUtil } from '@services';
import { SUPPORTED_LOCALES } from '@constants';

export default {
  namespaced: true,
  state: {
    language: 'ru'
  },
  mutations: {
    INIT_OR_CHANGE_LANGUAGE (state, language) {
      if (!localStorage.getItem('language')) {
        language = getBrowserLocaleUtil.getBrowserLocale();
        language = SUPPORTED_LOCALES.includes(language) ? 'ru' : 'en';
      } else {
        language = SUPPORTED_LOCALES.includes(language) ? 'ru' : 'en';
      }
      i18n.locale = language;
      localStorage.setItem('language', language);
      state.language = language;
    }
  }
};
