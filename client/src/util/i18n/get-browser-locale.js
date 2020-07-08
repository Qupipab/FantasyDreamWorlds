const getBrowserLocaleUtil = {
  getBrowserLocale (options = {}) {
    const defaultOptions = { countryCodeOnly: false },
          opt = { ...defaultOptions, ...options },
          navigatorLocale = navigator.languages !== undefined
            ? navigator.languages[0]
            : navigator.language,
          trimmedLocale = opt.countryCodeOnly
            ? navigatorLocale.trim().split(/-|_/)[0]
            : navigatorLocale.trim();

    if (!navigatorLocale) {
      return undefined;
    }

    return trimmedLocale;
  }
};

export { getBrowserLocaleUtil };
