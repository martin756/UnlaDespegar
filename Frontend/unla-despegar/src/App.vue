<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light no-print">
      <a class="navbar-brand nav-item nav-link" @click="cargaHome" href="#">UNLaDespegar</a>
      <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
        <ul id="navbar-options" class="navbar-nav ml-auto">
          <li class="nav-item" v-if="localShowTravels">
            <a class="nav-link" v-if="localUserLogged" @click="cargaMiperfil" href="#"><i class="fas fa-user-alt"></i> {{localUsuario.Nombre}} {{localUsuario.Apellido}}</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="cargaLogin" v-if="!localUserLogged" href="#"><i class="fas fa-user-friends"></i> Iniciar Sesión</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="cargaRegistro" v-if="!localUserLogged" href="#"><i class="fas fa-envelope"></i> Registrarse</a>
          </li>
          <li class="nav-item" v-if="localShowReservation">
            <a class="nav-link" @click="cargaReserva" href="#"><i class="fas fa-umbrella-beach"></i> Ver Reserva</a>
          </li>
          <li class="nav-item" v-if="localUserLogged">
            <a class="nav-link" @click="logout" href="#"><i class="fas fa-sign-out-alt"></i> Cerrar Sesión</a>
          </li>
        </ul>
      </div>
    </nav>
    <div class="py-5 text-center no-print">
        <img class="d-block mx-auto mb-4" src="./assets/unlaLogo.jpg" alt="" width="72" height="72">  
    </div>
    <Login v-if="localShowLogin"/>
    <Registro v-if="localShowRegistro"/>
    <Home v-if="localShowHome" ref="home"/>
    <MiPerfil v-if="localShowPerfil"/>
    <VistaReserva v-if="localShowReserva"/>
  </div>
</template>

<script>
import Registro from "./components/Registro.vue";
import Login from "./components/Login.vue";
import Home from "./components/Home.vue";
import MiPerfil from "./components/UserPerfil/MiPerfil.vue";
import VistaReserva from "./components/VistaReserva.vue";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";

export default {
  name: "App",
  components: {
    Registro,
    Login,
    Home,
    MiPerfil,
    VistaReserva
},
  props: {
    showHome: {
        type: Boolean,
        default: true
    },
    showLogin: {
        type: Boolean,
        default: false
    },
    showRegistro: {
        type: Boolean,
        default: false
    },
    showPerfil: {
        type: Boolean,
        default: false
    },
    usuario: null,
    reserva: null,
    userLogged: {
        type: Boolean,
        default: false
    },
    showTravels: {
      type: Boolean,
      default: false
    },
    showReservation: {
      type: Boolean,
      default: false
    },
    showReserva: {
      type: Boolean,
      default: false
    },
    showAbonar: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      localShowHome: this.showHome,
      localShowLogin: this.showLogin,
      localShowRegistro: this.showRegistro,
      localShowPerfil: this.showPerfil,
      localUsuario: this.usuario,
      localReserva: this.reserva,
      localUserLogged: this.userLogged,
      localShowTravels: this.showTravels,
      localShowReservation: this.showReservation,
      localShowReserva: this.showReserva,
      localShowAbonar: this.showAbonar,
    }
  },
  watch: {
    showHome(newVal) {
      this.localShowHome = newVal;
    },
    showLogin(newVal) {
      this.localShowLogin = newVal;
    },
    showRegistro(newVal) {
      this.localShowRegistro = newVal;
    },
    showPerfil(newVal) {
      this.localShowPerfil = newVal;
    },
    usuario(newVal) {
      this.localUsuario = newVal;
    },
    reserva(newVal) {
      this.localReserva = newVal;
    },
    userLogged(newVal) {
      this.localUserLogged = newVal;
    },
    showTravels(newVal) {
      this.localShowTravels = newVal;
    },
    showReservation(newVal) {
      this.localShowReservation = newVal;
    },
    showReserva(newVal) {
      this.localShowReserva = newVal;
    },
    showAbonar(newVal) {
      this.localShowAbonar = newVal;
    }
  },
  methods: {
    cargaLogin() {
      this.localShowLogin = true;
      this.localShowRegistro = false;
      this.localShowHome = false;
      this.localShowPerfil = false;
      this.localShowReserva = false;
      this.localShowAbonar = false;
    },
    cargaRegistro() {
      this.localShowRegistro = true;
      this.localShowLogin = false;
      this.localShowHome = false;
      this.localShowPerfil = false;
      this.localShowReserva = false;
      this.localShowAbonar = false;
    },
    cargaHome() {
      this.localShowLogin = false;
      this.localShowRegistro = false;
      this.localShowHome = true;
      this.localShowPerfil = false;
      this.localShowReserva = false;
      this.localShowAbonar = false;
      // this.$refs.home.init();
    },
    cargaMiperfil() {
      this.localShowLogin = false;
      this.localShowRegistro = false;
      this.localShowHome = false;
      this.localShowPerfil = true;
      this.localShowReserva = false;
      this.localShowAbonar = false;
    },
    cargaReserva(){
      this.localShowLogin = false;
      this.localShowRegistro = false;
      this.localShowHome = false;
      this.localShowPerfil = false;
      this.localShowReserva = true;
      this.localShowAbonar = false; 
    },
    init() {
      const token = localStorage.getItem('token');
      if (token) {
        this.localUsuario = JSON.parse(JSON.parse(atob(token.split(".")[1])).UserData);
        this.localUserLogged = true;
        this.cargaHome();
        this.localShowTravels = true;
        this.$axios
          .get("https://localhost:57935/api/reserva/usuario/" + this.localUsuario.Id)
          .then(response => {
            if(response.data.filter(function(reserva) {return !reserva.reservaFinalizada;}).length > 0){
              this.localReserva = response.data.filter(function(reserva) {return !reserva.reservaFinalizada;})[0];
              this.localShowReservation = true;
            }
          });
      } else {
        this.localUsuario = null;
        this.localUserLogged = false;
        this.localShowTravels = false;
        this.localShowReservation = false;
        this.cargaHome();
      }
    },
    logout() {
      this.$refs.home.$refs.vuelo.localAllowedToAddVuelo = false;
      localStorage.removeItem('token');
      this.init();
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
@media print {
  .no-print {
    display: none !important;
  }
}
</style>

