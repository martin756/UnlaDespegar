<template>
  <div>
    <div class="container">
      <div class="row d-flex justify-content-center mt-3 filtro">
        <div class="col-9">
          <form>
            <div class="form-row p-2">
              <div class="col">
                <b-form-input list="origen" v-model="localOrigen" placeholder="Origen"></b-form-input>
                <datalist id="origen">
                  <select v-model="localOrigen" class="form-control">
                    <option v-for="vuelo in localVuelosOriginal" :key="vuelo.id" :value="vuelo.origen.ciudad">
                      {{ vuelo.origen.region }} </option>
                  </select>
                </datalist>
              </div>
              <div class="col">
                <b-form-input list="destino" v-model="localDestino" placeholder="Destino"></b-form-input>
                <datalist id="destino">
                  <select v-model="localDestino" class="form-control">
                    <option v-for="vueloDestino in localVuelosOriginal" :key="vueloDestino.id"
                      :value="vueloDestino.destino.ciudad">{{ vueloDestino.destino.region }} </option>
                  </select>
                </datalist>
              </div>
              <div class="col">
                <datetime input-class="form-control" format="dd/MM/yyyy T" value-zone="UTC-3" :min-datetime="currentDate"
                  zone="UTC-3" type="datetime" id="fecha-desde" placeholder="Desde" v-model="localFechaDesde" required>
                </datetime>
              </div>
              <div class="col">
                <datetime input-class="form-control" format="yyyy/MM/dd T" value-zone="UTC-3" :min-datetime="currentDate"
                  zone="UTC-3" type="datetime" id="fecha-desde" placeholder="Hasta" v-model="localFechaHasta" required>
                </datetime>
              </div>
              <div class="col">
                <button type="button" class="btn btn-success" @click="submit">Buscar</button>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
    <div v-show="localVueloAgregado" class="alert alert-success" role="alert">
      Vuelo agregado!
    </div>
    <div v-show="localVueloNoAgregado" class="alert alert-danger" role="alert">
      El vuelo no ha sido agregado, por favor intente nuevamente.
    </div>
    <div class="my-3 p-3 rounded container">
      <div>
        <b-card v-for="vuelo in localVuelos" :key="vuelo.id" :img-src="vuelo.link" img-alt="Image" img-top
          class="mb-2 flight">
          <h6>{{ vuelo.origen.ciudad }}, {{ vuelo.origen.region }}, {{ vuelo.origen.pais }} - {{ vuelo.destino.ciudad }},
            {{ vuelo.destino.region }}, {{ vuelo.destino.pais }}</h6>
          <h6>Fecha Ida: {{ vuelo.fechaIda | moment("DD/MM/YYYY LT") }}</h6>
          <h6>Fecha Vuelta: {{ vuelo.fechaVuelta | moment("DD/MM/YYYY LT") }}</h6>
          <h6>{{ vuelo.clase }}</h6>

          <h6>{{ vuelo.nombreAereolinea }} - {{ vuelo.valoracionAereolinea }}</h6>
          <h6 v-if="vuelo.conEscala">Vuelo con escalas</h6>
          <h6 v-if="vuelo.accesoDiscapacitados">Acceso a Discapacitados</h6>
          <h5>${{ vuelo.precio }}</h5>
          <b-button v-if="localAllowedToAddVuelo" @click="agregarVueloAReserva(vuelo)" variant="primary">Agregar a
            Reserva</b-button>
        </b-card>
      </div>
    </div>
  </div>
</template>
 
<script>
export default {
  name: "VistaVuelo",
  props: {
    vuelos: null,
    origen: null,
    destino: null,
    currentDate: new Date(),
    fechaDesde: null,
    fechaHasta: null,
    escala: null,
    directo: null,
    ida: null,
    idaVuelta: null,
    vuelosOriginal: null,
    reservaActiva: null,
    allowedToAddVuelo: {
      type: Boolean,
      default: false
    },
    vueloAgregado: {
      type: Boolean,
      default: false
    },
    vueloNoAgregado: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      selected: [], // Must be an array reference!
      options: [
        { text: '5', value: '5' },
        { text: '4', value: '4' },
        { text: '3', value: '3' },
        { text: '2', value: '2' },
        { text: '1', value: '1' }
      ],
      clasesSeleccionadas: [],
      clases: [
        { text: 'Economica', value: 'Económica' },
        { text: 'Primera clase', value: 'Primera clase' },
        { text: 'Ejecutivo', value: 'Ejecutivo' }
      ],
      localOrigen: this.origen,
      localDestino: this.destino,
      localFechaDesde: this.fechaDesde,
      localFechaHasta: this.fechaHasta,
      localReservaActiva: this.reservaActiva,
      localAllowedToAddVuelo: this.allowedToAddVuelo,
      localVueloAgregado: this.vueloAgregado,
      localVueloNoAgregado: this.vueloNoAgregado,
      localVuelos: this.vuelos,
      localVuelosOriginal: this.vuelosOriginal,
    }
  },
  watch: {
    fechaDesde(newVal) {
      this.localFechaDesde = newVal;
    },
    fechaHasta(newVal) {
      this.localFechaHasta = newVal;
    },
    reservaActiva(newVal) {
      this.localReservaActiva = newVal;
    },
    allowedToAddVuelo(newVal) {
      this.localAllowedToAddVuelo = newVal;
    },
    vueloAgregado(newVal) {
      this.localVueloAgregado = newVal;
    },
    vueloNoAgregado(newVal) {
      this.localVueloNoAgregado = newVal;
    },
    vuelos(newVal) {
      this.localVuelos = newVal;
    },
    vuelosOriginal (newVal) {
      this.localVuelosOriginal = newVal;
    },
  },
  methods: {
    async init() {
      this.$axios
        .get("https://localhost:57935/api/vuelo/destino/" + this.$parent.localDestino)
        .then(response => {
          this.localVuelos = response.data;
          this.localVuelosOriginal = this.localVuelos;
        });
      if (!this.$parent.$parent.localShowReservation) {
        this.$axios
          .get("https://localhost:57935/api/reserva/usuario/" + 1)
          .then(response => {
            this.localAllowedToAddVuelo = true;
            if (response.data.filter(function (reserva) { return !reserva.reservaFinalizada; }).length > 0) {
              this.localReservaActiva = response.data.filter(function (reserva) { return !reserva.reservaFinalizada; })[0];
              this.$parent.$parent.localShowReservation = true;
              this.$parent.$parent.localReserva = this.localReservaActiva;
              if (this.localReservaActiva.vuelo != null) {
                this.localAllowedToAddVuelo = false;
              }
            }
          });
      }
    },
    filtro(vuelo) {
      return (vuelo.origen.ciudad == this.localOrigen || !this.localOrigen) && 
      (vuelo.destino.ciudad == this.localDestino || !this.localDestino) && 
      (vuelo.fechaIda.toString() >= this.localFechaDesde || !this.localFechaDesde) &&
      (vuelo.fechaVuelta.toString() <= this.localFechaHasta || !this.localFechaHasta)
    },
    submit() {
      this.localVuelos = this.localVuelosOriginal;
      this.localVuelos = this.localVuelos.filter(this.filtro);
    },
    agregarVueloAReserva(vuelo) {
      if (this.localReservaActiva == null) {
        this.$axios
          .post('https://localhost:57935/api/reserva', {
            nroReserva: "1",
            usuario: 1,
            destino: this.$parent.localDestino,
            vuelo: vuelo.id,
            importe: vuelo.precio,
            reservaFinalizada: false,
            fechaEntrada: null,
            fechaSalida: null
          }).then(async (response) => {
            if (response.status == 200) {
              this.localAllowedToAddVuelo = false;
              this.localVueloAgregado = true;
              this.localVuelosOriginal = this.localVuelos;
              await this.init();
              setTimeout(() => this.localVueloAgregado = false, 2000)
            }
          }).catch(() => {
            this.localVueloNoAgregado = true;
            setTimeout(() => this.localVueloNoAgregado = false, 2000)
          });
      }
      else {
        this.$axios
          .put('https://localhost:57935/api/reserva/' + this.localReservaActiva.id, {
            id: this.localReservaActiva.id,
            nroReserva: this.localReservaActiva.nroReserva,
            usuario: 1,
            destino: this.localReservaActiva.destino.id,
            vuelo: vuelo.id,
            importe: this.localReservaActiva.importe + vuelo.precio,
            reservaFinalizada: this.localReservaActiva.reservaFinalizada,
            fechaEntrada: null,
            fechaSalida: null
          }).then(async (response) => {
            if (response.status == 200) {
              this.localAllowedToAddVuelo = false;
              this.localVueloAgregado = true;
              await this.init();
              setTimeout(() => this.localVueloAgregado = false, 2000)
            }
          }).catch(() => {
            this.localVueloNoAgregado = true;
            setTimeout(() => this.localVueloNoAgregado = false, 2000)
          });
      }
    }
  },
  async mounted() {
    await this.init();
  }
};
</script>
 
 <!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container,
.alert {
  max-width: 960px;
}

.filtro {
  border-radius: 23px 23px 23px 23px;
  -moz-border-radius: 23px 23px 23px 23px;
  -webkit-border-radius: 23px 23px 23px 23px;
  border: 0px solid #000000;
  background: darkred;
}

.options,
.alert {
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
</style>