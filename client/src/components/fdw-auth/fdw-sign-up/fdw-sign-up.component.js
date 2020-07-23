/* eslint-disable */
export default {
  data() {
    return {
      form: {
        login: '',
        email: '',
        password: ''
      }
    }
  },
  methods: {
    onSubmit (evt) {
      evt.preventDefault();
    }
  }
}