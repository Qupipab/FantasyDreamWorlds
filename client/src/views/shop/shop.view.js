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
        { title: 'Infinity', id: 0 },
        { title: 'Unfinity', id: 1 },
        { title: 'Ozone', id: 2 },
        { title: 'Arcmagic', id: 3 }
      ]
    };
  }
};
