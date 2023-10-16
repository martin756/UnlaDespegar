<template>
  <div>
    <div class="container">
      <div class="row d-flex justify-content-center mt-3 filtro">
        <div class="col-12">
          <form>
            <div class="d-flex col-12 p-2 align-items-center" style="gap: 1rem;">
              <div class="col p-0">
                <div class="input-group">
                  <b-form-input list="alojamiento" v-model="localTipoAlojamiento" placeholder="Tipo alojamiento"></b-form-input>
                  <div @click="localTipoAlojamiento = ''" type="button" v-if="localTipoAlojamiento" class="form-control" style="max-width: fit-content;">
                    <div style="background-color: white;">
                      <i class="fas fa-times"></i>
                    </div>
                  </div>
                </div>
                <datalist id="alojamiento">
                  <option v-for="tipoAlojamiento in localTiposAlojamiento" :key="tipoAlojamiento"
                    :value="tipoAlojamiento"></option>
                </datalist>
              </div>
              <div class="col p-0">
                <div class="input-group">
                  <b-form-input list="serv" v-model="localServicio" placeholder="Tipo servicio"></b-form-input>
                  <div @click="localServicio = ''" type="button" v-if="localServicio" class="form-control" style="max-width: fit-content;">
                    <div style="background-color: white;">
                      <i class="fas fa-times"></i>
                    </div>
                  </div>
                </div>
                <datalist id="serv">
                  <option v-for="tipoServicio in localTiposServicios" :key="tipoServicio"
                    :value="tipoServicio"></option>
                </datalist>
              </div>
              <div class="col p-0">
                <div class="input-group">
                  <b-form-input list="regimen" v-model="localRegimen" placeholder="Tipo regimen"></b-form-input>
                  <div @click="localRegimen = ''" type="button" v-if="localRegimen" class="form-control" style="max-width: fit-content;">
                    <div style="background-color: white;">
                      <i class="fas fa-times"></i>
                    </div>
                  </div>
                </div>
                <datalist id="regimen">
                  <option v-for="tipoRegimen in localTiposRegimenes" :key="tipoRegimen"
                    :value="tipoRegimen"></option>
                </datalist>
              </div>
              <div class="col p-0">
                <div class="input-group">
                  <b-form-input list="hab" v-model="localHabitacion" placeholder="Tipo habitacion"></b-form-input>
                  <div @click="localHabitacion = ''" type="button" v-if="localHabitacion" class="form-control" style="max-width: fit-content;">
                    <div style="background-color: white;">
                      <i class="fas fa-times"></i>
                    </div>
                  </div>
                </div>
                <datalist id="hab">
                  <option v-for="tipoHabitacion in localTiposHabitaciones" :key="tipoHabitacion"
                    :value="tipoHabitacion"></option>
                </datalist>
              </div>
              <div class="">
                <button type="button" class="btn btn-success" @click="submit"><i class="fas fa-search"></i> Buscar</button>
              </div>
            </div>
          </form>
        </div>
      </div>
      <div v-if="localAplicarFiltro" class="row d-flex justify-content-end">
        <div class="col-3">
          <b-dropdown id="dropdown-4" text="Cantidad estrellas" class="m-md-2" variant="outline-success">
            <b-dropdown-form>
              <b-form-group label="Estrellas:">
                <b-form-checkbox v-for="option in options" v-model="selected" :key="option.value" :value="option.value"
                  name="flavour-3a" @input="filtrar">
                  {{ option.text }}
                </b-form-checkbox>
              </b-form-group>
            </b-dropdown-form>
          </b-dropdown>
        </div>
      </div>
    </div>
    <div v-show="localAlojamientoAgregado" class="alert alert-success" role="alert">
      Alojamiento agregado!
    </div>
    <div v-show="localAlojamientoNoAgregado" class="alert alert-danger" role="alert">
      El alojamiento no ha sido agregado, por favor intente nuevamente.
    </div>
    <div class="my-3 p-3 rounded container" style="max-width: 1072px;">
      <div v-if="localAplicarFiltro" style="display: flex; flex-wrap: wrap; justify-content: center;">
        <b-card v-for="alojamiento in localAlojamientos" :key="alojamiento.id" :title="alojamiento.nombreAlojamiento"
          :img-src="alojamiento.link"
          img-alt="Image" img-top class="mb-2 flight">
          <h6>{{ alojamiento.destino.ciudad }}, {{ alojamiento.destino.region }}, {{ alojamiento.destino.pais }}</h6>
          <h6>{{ alojamiento.cantidadEstrellas }} estrellas</h6>
          <h6>Tipo: {{ alojamiento.tipoServicio }}</h6>
          <h6>Habitacion: {{ alojamiento.tipoHabitacion }}</h6>
          <h6>Tipo: {{ alojamiento.tipoAlojamiento.descripcion }}</h6>
          <h6>Regimen: {{ alojamiento.tipoRegimen.descripcion }}</h6>
          <h6 v-if="alojamiento.accesoDiscapacitados">Wifi Gratis</h6>
          <h5>${{ alojamiento.precio }}</h5>
          <b-button v-if="!$parent.$parent.localReserva" @click="agregarAlojamientoAReserva(alojamiento)"
            variant="primary">Agregar a Reserva</b-button>
        </b-card>
        <h5 v-if="localAlojamientos && localAlojamientos.length == 0">Sin resultados</h5>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "VistaAlojamiento",
  props: {
    alojamientos: null,
    alojamientosOriginal: null,
    alojamientosConValoracion: null,
    fechaDesde: null,
    fechaHasta: null,
    nombreAlojamiento: null,
    habitacion: null,
    regimen: null,
    servicio: null,
    tipoAlojamiento: null,
    reservaActiva: null,
    aplicarFiltro: {
      type: Boolean,
      default: false
    },
    allowedToAddAlojamiento: {
      type: Boolean,
      default: false
    },
    alojamientoAgregado: {
      type: Boolean,
      default: false
    },
    alojamientoNoAgregado: {
      type: Boolean,
      default: false
    },
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
      localAlojamientos: this.alojamientos,
      localAlojamientosOriginal: this.alojamientosOriginal,
      localAlojamientosConValoracion: this.alojamientosConValoracion,
      localFechaDesde: this.fechaDesde,
      localFechaHasta: this.fechaHasta,
      localNombreAlojamiento: this.nombreAlojamiento,
      localHabitacion: this.habitacion,
      localRegimen: this.regimen,
      localServicio: this.servicio,
      localTipoAlojamiento: this.tipoAlojamiento,
      localReservaActiva: this.reservaActiva,
      localAplicarFiltro: this.aplicarFiltro,
      localAllowedToAddAlojamiento: this.allowedToAddAlojamiento,
      localAlojamientoAgregado: this.alojamientoAgregado,
      localAlojamientoNoAgregado: this.alojamientoNoAgregado,
      localTiposAlojamiento: [],
      localTiposServicios: [],
      localTiposRegimenes: [],
      localTiposHabitaciones: []
    }
  },
  watch: {
    alojamientos(newVal) { this.localAlojamientos = newVal; },
    alojamientosOriginal(newVal) { this.localAlojamientosOriginal = newVal; },
    alojamientosConValoracion(newVal) { this.localAlojamientosConValoracion = newVal; },
    fechaDesde(newVal) { this.localFechaDesde = newVal; },
    fechaHasta(newVal) { this.localFechaHasta = newVal; },
    nombreAlojamiento(newVal) { this.localNombreAlojamiento = newVal; },
    habitacion(newVal) { this.localHabitacion = newVal; },
    regimen(newVal) { this.localRegimen = newVal; },
    servicio(newVal) { this.localServicio = newVal; },
    tipoAlojamiento(newVal) { this.localTipoAlojamiento = newVal; },
    reservaActiva(newVal) { this.localReservaActiva = newVal; },
    aplicarFiltro(newVal) { this.localAplicarFiltro = newVal; },
    allowedToAddAlojamiento(newVal) { this.localAllowedToAddAlojamiento = newVal; },
    alojamientoAgregado(newVal) { this.localAlojamientoAgregado = newVal; },
    alojamientoNoAgregado(newVal) { this.localAlojamientoNoAgregado = newVal; }
  },
  methods: {
    init() {
      if (!this.localAlojamientos) {
        this.$axios
          .get("https://localhost:57935/api/alojamiento/")
          .then(response => {
            this.localAlojamientos = response.data;
            this.localAlojamientosOriginal = this.localAlojamientos;

            for (const alojamiento of this.localAlojamientos) {
              !this.localTiposAlojamiento.includes(alojamiento.tipoAlojamiento.descripcion) &&
                this.localTiposAlojamiento.push(alojamiento.tipoAlojamiento.descripcion);
              
              !this.localTiposServicios.includes(alojamiento.tipoServicio) &&
                this.localTiposServicios.push(alojamiento.tipoServicio);

              !this.localTiposRegimenes.includes(alojamiento.tipoRegimen.descripcion) &&
                this.localTiposRegimenes.push(alojamiento.tipoRegimen.descripcion);

              !this.localTiposHabitaciones.includes(alojamiento.tipoHabitacion) &&
                this.localTiposHabitaciones.push(alojamiento.tipoHabitacion);
            }
          }
        );
      }
      if (this.$parent.$parent.localUsuario) {
        this.$axios
          .get("https://localhost:57935/api/reserva/usuario/" + this.$parent.$parent.localUsuario.Id)
          .then(response => {
            this.localAllowedToAddAlojamiento = true;
            if (response.data.filter(function (reserva) { return !reserva.reservaFinalizada; }).length > 0) {
              this.localReservaActiva = response.data.filter(function (reserva) { return !reserva.reservaFinalizada; })[0];
              this.$parent.$parent.localShowReservation = true;
              this.$parent.$parent.localReserva = this.localReservaActiva;
              if (this.localReservaActiva.alojamiento != null || this.localReservaActiva.esUnPaquete) {
                this.localAllowedToAddAlojamiento = false;
              }
            }
          });
      }
    },
    submit() {
      this.localAplicarFiltro = true;
      this.localAlojamientos = this.localAlojamientosOriginal;
      this.localAlojamientos = this.localAlojamientos.filter(this.filtro);
      this.localAlojamientosConValoracion = this.localAlojamientos;
    },
    filtro(alojamiento) {
      return (alojamiento.tipoServicio == this.localServicio || !this.localServicio) && 
      (alojamiento.tipoRegimen.descripcion == this.localRegimen || !this.localRegimen) &&
      (alojamiento.tipoHabitacion == this.localHabitacion || !this.localHabitacion) && 
      (alojamiento.tipoAlojamiento.descripcion == this.localTipoAlojamiento || !this.localTipoAlojamiento);
    },
    filtrar() {
      this.localAlojamientos = this.localAlojamientosConValoracion;
      if (this.selected.length > 0) {
        this.filtrarPorValoracion();
      }
    },
    filtrarPorValoracion() {
      this.localAlojamientos = this.localAlojamientosOriginal;
      this.localAlojamientos = this.localAlojamientos.filter(aloj => {
        return this.selected.find(select => (select == aloj.cantidadEstrellas)) != undefined;
      })
    },
    ordenarPorValoracion(orden) {
      switch (orden) {
        case 'mayor':
          this.localAlojamientos.sort(function (a, b) { return b.cantidadEstrellas - a.cantidadEstrellas });
          break;
        case 'menor':
          this.localAlojamientos.sort(function (a, b) { return a.cantidadEstrellas - b.cantidadEstrellas });
          break;
      }
    },
    agregarAlojamientoAReserva(alojamiento) {
      if (this.localReservaActiva == null) {
        this.$axios
          .post('https://localhost:57935/api/reserva', {
            nroReserva: "1",
            usuario: this.$parent.$parent.localUsuario.Id,
            destino: alojamiento.destino.id,
            alojamiento: alojamiento.id,
            actividad: null,
            vuelo: null,
            esUnPaquete: false,
            paquete: null,
            importe: alojamiento.precio,
            reservaFinalizada: false,
            fechaEntrada: null,
            fechaSalida: null
          }).then(async (response) => {
            if (response.status == 200) {
              this.localAllowedToAddAlojamiento = false;
              this.localAlojamientoAgregado = true;
              await this.init();
              setTimeout(() => this.localAlojamientoAgregado = false, 2000)
            }
          }).catch(() => {
            this.localAlojamientoNoAgregado = true;
            setTimeout(() => this.localAlojamientoNoAgregado = false, 2000)
          });
      }
      else {
        this.$axios
          .put('https://localhost:57935/api/reserva/' + this.localReservaActiva.id, {
            id: this.localReservaActiva.id,
            nroReserva: this.localReservaActiva.nroReserva,
            usuario: this.localReservaActiva.usuario.id,
            destino: this.localReservaActiva.destino.id,
            alojamiento: alojamiento.id,
            actividad: this.localReservaActiva.actividad,
            vuelo: this.localReservaActiva.vuelo,
            esUnPaquete: this.localReservaActiva.esUnPaquete,
            paquete: this.localReservaActiva.paquete,
            importe: this.localReservaActiva.importe + alojamiento.precio,
            reservaFinalizada: this.localReservaActiva.reservaFinalizada,
            fechaEntrada: null,
            fechaSalida: null
          }).then((response) => {
            if (response.status == 200) {
              this.localAllowedToAddAlojamiento = false;
              this.localAlojamientoAgregado = true;
              setTimeout(() => this.localAlojamientoAgregado = false, 2000)
            }
          }).catch(() => {
            this.localAlojamientoNoAgregado = true;
            setTimeout(() => this.localAlojamientoNoAgregado = false, 2000)
          });
      }
    }
  },
  mounted() {
    this.init();
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

.card-body {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
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
  display: flex;
  max-width: 15rem;
  margin-right: 20px;
}</style>