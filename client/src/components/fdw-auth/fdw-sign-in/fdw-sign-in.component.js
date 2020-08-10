import { alphaNum, maxLength, minLength, required } from 'vuelidate/lib/validators';
import { haveNum, haveUppercase } from '@services/validators';

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
      maxLength: maxLength(100),
      haveUppercase,
      haveNum
    }
  },
  methods: {
    status (validation) {
      return {
        error: validation.$error,
        dirty: validation.$dirty
      };
    },
    submitHandler () {
      if (this.$v.$invalid) {
        this.$v.$touch();
        return;
      }

      const formData = {
        login: this.login,
        email: this.email,
        password: this.password
      };

      console.log(formData);
    }
  }
};
