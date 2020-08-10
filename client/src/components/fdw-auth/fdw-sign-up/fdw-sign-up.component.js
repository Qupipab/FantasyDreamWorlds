import { alphaNum, email, maxLength, minLength, required, sameAs } from 'vuelidate/lib/validators';
import { haveNum, haveUppercase, trueCheck } from '@services/validators';

export default {
  name: 'registration',
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
      minLength: minLength(4),
      maxLength: maxLength(30)
    },
    email: {
      required,
      email
    },
    password: {
      required,
      minLength: minLength(12),
      maxLength: maxLength(100),
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
