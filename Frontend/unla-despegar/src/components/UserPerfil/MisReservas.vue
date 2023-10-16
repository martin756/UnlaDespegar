<template>
  <div>
    <div v-if="!localShowAbonarReserva">
      <div v-if="localShowList">
        <h4 v-if="localReservasActivas && localReservasActivas.length == 1" class>Activas</h4>
        <div class="d-flex justify-content-center">
          <b-card v-for="reserva in localReservasActivas" :key="reserva.id" img-alt="Image" img-top class="mb-2 flight">
            <h6>Numero Reserva: {{ reserva.id }}</h6>
            <h6>Destino: {{ reserva.destino.pais }}, {{ reserva.destino.region }}, {{ reserva.destino.ciudad }}</h6>
            <div v-if="reserva.esUnPaquete">
              <h6>NroVuelo: {{ reserva.paquete.vuelo.id }}</h6>
              <h6>Alojamiento: {{ reserva.paquete.alojamiento.nombreAlojamiento }}</h6>
            </div>
            <div v-else>
              <h6 v-if="reserva.vuelo != null">NroVuelo: {{ reserva.vuelo.id }}</h6>
              <h6 v-if="reserva.alojamiento != null">Alojamiento: {{ reserva.alojamiento.nombreAlojamiento }}</h6>
            </div>
            <h5>${{ reserva.importe }}</h5>
            <b-button @click="cargaReserva(reserva)" href="#" variant="primary">Ver Reserva</b-button>
          </b-card>
        </div>
        <h4 v-if="localReservasFinalizadas && localReservasFinalizadas.length > 0">Finalizadas</h4>
        <div class="d-flex justify-content-center">
          <b-card v-for="reserva in localReservasFinalizadas" :key="reserva.id" img-alt="Image" img-top
            class="mb-2 flight">
            <h6>Numero Reserva: {{ reserva.id }}</h6>
            <h6>Destino: {{ reserva.destino.pais }}, {{ reserva.destino.region }}, {{ reserva.destino.ciudad }}</h6>
            <div v-if="reserva.esUnPaquete">
              <h6>NroVuelo: {{ reserva.paquete.vuelo.id }}</h6>
              <h6>Alojamiento: {{ reserva.paquete.alojamiento.nombreAlojamiento }}</h6>
            </div>
            <div v-else>
              <h6 v-if="reserva.vuelo != null">NroVuelo: {{ reserva.vuelo.id }}</h6>
              <h6 v-if="reserva.alojamiento != null">Alojamiento: {{ reserva.alojamiento.nombreAlojamiento }}</h6>
            </div>
            <h5>${{ reserva.importe }}</h5>
            <b-button @click="cargaReserva(reserva)" href="#" variant="primary">Ver Reserva</b-button>
          </b-card>
        </div>
        <br />
        <div class="row">
          <div class="options text-center">
            <button @click="volver" type="button" class="btn btn-lg btn-block btn-primary">Volver</button>
          </div>
        </div>
      </div>
    </div>
    <VistaReserva v-if="localShowDetalle" :reservaSeleccionada="localReservaSeleccionada" :volverFunc="volver" @eliminarReserva="eliminarReserva"/>
    <VistaAbonar v-if="localShowAbonarReserva" />
  </div>
</template>

<script>
import VistaAbonar from '../VistaAbonar.vue';
import VistaReserva from '../VistaReserva.vue';

export default {
  name: "MisReservas",
  props: {
    reservasActivas: [],
    reservasFinalizadas: [],
    reservaSeleccionada: null,
    showList: {
      type: Boolean,
      default: true
    },
    showDetalle: {
      type: Boolean,
      default: false
    },
    showAbonarReserva: {
      type: Boolean,
      default: false
    },
  },
  data() {
    return {
      localReservasActivas: this.reservasActivas,
      localReservasFinalizadas: this.reservaFinalizadas,
      localReservaSeleccionada: this.reservaSeleccionada,
      localShowList: this.showList,
      localShowDetalle: this.showDetalle,
      localShowAbonarReserva: this.showAbonarReserva,
    };
  },
  watch: {
    reservasActivas(newVal) { this.localReservasActivas = newVal; },
    reservasFinalizadas(newVal) { this.localReservasFinalizadas = newVal; },
    reservaSeleccionada(newVal) { this.localReservaSeleccionada = newVal; },
    showList(newVal) { this.localShowList = newVal; },
    showDetalle(newVal) { this.localShowDetalle = newVal; },
    showAbonarReserva(newVal) { this.localShowAbonarReserva = newVal; },
  },
  methods: {
    volver() {
      this.$parent.cargaMenu();
    },
    cargaReserva(reserva) {
      this.localShowList = false;
      this.localReservaSeleccionada = reserva;
      this.localShowDetalle = true;
    },
    eliminarReserva() {
      this.$parent.$parent.localReserva = null;
    },
    init() {
      this.$axios
        .get("https://localhost:57935/api/reserva/usuario/" +
          this.$parent.localCurrentUser[0].id)
        .then(response => {
          this.localReservas = response.data;
          this.localReservasActivas = this.localReservas.filter(function (reserva) {
            return !reserva.reservaFinalizada;
          });
          this.localReservasFinalizadas = this.localReservas.filter(function (reserva) {
            return reserva.reservaFinalizada;
          });
        });
    }
  },
  mounted() {
    this.init();
  },
  components: { VistaAbonar, VistaReserva }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
  max-width: 1500px;
}

.fondo {
  border-radius: 23px 23px 23px 23px;
  -moz-border-radius: 23px 23px 23px 23px;
  -webkit-border-radius: 23px 23px 23px 23px;
  border: 0px solid #000000;
  background: darkred;
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

.color-red {
  color: red;
}

.bv-example-row {
  max-height: 300px;
}

.flight {
  display: inline-block;
  max-width: 15rem;
  margin-right: 20px;
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
</style>