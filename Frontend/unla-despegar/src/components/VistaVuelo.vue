<template>
  <div>
    <div class="container">
      <div class="row d-flex justify-content-center mt-3 filtro">
        <div class="col-12">
          <form>
            <div class="form-row p-2 justify-content-center">
              <div class="col-2">
                <input class="form-check-input" type="checkbox" v-model="localIdaVuelta" @change="()=>{if(!this.localIdaVuelta){this.localIdaVuelta = undefined} this.localIda = false}" name="inlineRadioOptions"
                  id="inlineRadio1">
                <label class="form-check-label" for="inlineRadio1" style="color:white;">Ida y vuelta</label>
              </div>
              <div class="col-3">
                <input class="form-check-input" type="checkbox" v-model="localIda" @change="()=>{this.localIda ? this.localIdaVuelta = false : this.localIdaVuelta = undefined}" name="inlineRadioOptions"
                  id="inlineRadio2">
                <label class="form-check-label" for="inlineRadio2" style="color:white;">Ida</label>
              </div>
              <div class="col-2">
                <input class="form-check-input" type="checkbox" v-model="localDirecto" @change="()=>{this.localDirecto ? this.localEscala = false : this.localEscala = undefined}" name="escalaOptions"
                  id="escalaRadio1">
                <label class="form-check-label" for="escalaRadio1" style="color:white;">Directo</label>
              </div>
              <div class="col-3">
                <input class="form-check-input" type="checkbox" v-model="localEscala" @change="()=>{if(!this.localEscala){this.localEscala = undefined} this.localDirecto = false}" name="escalaOptions"
                  id="escalaRadio2">
                <label class="form-check-label" for="escalaRadio2" style="color:white;">Con escala</label>
              </div>
            </div>
            <div class="d-flex col-12 p-2 align-items-center" style="gap: 1rem;">
              <div class="col p-0">
                <div class="input-group">
                  <b-form-input list="origen" v-model="localOrigen" placeholder="Origen"></b-form-input>
                  <div @click="localOrigen = ''" type="button" v-if="localOrigen" class="form-control" style="max-width: fit-content;">
                    <div style="background-color: white;">
                      <i class="fas fa-times"></i>
                    </div>
                  </div>
                </div>
                <datalist id="origen">
                  <option v-for="vueloOrigen in localListaDestinos" :key="vueloOrigen.id" :value="vueloOrigen.ciudad">
                    {{ vueloOrigen.region }}.</option>
                </datalist>
              </div>
              <div class="col p-0">
                <div class="input-group">
                  <b-form-input list="destino" v-model="localDestino" placeholder="Destino"></b-form-input>
                  <div @click="localDestino = ''" type="button" v-if="localDestino" class="form-control" style="max-width: fit-content;">
                    <div style="background-color: white;">
                      <i class="fas fa-times"></i>
                    </div>
                  </div>
                </div>
                <datalist id="destino">
                  <option v-for="vueloDestino in localListaDestinos" :key="vueloDestino.id"
                    :value="vueloDestino.ciudad">{{ vueloDestino.region }}.</option>
                </datalist>
              </div>
              <div class="col p-0" style="text-align: start;">
                <b-form-datepicker
                  id="Desde"
                  placeholder="Desde"
                  :min="new Date()"
                  v-model="localFechaDesde"
                  :date-format-options="{ year: 'numeric', month: 'short', day: '2-digit' }"
                  locale="es-ES"
                ></b-form-datepicker>
              </div>
              <div class="col p-0" style="text-align: start;">
                <b-form-datepicker
                  id="Hasta"
                  placeholder="Hasta"
                  :min="localFechaDesde"
                  :disabled="!localFechaDesde"
                  v-model="localFechaHasta"
                  :date-format-options="{ year: 'numeric', month: 'short', day: '2-digit' }"
                  locale="es-ES"
                ></b-form-datepicker>
              </div>
              <div class="">
                <button type="button" class="btn btn-success" @click="submit"><i class="fas fa-search"></i> Buscar</button>
              </div>
            </div>
          </form>
        </div>
      </div>
      <div v-if="localAplicarFiltro" class="row justify-content-end align-items-center">
        <div>$ 0</div>
        <div class="col-3">Precio
          <b-form-input type="range" min="0" :max="localPrecioMaximo" v-model="localPrecio" 
          step="10" class="slider" @change="filtrar"></b-form-input>
        </div>
        <div style="min-width: 60px;">$ {{ localPrecio }}</div>
        <div class="col-2">
          <b-dropdown id="dropdown-1" text="Valoracion" class="m-md-2" variant="outline-success">
            <b-dropdown-form>
              <b-form-group label="Estrellas:">
                <b-form-checkbox v-for="option in options" v-model="localSelected" :key="option.value" :value="option.value"
                  name="flavour-3a" @input="filtrar">
                  {{ option.text }}
                </b-form-checkbox>
              </b-form-group>
            </b-dropdown-form>
          </b-dropdown>
        </div>
        <div class="col-2">
          <b-dropdown id="dropdown-2" text="Clase" class="m-md-2" variant="outline-success">
            <b-dropdown-form>
              <b-form-group label="Selecciona las clases:">
                <b-form-checkbox v-for="clase in clases" v-model="localClasesSeleccionadas" :key="clase.value"
                  :value="clase.value" name="clases" @input="filtrar">
                  {{ clase.text }}
                </b-form-checkbox>
              </b-form-group>
            </b-dropdown-form>
          </b-dropdown>
        </div>
      </div>  
    </div>
    <div v-show="localVueloAgregado" class="alert alert-success" role="alert">
      Vuelo agregado!
    </div>
    <div v-show="localVueloNoAgregado" class="alert alert-danger" role="alert">
      El vuelo no ha sido agregado, por favor intente nuevamente.
    </div>
    <div class="my-3 p-3 rounded container-lg">
      <table v-show="localAplicarFiltro" aria-describedby="vueloTable" class="table">
        <thead>
          <tr>
            <th @click="ordenar('nombreAerolinea')">Aerolínea <i :class="iconoOrden('nombreAerolinea')"></i></th>
            <th @click="ordenar('origen.ciudad')">Origen <i :class="iconoOrden('origen.ciudad')"></i></th>
            <th @click="ordenar('destino.ciudad')">Destino <i :class="iconoOrden('destino.ciudad')"></i></th>
            <th @click="ordenar('fechaIda')">Fecha de ida <i :class="iconoOrden('fechaIda')"></i></th>
            <th @click="ordenar('fechaVuelta')">Fecha de vuelta <i :class="iconoOrden('fechaVuelta')"></i></th>
            <th @click="ordenar('clase')">Clase <i :class="iconoOrden('clase')"></i></th>
            <th @click="ordenar('conEscala')">Con Escala <i :class="iconoOrden('conEscala')"></i></th>
            <th @click="ordenar('precio')">Precio <i :class="iconoOrden('precio')"></i></th>
            <th @click="ordenar('valoracionAerolinea')">Valoración de Aerolínea <i :class="iconoOrden('valoracionAerolinea')"></i></th>
            <th v-if="!$parent.$parent.localReserva && localAllowedToAddVuelo" style="min-width: 185px;"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="vuelo in localVuelos" :key="vuelo.id">
            <td><img :src="vuelo.link" alt="icon"/> {{ vuelo.nombreAerolinea }}</td>
            <td>{{ vuelo.origen.pais }}, {{ vuelo.origen.region }}, {{ vuelo.origen.ciudad }}</td>
            <td>{{ vuelo.destino.pais }}, {{ vuelo.destino.region }}, {{ vuelo.destino.ciudad }}</td>
            <td>{{ new Date(vuelo.fechaIda).toLocaleString() }}</td>
            <td>{{ new Date(vuelo.fechaVuelta).toLocaleString() }}</td>
            <td>{{ vuelo.clase }}</td>
            <td>{{ vuelo.conEscala ? "Sí" : "No" }}</td>
            <td>{{ vuelo.precio }}</td>
            <td>{{ vuelo.valoracionAerolinea }}</td>
            <td v-if="!$parent.$parent.localReserva && localAllowedToAddVuelo">
              <b-button @click="agregarVueloAReserva(vuelo)" variant="primary" class="btn btn-primary">
                Agregar a Reserva
              </b-button>
            </td>
          </tr>
        </tbody>
      </table>
      <h5 v-if="localVuelos && localVuelos.length == 0">Sin resultados</h5>
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
    precio: null,
    precioMaximo: null,
    currentDate: new Date(),
    fechaDesde: null,
    fechaHasta: null,
    escala: null,
    directo: null,
    ida: null,
    idaVuelta: null,
    vuelosOriginal: null,
    vuelosConValoracionYClase: null,
    listaDestinos: null,
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
    },
    aplicarFiltro: {
      type: Boolean,
      default: false
    },
    selected: [],
    clasesSeleccionadas: []
  },
  data() {
    return {
      localSelected: [], // Must be an array reference!
      options: [
        { text: '5', value: '5' },
        { text: '4', value: '4' },
        { text: '3', value: '3' },
        { text: '2', value: '2' },
        { text: '1', value: '1' }
      ],
      localClasesSeleccionadas: [],
      clases: [
        { text: 'Economica', value: 'Económica' },
        { text: 'Primera clase', value: 'Primera Clase' },
        { text: 'Ejecutivo', value: 'Ejecutivo' }
      ],
      localPrecio: this.precioMaximo,
      localOrigen: this.origen,
      localDestino: this.destino,
      localFechaDesde: this.fechaDesde,
      localFechaHasta: this.fechaHasta,
      localIda: this.ida,
      localIdaVuelta: this.idaVuelta,
      localEscala: this.escala,
      localDirecto: this.directo,
      localPrecioMaximo: this.precioMaximo,
      localReservaActiva: this.reservaActiva,
      localAllowedToAddVuelo: this.allowedToAddVuelo,
      localVueloAgregado: this.vueloAgregado,
      localVueloNoAgregado: this.vueloNoAgregado,
      localVuelos: this.vuelos,
      localVuelosOriginal: this.vuelosOriginal,
      localVuelosConValoracionYClase: this.vuelosConValoracionYClase,
      localListaDestinos: this.listaDestinos,
      localAplicarFiltro: this.aplicarFiltro,
      columnOrden: "",
      ordenAscendente: true
    }
  },
  watch: {
    fechaDesde(newVal) {
      this.localFechaDesde = newVal;
    },
    fechaHasta(newVal) {
      this.localFechaHasta = newVal;
    },
    precio(newVal) {
      this.localPrecio = newVal;
    },
    ida(newVal) {
      this.localIda = newVal;
    },
    idaVuelta(newVal) {
      this.localIdaVuelta = newVal;
    },
    escala(newVal) {
      this.localEscala = newVal;
    },
    directo(newVal) {
      this.localDirecto = newVal;
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
    vuelosConValoracionYClase(newVal) {
      this.localVuelosConValoracionYClase = newVal;
    }
  },
  methods: {
    async init() {
      this.$axios
        .get("https://localhost:57935/api/destino")
        .then(response => {
          this.localListaDestinos = response.data;
        });
      this.$axios
        .get("https://localhost:57935/api/vuelo")
        .then(response => {
          this.localVuelos = response.data;
          this.localVuelosOriginal = this.localVuelos;
          this.rangoPrecio(response.data);
        });
      if (this.$parent.$parent.localUsuario) {
        this.$axios
          .get("https://localhost:57935/api/reserva/usuario/" + this.$parent.$parent.localUsuario.Id)
          .then(response => {
            this.localAllowedToAddVuelo = true;
            if (response.data.filter(function (reserva) { return !reserva.reservaFinalizada; }).length > 0) {
              this.localReservaActiva = response.data.filter(function (reserva) { return !reserva.reservaFinalizada; })[0];
              this.$parent.$parent.localShowReservation = true;
              this.$parent.$parent.localReserva = this.localReservaActiva;
              if(this.localReservaActiva.alojamiento != null){
                this.localReservaActiva.alojamiento = this.localReservaActiva.alojamiento.id;
              }
              if(this.localReservaActiva.actividad != null){
                this.localReservaActiva.actividad = this.localReservaActiva.actividad.id;
              }
              if (this.localReservaActiva.vuelo != null || this.localReservaActiva.esUnPaquete) {
                this.localAllowedToAddVuelo = false;
              }
            }
          });
      }
    },
    rangoPrecio(vuelos) {
      if (vuelos.length == 0) {
        this.localPrecioMaximo = 0;
        return;
      }
      this.localPrecioMaximo = vuelos[0].precio;
      vuelos.forEach(({precio}) => {
        if (precio > this.localPrecioMaximo) {
          this.localPrecioMaximo = precio;
          this.localPrecio = precio;
        }
      })
    },
    submit() {
      this.localPrecio = this.localPrecioMaximo;
      this.localSelected = [];
      this.localClasesSeleccionadas = [];

      this.localAplicarFiltro = true;
      this.localVuelos = this.localVuelosOriginal;
      this.localVuelos = this.localVuelos.filter(this.filtro);
      this.localVuelosConValoracionYClase = this.localVuelos;
    },
    filtro(vuelo) {
      return (vuelo.origen.ciudad == this.localOrigen || !this.localOrigen) && 
      (vuelo.destino.ciudad == this.localDestino || !this.localDestino) && 
      (vuelo.fechaIda.toString() >= this.localFechaDesde || !this.localFechaDesde) &&
      (vuelo.fechaVuelta.toString() <= this.localFechaHasta || !this.localFechaHasta) &&
      ((this.localIdaVuelta && vuelo.fechaVuelta != null || this.localIdaVuelta == null ) || 
      (!this.localIdaVuelta && vuelo.fechaVuelta == null) || this.localIdaVuelta == null ) && 
      (vuelo.conEscala == this.localEscala || this.localEscala == null) && (vuelo.precio <= this.localPrecio)
    },
    filtrar(){
      this.localVuelos = this.localVuelosConValoracionYClase;
      
      this.filtrarPorPrecio();
      if(this.localSelected.length > 0)
        this.filtrarPorValoracion(); 
      if(this.localClasesSeleccionadas.length > 0)
        this.filtrarClase();
    },
    filtrarPorPrecio() {
      this.localVuelos = this.localVuelosConValoracionYClase;

      this.localVuelos = this.localVuelos.filter(vuelo => vuelo.precio <= this.localPrecio)
    },
    filtrarPorValoracion(){
      this.localVuelos = this.localVuelos.filter(vuelo => {
        return this.localSelected.find(select => (select == vuelo.valoracionAerolinea)) != undefined;
      })
    },
    filtrarClase(){
       this.localVuelos = this.localVuelos.filter(vuelo => {
        return this.localClasesSeleccionadas.find(select => (select == vuelo.clase)) != undefined;
      })
    },
    ordenar(columna) {
      // Verifica si la columna es la misma que la última seleccionada
      if (this.columnOrden === columna) {
        // Cambia la dirección de clasificación
        this.ordenAscendente = !this.ordenAscendente;
      } else {
        // Si se selecciona una columna diferente, restablece la dirección a ascendente
        this.columnOrden = columna;
        this.ordenAscendente = true;
      }
      // Realiza la clasificación de acuerdo a la columna seleccionada y la dirección
      this.localVuelos.sort((a, b) => {
        const valueA = this.obtenerValor(a, columna);
        const valueB = this.obtenerValor(b, columna);

        if (valueA === valueB) return 0;
        if (this.ordenAscendente) {
          return valueA < valueB ? -1 : 1;
        } else {
          return valueA > valueB ? -1 : 1;
        }
      });
    },
    obtenerValor(obj, columna) {
      // Función auxiliar para obtener el valor de una propiedad anidada en un objeto
      const propiedades = columna.split('.');
      for (let propiedad of propiedades) {
        obj = obj[propiedad];
      }
      return obj;
    },
    iconoOrden(columna) {
      // Devuelve la clase de icono de FontAwesome basada en la dirección de clasificación
      if (this.columnOrden === columna) {
        return this.ordenAscendente ? 'fa fa-arrow-up' : 'fa fa-arrow-down';
      }
    },
    agregarVueloAReserva(vuelo) {
      if (this.localReservaActiva == null) {
        this.$axios
          .post('https://localhost:57935/api/reserva', {
            nroReserva: "1",
            usuario: this.$parent.$parent.localUsuario.Id,
            destino: vuelo.destino.id,
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

.btn-primary {
  color: #fff;
  background-color: darkred;
  border-color: black;
}

.flight {
  display: inline-block;
  max-width: 15rem;
  margin-right: 20px;
}

.slider {
  width: 100%;
  height: 10px;
  border: none;
  outline: none;
  cursor: pointer;
  border-radius: 5px;
}

.slider::-webkit-slider-runnable-track {
  background-color: #dcdcdc;
  height: 10px;
  border-radius: 5px;
}

.slider::-webkit-slider-thumb {
  width: 20px;
  height: 20px;
  background-color: darkred;
  border: none;
  border-radius: 50%;
  box-shadow: 0 0 3px rgba(0, 0, 0, 0.5);
}

.slider::-webkit-slider-thumb:active {
  background-color: rgb(151, 60, 60);
}

th:hover {
  cursor: pointer;
  background-color: #fafafa;
}

th:active {
  background-color: #e5e5e5;
}
</style>