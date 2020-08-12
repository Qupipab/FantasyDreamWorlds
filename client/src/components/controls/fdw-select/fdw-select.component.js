export default {
  props: ['placeholder', 'options', 'test'],
  data () {
    return {
      isActive: false
    };
  },
  methods: {
    test (val) {
      console.log(val);
    }
  }
};
