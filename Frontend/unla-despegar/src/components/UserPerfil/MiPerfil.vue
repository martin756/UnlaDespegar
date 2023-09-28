<template>
  <div>
    <div v-if="localShowMenu" class="text-center">
      <h4 class="mb-3">Mi Perfil</h4>
      <div showMenu class="row">
        <div class="options text-center">
          <button @click="cargaEditarPerfil" type="button" class="btn btn-lg btn-block btn-primary">
            Editar mis Datos
          </button>
          <!-- <button @click="cargaMisReservas" type="button" class="btn btn-lg btn-block btn-primary">
            Mis Reservas
          </button> -->
          <button @click="volver" type="button" class="btn btn-lg btn-block btn-primary">
            Volver
          </button>
        </div>
      </div>
    </div>
    <EditarPerfil v-if="localShowEditarPerfil" />
    <MisReservas v-if="localShowMisReservas" />
    <br>
  </div>
</template>

<script>
import EditarPerfil from "./EditarPerfil.vue";
import MisReservas from "./MisReservas.vue";

export default {
  name: "MiPerfil",
  components: {
    EditarPerfil,
    MisReservas
  },
  props: {
    showMenu: {
      type: Boolean,
      default: true
    },
    showEditarPerfil: {
      type: Boolean,
      default: false
    },
    showMisReservas: {
      type: Boolean,
      default: false
    },
    current_user: null
  },
  data() {
    return {
      localShowMenu: this.showMenu,
      localShowEditarPerfil: this.showEditarPerfil,
      localShowMisReservas: this.showMisReservas,
      localCurrentUser: this.current_user
    }
  },
  watch: {
    showMenu(newVal) {this.localShowMenu = newVal; },
    showEditarPerfil(newVal) { this.localShowEditarPerfil = newVal; },
    showMisReservas(newVal) { this.localShowMisReservas = newVal; },
    current_user(newVal) { this.localCurrentUser = newVal; }
  },
  methods: {
    volver() {
      this.$parent.cargaHome();
    },
    cargaEditarPerfil() {
      if (this.localCurrentUser) {
        this.localShowMenu = false
        this.localShowEditarPerfil = true
        this.localShowMisReservas = false
      }
    },
    cargaMenu() {
      this.localShowMenu = true
      this.localShowEditarPerfil = false
      this.localShowMisReservas = false
    },
    cargaMisReservas() {
      this.localShowMenu = false
      this.localShowEditarPerfil = false
      this.localShowMisReservas = true
    },
    init() {
      this.$axios
        .get("https://localhost:57935/api/usuario/" + this.$parent.localUsuario.Id)
        .then(response => (this.localCurrentUser = [response.data]));
    },
  },
  mounted() {
    this.init();
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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

.btn-primary {
  color: #fff;
  background-color: darkred;
  border-color: black;
}
</style>