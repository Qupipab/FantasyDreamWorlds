import { FdwSidebar } from '@components';

export default {
  components: {
    FdwSidebar
  },
  computed: {},
  data () {
    return {
      checkedRulesGroupIndex: ''
    };
  },
  methods: {
    viewRules (i) {
      this.checkedRulesGroupIndex = this.checkedRulesGroupIndex === i ? '' : i;
    }
  },
  mounted () {}
};
