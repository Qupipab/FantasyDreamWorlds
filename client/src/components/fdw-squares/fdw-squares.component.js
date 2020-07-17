
export default {
  props: {
    width: {
      type: String,
      required: false,
      default: '100%'
    },
    height: {
      type: String,
      required: false,
      default: '100%'
    },
    position: {
      type: String,
      required: false,
      default: 'left'
    },
    distance: {
      type: String,
      required: false,
      default: '0'
    },
    minSize: {
      type: Number,
      required: false,
      default: 20
    },
    maxSize: {
      type: Number,
      required: false,
      default: 40
    },
    count: {
      type: Number,
      required: false,
      default: 10
    },
    opacity: {
      type: Number,
      required: false,
      default: 0
    }
  },
  components: {},
  computed: {
    squareStyle () {
      return this.setSquaresStyle();
    },
    squaresStyle () {
      return `width: ${this.width};
              height: ${this.height};
              ${this.position}: ${this.distance};`;
    }
  },
  methods: {
    getRandomInt (min, max) {
      min = Math.ceil(min);
      max = Math.floor(max);
      return Math.floor(Math.random() * (max - min)) + min;
    },
    setSquaresStyle () {
      const arr = [];
      for (let i = 0; i < this.count; i++) {
        const size = this.getRandomInt(this.minSize, this.maxSize),
              position = this.getRandomInt(5, 95),
              delay = this.getRandomInt(1, 5),
              duration = this.getRandomInt(10, 40);

        arr.push(`width: ${size}px;
                  height: ${size}px;
                  left: ${position}%;
                  animation-delay: ${delay}s;
                  animation-duration: ${duration}s;
                  bottom: -${this.maxSize}px;
                  --base-opacity: ${this.opacity};`);
      }
      return arr;
    }
  },
  data () {
    return {};
  },
  mounted () {

  }
};

// props

// squares
// width
// height
// left/right

// left: 0;
// width: 100%;
// height: 500px;
