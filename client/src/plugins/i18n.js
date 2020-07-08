import EventBus from '@/EventBus';
import Vue from 'vue';
import VueI18n from 'vue-i18n';
import {
  getBrowserLocaleUtil,
  supportedLocalesUtil,
  choiceIndexForPluralUtil
} from '@utils';

Vue.use(VueI18n);

function getStartingLocale () {
  const browserLocale = getBrowserLocaleUtil.getBrowserLocale({ countryCodeOnly: true });

  if (supportedLocalesUtil.supportedLocalesInclude(browserLocale)) {
    return browserLocale;
  } else {
    return process.env.VUE_APP_I18N_LOCALE || 'ru';
  }
}

choiceIndexForPluralUtil.setDefaultChoiceIndexGet(VueI18n.prototype.getChoiceIndex);

VueI18n.prototype.getChoiceIndex = choiceIndexForPluralUtil.getChoiceIndex;

const startingLocale = getStartingLocale(),
      i18n = new VueI18n({
        locale: startingLocale,
        fallbackLocale: 'ru',
        messages: {}
      }),
      loadedLanguages = [];
export function loadLocaleMessagesAsync (locale) {
  EventBus.$emit('i18n-load-start');

  if (loadedLanguages.length > 0 && i18n.locale === locale) {
    EventBus.$emit('i18n-load-complete');
    return Promise.resolve(locale);
  }

  if (loadedLanguages.includes(locale)) {
    i18n.locale = locale;
    EventBus.$emit('i18n-load-complete');
    return Promise.resolve(locale);
  }

  return import('@/locales/translations/' + locale + '.json')
    .then(messages => {
      i18n.setLocaleMessage(locale, messages.default);

      loadedLanguages.push(locale);

      i18n.locale = locale;

      EventBus.$emit('i18n-load-complete');
      return Promise.resolve(locale);
    });
}

export default i18n;
