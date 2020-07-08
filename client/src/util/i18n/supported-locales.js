import supportedLocales from '@/config/supported-locales';

const supportedLocalesUtil = {
  getSupportedLocales () {
    const annotatedLocales = [];

    for (const code of Object.keys(supportedLocales)) {
      annotatedLocales.push({
        code,
        name: supportedLocales[code]
      });
    }

    return annotatedLocales;
  },
  supportedLocalesInclude (locale) {
    return Object.keys(supportedLocales).includes(locale);
  }
};

export { supportedLocalesUtil };
