<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand nav-item nav-link" @click="cargaHome" href="#">UNLADespegar</a>
      <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
        <ul id="navbar-options" class="navbar-nav ml-auto">
          <li class="nav-item">
            <a class="nav-link" @click="cargaHome" href="#"><i class="fas fa-globe-americas"></i> Destinos</a>
          </li>
          <li class="nav-item" v-if="localShowReservation">
            <a class="nav-link" @click="cargaReserva" href="#"><i class="fas fa-umbrella-beach"></i> Ver Reserva</a>
          </li>
        </ul>
      </div>
    </nav>
    <div class="py-5 text-center">
        <img class="d-block mx-auto mb-4" src="./assets/unlaLogo.jpg" alt="" width="72" height="72">  
    </div>
    <Home v-if="localShowHome" ref="home"/>
    <VistaReserva v-if="localShowReserva"/>
  </div>
</template>

<script>
import Home from "./components/Home.vue";
import VistaReserva from "./components/VistaReserva.vue";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";
export default {
  name: "App",
  components: {
    Home,
    VistaReserva
  },
  props: {
    showHome: {
        type: Boolean,
        default: true
    },
    reserva: null,
    showReservation: {
      type: Boolean,
      default: false
    },
    showReserva: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      localShowHome: this.showHome,
      localReserva: this.reserva,
      localShowReservation: this.showReservation,
      localShowReserva: this.showReserva,
    }
  },
  watch: {
    showHome(newVal) {
      this.localShowHome = newVal;
    },
    reserva(newVal) {
      this.localReserva = newVal;
    },
    showReservation(newVal) {
      this.localShowReservation = newVal;
    },
    showReserva(newVal) {
      this.localShowReserva = newVal;
    }
  },
  methods: {
    cargaHome() {
      this.localShowHome = true;
      this.localShowReserva = false;
      this.$refs.home.init();
    },
    cargaReserva(){
      this.localShowHome = false;
      this.localShowReserva = true; 
    },
    init() {
      this.cargaHome();
      this.$axios
      .get("https://localhost:57935/api/reserva/usuario/" + 1)
      .then(response => {
        if(response.data.filter(function(reserva) {return reserva.reservaFinalizada == false;}).length > 0){
          this.localReserva = response.data.filter(function(reserva) {return reserva.reservaFinalizada == false;})[0];
          this.localShowReservation = true;
        }
      });
    }
  },
  mounted() {
    this.init();
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.navbar {
  padding: 0 !important;
}
.navbar-brand {
  margin-right: 0 !important;
  color: white !important;
}
.navbar-collapse, .navbar-brand {
  background-color: darkred;
}
.navbar-light .navbar-nav .nav-link, .fas {
  color: white !important;
}
</style>

