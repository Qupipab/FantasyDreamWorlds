const path = require('path');

module.exports = {
  transpileDependencies: [
    'vuetify'
  ],
  chainWebpack: config => {
    config.resolve.alias
      .set('@components', path.resolve('src/components/'))
      .set('@views', path.resolve('src/views/'))
      .set('@router', path.resolve('src/router/'))
      .set('@store', path.resolve('src/store/'))
      .set('@layout', path.resolve('src/layouts/'))
      .set('@styles', path.resolve('src/styles/'))
      .set('@locales', path.resolve('src/locales/'))
      .set('@constants', path.resolve('src/constants/'))
      .set('@utils', path.resolve('src/util/'))
  },
  pluginOptions: {
    i18n: {
      locale: 'ru',
      fallbackLocale: 'ru',
      localeDir: 'locales',
      enableInSFC: false
    }
  }
};

// .set('@assets', path.resolve('src/assets/'))
// .set('@filters', path.resolve('src/filters/'))
// .set('@config', path.resolve('src/config/config.dev.json'))
// .set('@api', path.resolve('src/services/api-service.service.js'))

