import { alphaNum, email, maxLength, minLength, required, sameAs } from 'vuelidate/lib/validators';
import { haveNum, haveUppercase, trueCheck } from '@services/validators';

import { mapActions } from 'vuex';
import validConfig from '@/config/config.validation.json';

const touchMap = new WeakMap();

export default {
  name: 'sign-up',
  data () {
    return {
      login: '',
      email: '',
      password: '',
      confirmPassword: '',
      rulesAccept: false
    };
  },
  validations: {
    login: {
      required,
      alphaNum,
      minLength: minLength(validConfig.login.minLength),
      maxLength: maxLength(validConfig.login.maxLength),
      async isUnique (value) {
        if (value === '') {
          return true;
        };

        if (this.$v.login.$dirty
            && this.$v.login.alphaNum
            && this.$v.login.minLength
            && this.$v.login.maxLength) {
          return this.CheckByUserName(value);
        }
      }
    },
    email: {
      required,
      email
    },
    password: {
      required,
      minLength: minLength(validConfig.password.minLength),
      maxLength: maxLength(validConfig.password.maxLength),
      haveUppercase,
      haveNum
    },
    confirmPassword: {
      required,
      sameAsPassword: sameAs('password')
    },
    rulesAccept: { trueCheck }
  },
  methods: {
    ...mapActions(['signUp', 'CheckByUserName']),
    submit () {
      if (this.$v.$invalid) {
        this.$v.$touch();
        return;
      }

      const formData = {
        userName: this.login,
        email: this.email,
        password: this.password
      };

      this.signUp(formData);
    },
    delayTouch ($v) {
      $v.$reset();
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v));
      }
      touchMap.set($v, setTimeout($v.$touch, 500));
    }
  }
};
