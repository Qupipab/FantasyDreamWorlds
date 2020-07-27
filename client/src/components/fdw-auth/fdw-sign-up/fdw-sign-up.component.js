import { minLength, required } from 'vuelidate/lib/validators';

// const touchMap = new WeakMap();

export default {
  name: 'registration',
  data () {
    return {
      text: '',
      login: ''
    };
  },
  validations: {
    text: {
      required,
      minLength: minLength(5)
    },
    login: {
      required,
      minLength: minLength(5)
    }
  },
  methods: {
    status (validation) {
      return {
        error: validation.$error,
        dirty: validation.$dirty
      };
    }
  }
};
