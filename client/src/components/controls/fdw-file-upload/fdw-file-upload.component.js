import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

export default {
  props: {
    title: {
      type: String,
      default: 'Выберите файл'
    }
  },
  data () {
    return {
      fileName: ''
    };
  },
  components: {
    FontAwesomeIcon
  },
  methods: {
    onChange (event) {
      this.fileName = event.target.files[0].name;
      this.$emit('change', event.target);
    }
  }
};
