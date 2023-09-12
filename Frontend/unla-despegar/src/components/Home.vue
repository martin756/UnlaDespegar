<template>
 <div>
    <VistaVuelo v-if="localShowVuelos"/>
 </div>
</template>

<script>
import VistaVuelo from './VistaVuelo.vue'

export default {
  name: "Home",
  components: {
    VistaVuelo,
  },
  props: {
    destinos: null,
    destino: null,
    activeSearch: {
      type: Boolean,
      default: false
    },
    showVuelos: {
      type: Boolean,
      default: true
    },
    current_destino: null
  },
  data() {
    return {
      localDestinos: this.destinos,
      localDestino: this.destino,
      localActiveSearch: this.activeSearch,
      localShowVuelos: this.showVuelos,
      localCurrentDestino: this.current_destino,
    }
  },
  watch: {
    destinos(newVal) {
      this.localDestinos = newVal;
    },
    destino(newVal) {
      this.localDestino = newVal;
    },
    activeSearch(newVal) {
      this.localActiveSearch = newVal;
    },
    showVuelos(newVal) {
      this.localShowVuelos = newVal;
    },
    current_destino(newVal) {
      this.localCurrentDestino = newVal;
    }
  },
  methods: {
    init() {
    },
    search(){
      this.localActiveSearch = true;
      // this.localShowVuelos = true;
      this.localCurrentDestino = this.localDestinos[this.localDestino-1].ciudad +", " + this.localDestinos[this.localDestino-1].region + ", " + this.localDestinos[this.localDestino-1].pais
    },
    cargaVuelos(){
      // this.localShowVuelos = true;
    },
    cargaDestinos(){
      // this.localShowVuelos = false;
      this.localActiveSearch = false;
    }
  },
  mounted() {
    this.init();
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
  max-width: 960px;
}
.options {
  margin: auto;
}
.border-top {
  border-top: 1px solid #e5e5e5;
}
.border-bottom {
  border-bottom: 1px solid #e5e5e5;
}
.border-top-gray {
  border-top-color: #adb5bd;
}
.box-shadow {
  box-shadow: 0 0.25rem 0.75rem rgba(0, 0, 0, 0.05);
}
.lh-condensed {
  line-height: 1.25;
}
.color-red{
  color: red;
}
.bv-example-row{
  color: white;
}
.fas{
  color: white;
}
.btn-primary {
    color: #fff;
    background-color: darkred;
    border-color: black;
}
.destination {
  color: black;
  margin: auto;
}
</style>