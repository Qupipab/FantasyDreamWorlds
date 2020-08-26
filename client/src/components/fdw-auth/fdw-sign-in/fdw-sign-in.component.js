import { alphaNum, maxLength, minLength, required } from 'vuelidate/lib/validators';

import { mapActions } from 'vuex';

export default {
  name: 'sign-in',
  data () {
    return {
      login: '',
      password: ''
    };
  },
  validations: {
    login: {
      required,
      alphaNum,
      minLength: minLength(4),
      maxLength: maxLength(30)
    },
    password: {
      required,
      minLength: minLength(12),
      maxLength: maxLength(100)
    }
  },
  methods: {
    ...mapActions([ 'signIn' ]),
    async submitLogin () {
      if (this.$v.$invalid) {
        this.$v.$touch();
        return;
      }

      const loginData = {
        userNameOrEmail: this.login,
        password: this.password
      };

      if (await this.signIn(loginData)) {
        this.modalClose();
      }
    },
    modalClose () {
      this.$bvModal.hide('sign-in-modal');
    }
  }
};
