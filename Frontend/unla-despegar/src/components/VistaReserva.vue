<template>
  <div>
    <div v-if="!localShowAbonarReserva">
      <div v-if="localShowDetalle">
        <main role="main" class="container">
          <div class="d-flex align-items-start flex-column p-3 my-3 bg-purple rounded box-shadow">
            <h1>Número Reserva: {{ localReservaSeleccionada.id }}</h1>
            <h3>Destino: {{ localReservaSeleccionada.destino && localReservaSeleccionada.destino.pais }}, {{ localReservaSeleccionada.destino && localReservaSeleccionada.destino.region }},
              {{ localReservaSeleccionada.destino.ciudad }}</h3>
            <h3 v-if="localReservaSeleccionada.vuelo != null">Total: ${{ calcularImporte }}</h3>
            <h3 v-if="localReservaSeleccionada.alojamiento != null">Total: ${{ calcularImporte }}</h3>
          </div>
          <div v-show="!localVueloEliminado" class="alert alert-danger" role="alert">
            El vuelo no ha sido agregado, por favor intente nuevamente.
          </div>
          <div v-show="!localAlojamientoEliminado" class="alert alert-danger" role="alert">
            El Alojamiento no fue eliminado, por favor intente nuevamente.
          </div>
          <div v-show="!localPasajeroEliminado" class="alert alert-danger" role="alert">
            El Pasajero no fue eliminado, por favor intente nuevamente.
          </div>
          <div v-show="!localPasajeroAgregado" class="alert alert-danger" role="alert">
            El Pasajero no fue agregado, por favor intente nuevamente.
          </div>
          <div v-show="!localPasajeroModificado" class="alert alert-danger" role="alert">
            El Pasajero no fue modificado, por favor intente nuevamente.
          </div>
          <div v-show="!localReservaEliminada" class="alert alert-danger" role="alert">
            La Reserva no fue eliminada, por favor intente nuevamente.
          </div>
          <div v-show="!localReservaConfirmada" class="alert alert-danger" role="alert">
            La Reserva no fue confirmada, por favor intente nuevamente.
          </div>
          <div v-if="localReservaSeleccionada.vuelo != null">
            <div class="d-flex align-items-start flex-column my-3 p-3 bg-white rounded box-shadow">
              <h2>Vuelo</h2>
              <table aria-describedby="vueloTable" class="table">
                <thead>
                  <tr>
                    <th>Origen</th>
                    <th>Destino</th>
                    <th>Fecha Ida</th>
                    <th>Fecha Vuelta</th>
                    <th>Clase</th>
                    <th>Con Escala</th>
                    <th>Aerolínea</th>
                    <th>Precio</th>
                    <th>Valoración de Aerolínea</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-if="localReservaSeleccionada.vuelo">
                    <td>{{ localReservaSeleccionada.vuelo.origen && localReservaSeleccionada.vuelo.origen.pais }}, {{ localReservaSeleccionada.vuelo.origen.region
                    }},
                      {{ localReservaSeleccionada.vuelo.origen.ciudad }}</td>
                    <td>{{ localReservaSeleccionada.vuelo.destino && localReservaSeleccionada.vuelo.destino.pais }}, {{
                      localReservaSeleccionada.vuelo.destino.region }},
                      {{ localReservaSeleccionada.vuelo.destino.ciudad }}</td>
                    <td>{{ new Date(localReservaSeleccionada.vuelo.fechaIda).toLocaleString() }}</td>
                    <td>{{ new Date(localReservaSeleccionada.vuelo.fechaVuelta).toLocaleString() }}</td>
                    <td>{{ localReservaSeleccionada.vuelo.clase }}</td>
                    <td>{{ localReservaSeleccionada.vuelo.conEscala ? "Sí" : "No" }}</td>
                    <td>{{ localReservaSeleccionada.vuelo.nombreAerolinea }}</td>
                    <td>{{ localReservaSeleccionada.vuelo.precio }}</td>
                    <td>{{ localReservaSeleccionada.vuelo.valoracionAerolinea }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <div v-if="localReservaSeleccionada.alojamiento != null">
            <div class="d-flex align-items-start flex-column my-3 p-3 bg-white rounded box-shadow">
              <h2>Alojamiento</h2>
              <table class="table" aria-describedby="">
                <thead>
                  <tr>
                    <th>Alojamiento</th>
                    <th>Destino</th>
                    <th>Tipo Alojamiento</th>
                    <th>Tipo Habitación</th>
                    <th>Tipo Régimen</th>
                    <th>Tipo Servicio</th>
                    <th>Estrellas</th>
                    <th>Fecha Entrada</th>
                    <th>Fecha Salida</th>
                    <th>Precio</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-if="localReservaSeleccionada.alojamiento.destino">
                    <td>{{ localReservaSeleccionada.alojamiento.nombreAlojamiento }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.destino.pais }},
                      {{ localReservaSeleccionada.alojamiento.destino.region }},
                      {{ localReservaSeleccionada.alojamiento.destino.ciudad }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoAlojamiento.descripcion }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoHabitacion }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoRegimen.descripcion }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoServicio }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.cantidadEstrellas }}</td>

                    <td v-if="localReservaSeleccionada.reservaFinalizada == false" style="width: 200px;">
                      <b-form-datepicker
                        id="Entrada"
                        placeholder="Entrada"
                        :min="new Date()"
                        v-model="localFechaEntrada"
                        :date-format-options="{ year: 'numeric', month: 'short', day: '2-digit' }"
                        locale="es-ES"
                        :state="this.localFechaEntrada == undefined ? null : !!this.localFechaEntrada"
                        @input="()=>{if (new Date(this.localFechaEntrada) > new Date(this.localFechaSalida)) this.localFechaSalida = undefined}"
                      />
                      <b-form-invalid-feedback id="input-live-feedback">
                        Ingrese la fecha de ingreso
                      </b-form-invalid-feedback>
                    </td>
                    <td v-else>{{ localReservaSeleccionada.fechaEntrada | moment("DD/MM/YYYY") }} </td>
                    <td v-if="localReservaSeleccionada.reservaFinalizada == false" style="width: 200px;">
                      <b-form-datepicker
                        id="Salida"
                        placeholder="Salida"
                        :min="localFechaEntrada"
                        v-model="localFechaSalida"
                        :date-format-options="{ year: 'numeric', month: 'short', day: '2-digit' }"
                        locale="es-ES"
                        :state="this.localFechaSalida == undefined ? null : !!this.localFechaSalida"
                      />
                      <b-form-invalid-feedback id="input-live-feedback">
                        Ingrese la fecha de salida
                      </b-form-invalid-feedback>
                    </td>
                    <td v-else>{{ localReservaSeleccionada.fechaSalida | moment("DD/MM/YYYY") }} </td>
                    <td>{{ localReservaSeleccionada.alojamiento.precio }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <div class="d-flex align-items-start flex-column my-3 p-3 bg-white rounded box-shadow">
            <h2>{{localReservaSeleccionada.vuelo != null ? "Pasajeros" : "Personas"}}</h2>
            <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="vistaAgregarPasajero()" class="btn">
              <i class="fa fa-plus-circle"></i>
            </button>
            <table aria-describedby="pasajerosTable" class="table">
              <thead>
                <tr>
                  <th>Nombre</th>
                  <th>Apellido</th>
                  <th>DNI</th>
                  <th>Nacionalidad</th>
                  <th>Email</th>
                  <th>Teléfono</th>
                  <th>Domicilio</th>
                  <th v-if="!localReservaSeleccionada.reservaFinalizada">Editar</th>
                  <th v-if="!localReservaSeleccionada.reservaFinalizada">Eliminar</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="pasajero in localPasajerosSeleccionados" :key="pasajero.id">
                  <td>{{ pasajero.nombre }}</td>
                  <td>{{ pasajero.apellido }}</td>
                  <td>{{ pasajero.dni }}</td>
                  <td>{{ pasajero.nacionalidad }}</td>
                  <td>{{ pasajero.mail }}</td>
                  <td>{{ pasajero.telefono }}</td>
                  <td>{{ pasajero.domicilio }}</td>
                  <td v-if="!localReservaSeleccionada.reservaFinalizada">
                    <button @click="vistaModificarPasajero(pasajero)" class="btn">
                      <i class="fas fa-edit"></i>
                    </button>
                  </td>
                  <td v-if="!localReservaSeleccionada.reservaFinalizada">
                    <button @click="eliminarPasajero(pasajero)" class="btn">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
          <VistaAsientos v-if="localReservaSeleccionada.vuelo && !localReservaSeleccionada.reservaFinalizada" :numPasajeros="localPasajerosSeleccionados && localPasajerosSeleccionados.length"/>
        </main>
        <div showMenu class="row">
          <div class="options text-center">
            <button @click="volverMenu" type="button" class="btn btn-lg btn-block btn-primary no-print">
              <i class="fas fa-arrow-left"></i> Volver</button>
            <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="vistaAbonarReserva" type="button"
              class="btn btn-lg btn-block btn-primary no-print"><i class="fas fa-credit-card"></i>  Ir a Abonar Reserva</button>
            <button @click="imprimirReserva" type="button"
              class="btn btn-lg btn-block btn-primary no-print"><i class="fas fa-print"></i> Imprimir Reserva</button>
            <button @click="eliminarReserva" type="button"
              class="btn btn-lg btn-block btn-primary no-print"><i class="fas fa-trash"></i> Eliminar Reserva</button>
          </div>
        </div>
      </div>
      <div v-if="localShowEditarPasajero">
        <div class="text-center">
          <h4 class="mb-3">Ingrese sus datos personales</h4>
          <div class="row options">
            <div class="options text-center">
              <form class="needs-validation" novalidate ref="editarForm"
                @submit.prevent="modificarPasajero(localPasajeroToEdit)">
                <div class="row options">
                  <div>
                    <label for="dni">DNI</label>
                    <input type="text" class="form-control" id="dni" v-model="localPasajeroToEdit.dni" required />
                    <div class="invalid-feedback">Ingrese su DNI</div>

                    <label for="nombre">Nombre</label>
                    <input type="text" class="form-control" id="nombre" v-model="localPasajeroToEdit.nombre" required />
                    <div class="invalid-feedback">Ingrese su nombre</div>

                    <label for="apellido">Apellido</label>
                    <input type="text" class="form-control" id="apellido" v-model="localPasajeroToEdit.apellido"
                      required />
                    <div class="invalid-feedback">Ingrese su apellido</div>

                    <label for="nacionalidad">Nacionalidad</label>
                    <input type="text" class="form-control" id="nacionalidad" v-model="localPasajeroToEdit.nacionalidad"
                      required />
                    <div class="invalid-feedback">Ingrese su nacionalidad</div>

                    <label for="domicilio">Domicilio</label>
                    <input type="text" class="form-control" id="domicilio" v-model="localPasajeroToEdit.domicilio"
                      required />
                    <div class="invalid-feedback">Ingrese su domicilio</div>

                    <label for="mail">Mail</label>
                    <input type="text" class="form-control" id="mail" v-model="localPasajeroToEdit.mail" required />
                    <div class="invalid-feedback">Ingrese un mail</div>

                    <label for="telefono">Teléfono</label>
                    <input type="text" class="form-control" id="telefono" v-model="localPasajeroToEdit.telefono"
                      required />
                    <div class="invalid-feedback">Ingrese un teléfono de contacto</div>

                    <br />
                    <button type="submit" class="btn btn-lg btn-block btn-primary options">
                      <i class="fas fa-save"></i> Guardar Cambios
                    </button>
                    <br />
                    <button @click="volverReserva" type="button" class="btn btn-lg btn-block btn-primary options text-center">
                      <i class="fas fa-arrow-left"></i> Volver
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
          <br />
        </div>
      </div>
      <div v-if="localShowAgregarPasajero">
        <div class="text-center">
          <h4 class="mb-3">Ingrese sus datos personales</h4>
          <div class="row options">
            <div class="options text-center">
              <form class="needs-validation" novalidate ref="agregarForm" @submit.prevent="agregarPasajero">
                <div class="row options">
                  <div>
                    <label for="dni">DNI</label>
                    <input type="text" class="form-control" id="dni" v-model="localDni" required />
                    <div class="invalid-feedback">Ingrese su DNI</div>

                    <label for="nombre">Nombre</label>
                    <input type="text" class="form-control" id="nombre" v-model="localNombre" required />
                    <div class="invalid-feedback">Ingrese su nombre</div>

                    <label for="apellido">Apellido</label>
                    <input type="text" class="form-control" id="apellido" v-model="localApellido" required />
                    <div class="invalid-feedback">Ingrese su apellido</div>

                    <label for="nacionalidad">Nacionalidad</label>
                    <input type="text" class="form-control" id="nacionalidad" v-model="localNacionalidad" required />
                    <div class="invalid-feedback">Ingrese su nacionalidad</div>

                    <label for="domicilio">Domicilio</label>
                    <input type="text" class="form-control" id="domicilio" v-model="localDomicilio" required />
                    <div class="invalid-feedback">Ingrese su domicilio</div>

                    <label for="mail">Mail</label>
                    <input type="text" class="form-control" id="mail" v-model="localMail" required />
                    <div class="invalid-feedback">Ingrese un mail</div>

                    <label for="telefono">Teléfono</label>
                    <input type="text" class="form-control" id="telefono" v-model="localTelefono" required />
                    <div class="invalid-feedback">Ingrese un teléfono de contacto</div>

                    <br />
                    <button type="submit" class="btn btn-lg btn-block btn-primary options">
                      <i class="fas fa-save"></i> Guardar Cambios
                    </button>
                    <br />
                    <button @click="volverReserva" type="button" class="btn btn-lg btn-block btn-primary options text-center">
                      <i class="fas fa-arrow-left"></i> Volver Al Menú
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
          <br />
        </div>
      </div>
    </div>
    <VistaAbonar v-if="localShowAbonarReserva" />
  </div>
</template>

<script>
import VistaAbonar from './VistaAbonar.vue';
import VistaAsientos from './VistaAsientos.vue';

export default {
  name: "VistaReserva",
  props: {
    reservaSeleccionada: null,
    vuelo_id: null,
    pasajerosSeleccionados: null,
    pasajeroToEdit: null,
    fechaEntrada: null,
    fechaSalida: null,
    //flags errores
    vueloEliminado: {
      type: Boolean,
      default: true
    },
    alojamientoEliminado:{
      type:Boolean,
      default: true
    }, 
    pasajeroEliminado: {
      type: Boolean,
      default: true
    },
    pasajeroAgregado: {
      type: Boolean,
      default: true
    },
    pasajeroModificado: {
      type: Boolean,
      default: true
    },
    reservaEliminada: {
      type: Boolean,
      default: true
    },
    reservaConfirmada: {
      type: Boolean,
      default: true
    },
    showDetalle: {
      type: Boolean,
      default: true
    },
    showEditarPasajero: {
      type: Boolean,
      default: false
    },
    showAgregarPasajero: {
      type: Boolean,
      default: false
    },
    showAbonarReserva: {
      type: Boolean,
      default: false
    },
    dni: null,
    nombre: null,
    apellido: null,
    nacionalidad: null,
    domicilio: null,
    mail: null,
    telefono: null,
    volverFunc: Function,
    reserva: Boolean,
    showReservation: Boolean
  },
  computed: {
    calcularDiferenciaDias() {
      let fechaInicio = new Date(this.localFechaEntrada || this.localReservaSeleccionada.fechaEntrada);
      let fechaFin = new Date(this.localFechaSalida || this.localReservaSeleccionada.fechaSalida);
      if (this.localFechaEntrada && this.localFechaSalida) {
        fechaInicio = new Date(this.localFechaEntrada);
        fechaFin = new Date(this.localFechaSalida);
      } else {
        fechaInicio = new Date(this.localReservaSeleccionada.fechaEntrada);
        fechaFin = new Date(this.localReservaSeleccionada.fechaSalida);
      }
        // Calcula la diferencia en milisegundos
        const diferenciaMilisegundos = fechaFin - fechaInicio;

        // Convierte la diferencia en días
        const unDiaEnMilisegundos = 1000 * 60 * 60 * 24;
        const diferenciaDias = Math.floor(diferenciaMilisegundos / unDiaEnMilisegundos);

        return diferenciaDias === 0 ? 1 : diferenciaDias;
      
    },
    calcularImporte() {
      if(this.localReservaSeleccionada.vuelo){
        return this.localReservaSeleccionada.importe
      } else if (this.localReservaSeleccionada.alojamiento && this.localPasajerosSeleccionados){
        return this.localReservaSeleccionada.alojamiento.precio * this.localPasajerosSeleccionados.length * this.calcularDiferenciaDias;
      } else {
        return 0;
      }
    }
  },
  data() {
    return {
      localDni: this.dni,
      localNombre: this.nombre,
      localApellido: this.apellido,
      localNacionalidad: this.nacionalidad,
      localDomicilio: this.domicilio,
      localMail: this.mail,
      localPassword: this.password,
      localTelefono: this.telefono,
      localVueloId: this.vuelo_id,
      localReservaSeleccionada: this.reservaSeleccionada,
      localPasajerosSeleccionados: this.pasajerosSeleccionados,
      localPasajeroToEdit: this.pasajeroToEdit,
      localFechaEntrada: this.fechaEntrada,
      localFechaSalida: this.fechaSalida,
      localVueloEliminado: this.vueloEliminado,
      localAlojamientoEliminado: this.alojamientoEliminado,
      localPasajeroEliminado: this.pasajeroEliminado,
      localPasajeroAgregado: this.pasajeroAgregado,
      localPasajeroModificado: this.pasajeroModificado,
      localReservaEliminada: this.reservaEliminada,
      localReservaConfirmada: this.reservaConfirmada,
      localShowDetalle: this.showDetalle,
      localShowEditarPasajero: this.showEditarPasajero,
      localShowAgregarPasajero: this.showAgregarPasajero,
      localShowAbonarReserva: this.showAbonarReserva,
      localReserva: this.reserva,
      localShowReservation: this.showReservation
    };
  },
  watch: {
    dni(newVal) { this.localDni = newVal; },
    nombre(newVal) { this.localNombre = newVal; },
    apellido(newVal) { this.localApellido = newVal; },
    nacionalidad(newVal) { this.localNacionalidad = newVal; },
    domicilio(newVal) { this.localDomicilio = newVal; },
    mail(newVal) { this.localMail = newVal; },
    password(newVal) { this.localPassword = newVal; },
    telefono(newVal) { this.localTelefono = newVal; },
    vuelo_id(newVal) { this.localVueloId = newVal; },
    reservaSeleccionada(newVal) { this.localReservaSeleccionada = newVal; },
    pasajerosSeleccionados(newVal) { this.localPasajerosSeleccionados = newVal; },
    pasajeroToEdit(newVal) { this.localPasajeroToEdit = newVal; },
    fechaEntrada(newVal) { this.localFechaEntrada = newVal; },
    fechaSalida(newVal) { this.localFechaSalida = newVal; },
    vueloEliminado(newVal) { this.localVueloEliminado = newVal; },
    alojamientoEliminado(newVal) { this.localAlojamientoEliminado = newVal; },
    pasajeroEliminado(newVal) { this.localPasajeroEliminado = newVal; },
    pasajeroAgregado(newVal) { this.localPasajeroAgregado = newVal; },
    pasajeroModificado(newVal) { this.localPasajeroModificado = newVal; },
    reservaEliminada(newVal) { this.localReservaEliminada = newVal; },
    reservaConfirmada(newVal) { this.localReservaConfirmada = newVal; },
    showDetalle(newVal) { this.localShowDetalle = newVal; },
    showEditarPasajero(newVal) { this.localShowEditarPasajero = newVal; },
    showAgregarPasajero(newVal) { this.localShowAgregarPasajero = newVal; },
    showAbonarReserva(newVal) { this.localShowAbonarReserva = newVal; },
    reserva(newVal) { this.localReserva = newVal; },
    showReservation(newVal) { this.localShowReservation = newVal; }
  },
  methods: {
    imprimirReserva() {
      print()
    },
    volverMenu() {
      // this.$parent.cargaHome();
      this.volverFunc();
    },
    volverReserva() {
      this.localShowEditarPasajero = false;
      this.localShowAgregarPasajero = false;
      this.localShowDetalle = true;
    },
    eliminarPasajero(pasajero) {
      if (confirm("Desea eliminar esta pasajero?"))
        this.$axios
          .delete("https://localhost:57935/api/pasajero/" + pasajero.id)
          .then(() => {
            this.actualizar();
            this.localReservaSeleccionada.importe = this.calcularImporte;
          })
          .catch(() => {
            this.localPasajeroEliminado = false;
            setTimeout(() => this.localPasajeroEliminado = true, 2000);
          });
    },
    vistaModificarPasajero(pasajero) {
      this.localPasajeroToEdit = pasajero;
      this.localShowDetalle = false;
      this.localShowEditarPasajero = true;
    },
    vistaAgregarPasajero() {
      this.localShowDetalle = false;
      this.localShowAgregarPasajero = true;
    },
    vistaAbonarReserva() {
      if(this.localReservaSeleccionada.alojamiento) {
        if(!this.localFechaEntrada) {
          this.localFechaEntrada = "";
        } 
        if (!this.localFechaSalida) {
          this.localFechaSalida = "";
        }
        if (!this.localFechaEntrada || !this.localFechaSalida) {
          return;
        }
      }
      this.localShowAbonarReserva = true;
      this.localShowDetalle = false;
      this.localShowEditarPasajero = false;
    },
    validar(form) {
      if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return true;
      }
      return false;
    },
    agregarPasajero() {
      if (this.validar(this.$refs.agregarForm)) return;
      if (confirm("Desea Guardar Cambios?"))
        this.$axios
          .post("https://localhost:57935/api/pasajero", {
            nombre: this.localNombre,
            apellido: this.localApellido,
            dni: this.localDni,
            domicilio: this.localDomicilio,
            mail: this.localMail,
            nacionalidad: this.localNacionalidad,
            reserva: this.localReservaSeleccionada.id,
            telefono: this.localTelefono,
          })
          .then(() => {
            this.actualizar();
            this.localShowDetalle = true;
            this.localShowAgregarPasajero = false;
            this.localReservaSeleccionada.importe = this.calcularImporte;
          })
          .catch(() => {
            this.localPasajeroAgregado = false;
            setTimeout(() => this.localPasajeroAgregado = true, 2000);
          });
    },
    modificarPasajero(user) {
      if (this.validar(this.$refs.editarForm)) return;
      this.localDni = user.dni;
      this.localNombre = user.nombre;
      this.localApellido = user.apellido;
      this.localNacionalidad = user.nacionalidad;
      this.localDomicilio = user.domicilio;
      this.localMail = user.mail;
      this.localTelefono = user.telefono;
      if (confirm("Desea Guardar Cambios?")) {
        this.$axios
          .put("https://localhost:57935/api/pasajero/" +
            this.localPasajeroToEdit.id, {
            id: this.localPasajeroToEdit.id,
            nombre: this.localPasajeroToEdit.nombre,
            apellido: this.localPasajeroToEdit.apellido,
            dni: this.localPasajeroToEdit.dni,
            domicilio: this.localPasajeroToEdit.domicilio,
            mail: this.localPasajeroToEdit.mail,
            nacionalidad: this.localPasajeroToEdit.nacionalidad,
            reserva: this.localPasajeroToEdit.reserva,
            telefono: this.localPasajeroToEdit.telefono,
          }).then(() => {
            this.actualizar();
            this.localShowDetalle = true;
            this.localShowEditarPasajero = false;
          }).catch(() => {
            this.localPasajeroModificado = false;
            setTimeout(() => this.localPasajeroModificado = true, 2000);
          });
      }
    },
    modificarReserva() {
      this.$axios
        .put("https://localhost:57935/api/reserva/" + this.localReservaSeleccionada.id, {
          id: this.localReservaSeleccionada.id,
          nroReserva: this.localReservaSeleccionada.nroReserva,
          usuario: this.localReservaSeleccionada.usuario.id,
          destino: this.localReservaSeleccionada.destino.id,
          vuelo: this.localVueloId,
          importe: this.localReservaSeleccionada.importe,
          pasajeros: this.localReservaSeleccionada.pasajeros,
          fechaEntrada: this.localFechaEntrada,
          fechaSalida: this.localFechaSalida,
          reservaFinalizada: false
        }).then(() => {
          this.actualizar();
        });
    },
    actualizar() {
      this.$axios
        .get("https://localhost:57935/api/reserva/" + this.localReservaSeleccionada.id)
        .then(response => {
          this.localReservaSeleccionada = response.data;
          if (this.localReservaSeleccionada.vuelo != null) {
            this.localVueloId = this.localReservaSeleccionada.vuelo.id;
          }
          else {
            this.localVueloId = null;
          }
          this.localPasajerosSeleccionados = this.localReservaSeleccionada.pasajeros;
          this.$parent.localReserva = this.localReservaSeleccionada;
        });
    },
    eliminarReserva() {
      if (confirm("Desea eliminar reserva")) {
        this.$axios.delete('https://localhost:57935/api/reserva/' + this.localReservaSeleccionada.id)
          .then(() => {
            this.$emit("eliminarReserva");
            this.volverFunc();
          }).catch(() => {
            this.localReservaEliminada = false;
            setTimeout(() => this.localReservaEliminada = true, 2000);
          });
      }
    },
    confirmarReserva() {
      if (confirm("Desea confirmar reserva?")) {
        if (this.localReservaSeleccionada.vuelo) {
          this.$axios
            .put("https://localhost:57935/api/reserva/" + this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              vuelo: this.localReservaSeleccionada.vuelo.id,
              importe: this.localReservaSeleccionada.importe,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              fechaEntrada: this.localFechaEntrada,
              fechaSalida: this.localFechaSalida,
              reservaFinalizada: true
            }).then(() => {
              this.$parent.localReserva = null;
              this.$parent.localShowReservation = false;
              this.$emit("eliminarReserva");
              this.volverFunc();
            }).catch(() => {
              this.localReservaConfirmada = false;
              setTimeout(() => this.localReservaConfirmada = true, 2000);
            });
        } else {
          this.$axios
            .put("https://localhost:57935/api/reserva/" + this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              alojamiento: this.localReservaSeleccionada.alojamiento.id,
              importe: this.localReservaSeleccionada.alojamiento.precio,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              fechaEntrada: this.localFechaEntrada,
              fechaSalida: this.localFechaSalida,
              reservaFinalizada: true
            }).then(() => {
              this.$parent.localReserva = null;
              this.$parent.localShowReservation = false;
              this.$emit("eliminarReserva");
              this.volverFunc();
            }).catch(() => {
              this.localReservaConfirmada = false;
              setTimeout(() => this.localReservaConfirmada = true, 2000);
            });
        }
      }
    },
    async init() {
      // this.localReservaSeleccionada = this.$parent.localReserva;
      this.localFechaEntrada = null;
      this.localFechaSalida = null;
      if (this.localReservaSeleccionada.vuelo != null) {
        this.localVueloId = this.localReservaSeleccionada.vuelo.id;
      }
      else {
        this.localVueloId = null;
      }
      this.localPasajerosSeleccionados = this.localReservaSeleccionada.pasajeros;
      if (this.localPasajerosSeleccionados.length == 0) {
        this.$axios
          .post("https://localhost:57935/api/pasajero", {
            nombre: this.localReservaSeleccionada.usuario.nombre,
            apellido: this.localReservaSeleccionada.usuario.apellido,
            dni: this.localReservaSeleccionada.usuario.dni,
            domicilio: this.localReservaSeleccionada.usuario.domicilio,
            mail: this.localReservaSeleccionada.usuario.mail,
            nacionalidad: this.localReservaSeleccionada.usuario.nacionalidad,
            reserva: this.localReservaSeleccionada.id,
            telefono: this.localReservaSeleccionada.usuario.telefono,
          }).then(() => {
            this.actualizar();
          });
      }
    }
  },
  async mounted() {
    await this.init();
  },
  components: { VistaAbonar, VistaAsientos }
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