<template>
  <div>
    <b-container class="bv-example-row">
      <b-row>
        <b-col>
          <button @click="cargaVuelos" class="btn btn-primary"><i class="fas fa-plane"></i> Vuelos</button>
        </b-col>
        <b-col>
          <button @click="cargaAlojamientos" class="btn btn-primary"><i class="fas fa-hotel"></i> Alojamientos</button>
        </b-col>
      </b-row>
    </b-container>
    <VistaVuelo v-if="localShowVuelos" ref="vuelo"/>
    <VistaAlojamiento v-if="localShowAlojamientos" />
 </div>
</template>

<script>
import VistaVuelo from './VistaVuelo.vue'
import VistaAlojamiento from './VistaAlojamiento.vue'

export default {
  name: "Home",
  components: {
    VistaVuelo,
    VistaAlojamiento
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
    showAlojamientos: {
      type: Boolean,
      default: false
    },
    current_destino: null
  },
  data() {
    return {
      localDestinos: this.destinos,
      localDestino: this.destino,
      localActiveSearch: this.activeSearch,
      localShowVuelos: this.showVuelos,
      localShowAlojamientos: this.showVuelos,
      localCurrentDestino: this.current_destino,
    }
  },
  watch: {
    destinos(newVal) { this.localDestinos = newVal; },
    destino(newVal) { this.localDestino = newVal; },
    activeSearch(newVal) { this.localActiveSearch = newVal; },
    showVuelos(newVal) { this.localShowVuelos = newVal; },
    showAlojamientos(newVal) { this.localShowAlojamientos = newVal; },
    current_destino(newVal) { this.localCurrentDestino = newVal; }
  },
  methods: {
    init() {
      this.cargaVuelos();
    },
    cargaVuelos() {
      this.localShowVuelos = true;
      this.localShowAlojamientos = false;
    },
    cargaAlojamientos() {
      this.localShowVuelos = false;
      this.localShowAlojamientos = true;
    },
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
.btn-primary:hover {
  background-color: #8b0000b3;
  border-color: #cc0000;
}
.btn-primary:not(:disabled):not(.disabled):active {
  background-color: #8b0000b3;
  border-color: #cc0000;
}
.btn-primary:focus {
  background-color: #8b0000b3;
  border-color: #cc000093;
  box-shadow: 0 0 0 0.2rem rgba(255, 38, 38, 0.5);
}
.destination {
  color: black;
  margin: auto;
}
</style>