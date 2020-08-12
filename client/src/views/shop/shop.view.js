import { FdwSelect } from '@components';
import Magnify from '@icons/Magnify';

export default {
  components: {
    FdwSelect,
    Magnify
  },
  data () {
    return {
      servers: [
        { label: 'Infinity', id: 0 },
        { label: 'Unfinity', id: 1 },
        { label: 'Ozone', id: 2 },
        { label: 'Arcmagic', id: 3 }
      ]
    };
  }
};
