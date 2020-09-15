/* eslint-disable */

export default {
  props: ['placeholder', 'options', 'label', 'value', "reduce"],
  data () {
    return {
      isActive: false,
      selected: { title: 'somethin' }
    };
  },
  methods: {
    input (val) {
      this.$emit('input', val);
    }
  }
};
