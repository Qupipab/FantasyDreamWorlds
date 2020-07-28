import { email, maxLength, minLength, required, sameAs } from 'vuelidate/lib/validators';

const trueCheck = (value) => value === true;

export default {
  name: 'registration',
  data () {
    return {
      login: '',
      email: '',
      password: '',
      repeatPassword: '',
      rulesAccept: false
    };
  },
  validations: {
    login: { required, minLength: minLength(4), maxLength: maxLength(30) },
    email: { required, email },
    password: { required, minLength: minLength(12), maxLength: maxLength(30) },
    repeatPassword: { required, sameAsPassword: sameAs('password') },
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
