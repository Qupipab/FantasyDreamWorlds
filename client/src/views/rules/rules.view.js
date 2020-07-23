export default {
  data () {
    return {
      checkedRulesGroupIndex: ''
    };
  },
  methods: {
    viewRules (i) {
      this.checkedRulesGroupIndex = this.checkedRulesGroupIndex === i ? '' : i;
    }
  }
};
