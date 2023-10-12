<template>
  <div>
    <div v-if="!localShowAbonarReserva">
      <div v-if="localShowList">
        <h4 v-if="localReservasActivas[0] != null" class>Activas</h4>
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
            <h5 v-if="reserva.vuelo != null">${{ reserva.importe }}</h5>
            <h5 v-if="reserva.alojamiento != null">${{ reserva.alojamiento.precio }}</h5>
            <b-button @click="cargaReserva(reserva)" href="#" variant="primary">Ver Reserva</b-button>
          </b-card>
        </div>
        <h4 v-if="localReservasFinalizadas[0] != null">Finalizadas</h4>
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

      <!-- <div v-if="localShowDetalle">
        <div v-show="!localVueloEliminado" class="alert alert-danger" role="alert">
          El vuelo no fue creado
        </div>
        <div v-show="!localAlojamientoEliminado" class="alert alert-danger" role="alert">
          El alojamiento no fue eliminado
        </div>
        <main role="main" class="container">
          <div class="d-flex align-items-start flex-column p-3 my-3 bg-purple rounded box-shadow">
            <h1>Número Reserva: {{ localReservaSeleccionada.id }}</h1>
            <h3>Destino: {{ localReservaSeleccionada.destino.pais }}, {{ localReservaSeleccionada.destino.region }},
              {{ localReservaSeleccionada.destino.ciudad }}</h3>
            <h3>Total: ${{ localReservaSeleccionada.importe }}</h3>
          </div>
          <div v-if="localReservaSeleccionada.vuelo != null">
            <div class="d-flex align-items-start flex-column my-3 p-3 bg-white rounded box-shadow">
              <h2>Vuelo</h2>
              <table class="table" aria-describedby="">
                <thead>
                  <tr>
                    <th>Origen</th>
                    <th>Destino</th>
                    <th>Fecha Ida</th>
                    <th>Fecha Vuelta</th>
                    <th>Clase</th>
                    <th>Con Escala</th>
                    <th>Aerolinea</th>
                    <th>Precio</th>
                    <th>Valoración Aerolinea</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>{{ localReservaSeleccionada.vuelo.origen.pais }}, {{ localReservaSeleccionada.vuelo.origen.region
                    }},
                      {{ localReservaSeleccionada.vuelo.origen.ciudad }}</td>
                    <td>{{ localReservaSeleccionada.vuelo.destino.pais }}, {{
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
              <button v-if="localReservaSeleccionada.reservaFinalizada == false" @click="eliminarAlojamiento()" class="btn">
                <i class="fa fa-trash"></i>
              </button>
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
                  <tr>
                    <td>{{ localReservaSeleccionada.alojamiento.nombreAlojamiento }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.destino.pais }},
                      {{ localReservaSeleccionada.alojamiento.destino.region }},
                      {{ localReservaSeleccionada.alojamiento.destino.ciudad }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoAlojamiento.descripcion }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoHabitacion }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoRegimen.descripcion }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.tipoServicio }}</td>
                    <td>{{ localReservaSeleccionada.alojamiento.cantidadEstrellas }}</td>


                    <td v-if="localReservaSeleccionada.reservaFinalizada == false">
                      <datetime input-class="form-control" format="yyyy/MM/dd T" value-zone="UTC-3"
                        :min-datetime="currentDate" zone="UTC-3" type="datetime" id="fecha-desde"
                        placeholder="aaaa/mm/dd HH:MM" v-model="fechaEntrada" required></datetime>
                    </td>
                    <td v-else>{{ localReservaSeleccionada.fechaEntrada | moment("DD/MM/YYYY LT") }} </td>
                    <td v-if="localReservaSeleccionada.reservaFinalizada == false">
                      <datetime input-class="form-control" format="yyyy/MM/dd T" value-zone="UTC-3"
                        :min-datetime="fechaDesde" zone="UTC-3" type="datetime" id="fecha-hasta"
                        placeholder="aaaa/mm/dd HH:MM" v-model="fechaSalida" required></datetime>
                    </td>
                    <td v-else>{{ localReservaSeleccionada.fechaSalida | moment("DD/MM/YYYY LT") }} </td>
                    <td>{{ localReservaSeleccionada.alojamiento.precio }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <div class="d-flex align-items-start flex-column my-3 p-3 bg-white rounded box-shadow">
            <h2>Pasajeros</h2>
            <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="vistaAgregarPasajero()" class="btn">
              <i class="fa fa-plus-circle"></i>
            </button>
            <table class="table" aria-describedby="">
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
                  <td>
                    <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="vistaModificarPasajero(pasajero)"
                      class="btn">
                      <i class="fas fa-edit"></i>
                    </button>
                  </td>
                  <td>
                    <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="eliminarPasajero(pasajero)"
                      class="btn">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </main>
        <div class="row">
          <div class="options text-center">
            <button @click="listaReservas" type="button" class="btn btn-lg btn-block btn-primary">Volver</button>
            <button v-if="localReservaSeleccionada.reservaFinalizada" @click="imprimirReserva" type="button"
              class="btn btn-lg btn-block btn-primary">Imprimir Reserva</button>
            <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="vistaAbonarReserva" type="button"
              class="btn btn-lg btn-block btn-primary">Ir a Abonar Reserva</button>
            <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="eliminarReserva" type="button"
              class="btn btn-lg btn-block btn-primary">Eliminar Reserva</button>
          </div>
          <div v-show="!localReservaEliminada" class="alert alert-danger" role="alert">
            La Reserva no ha sido eliminada
          </div>
          <div v-show="!localReservaConfirmada" class="alert alert-danger" role="alert">
            La Reserva no ha sido confirmada
          </div>
        </div>
      </div>
      <div v-if="localShowEditarPasajero">
        <div v-show="!localPasajeroEliminado" class="alert alert-danger" role="alert">
          El pasajero no fue eliminado
        </div>
        <div v-show="!localPasajeroAgregado" class="alert alert-danger" role="alert">
          El pasajero no fue agregado
        </div>
        <div v-show="!localPasajeroModificado" class="alert alert-danger" role="alert">
          El pasajero no fue modificado
        </div>
        <div class="text-center">
          <h4 class="mb-3">Ingrese sus datos personales</h4>
          <div class="row options">
            <div class="options text-center">
              <form class="needs-validation" novalidate>
                <div class="row options">
                  <div>
                    <label for="dni">DNI</label>
                    <input type="text" class="form-control" id="dni" v-model="localPasajeroToEdit.dni" required />
                    <p v-if="localDniAlert" class="color-red">{{ localDniMessage }}</p>

                    <label for="nombre">Nombre</label>
                    <input type="text" class="form-control" id="nombre" v-model="localPasajeroToEdit.nombre" required />
                    <p v-if="localNombreAlert" class="color-red">{{ localNombreMessage }}</p>

                    <label for="apellido">Apellido</label>
                    <input type="text" class="form-control" id="apellido" v-model="localPasajeroToEdit.apellido"
                      required />
                    <p v-if="localApellidoAlert" class="color-red">{{ localApellidoMessage }}</p>

                    <label for="nacionalidad">Nacionalidad</label>
                    <input type="text" class="form-control" id="nacionalidad" v-model="localPasajeroToEdit.nacionalidad"
                      required />
                    <p v-if="localNacionalidadAlert" class="color-red">{{ localNacionalidadMessage }}</p>

                    <label for="domicilio">Domicilio</label>
                    <input type="text" class="form-control" id="domicilio" v-model="localPasajeroToEdit.domicilio"
                      required />
                    <p v-if="localDomicilioAlert" class="color-red">{{ localDomicilioMessage }}</p>

                    <label for="mail">Mail</label>
                    <input type="text" class="form-control" id="mail" v-model="localPasajeroToEdit.mail" required />
                    <p v-if="localMailAlert" class="color-red">{{ localMailMessage }}</p>

                    <label for="telefono">Telefono</label>
                    <input type="text" class="form-control" id="telefono" v-model="localPasajeroToEdit.telefono"
                      required />
                    <p v-if="localTelefonoAlert" class="color-red">{{ localTelefonoMessage }}</p>

                    <br />
                  </div>
                </div>
              </form>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="options text-center">
              <button @click="modificarPasajero(localPasajeroToEdit)" type="button"
                class="btn btn-lg btn-block btn-primary options">Guardar Cambios</button>
              <button @click="listaReservas" type="button"
                class="btn btn-lg btn-block btn-primary options text-center">Volver</button>
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
              <form class="needs-validation" novalidate>
                <div class="row options">
                  <div>
                    <label for="dni">DNI</label>
                    <input type="text" class="form-control" id="dni" v-model="localDni" required />
                    <p v-if="localDniAlert" class="color-red">{{ localDniMessage }}</p>

                    <label for="nombre">Nombre</label>
                    <input type="text" class="form-control" id="nombre" v-model="localNombre" required />
                    <p v-if="localNombreAlert" class="color-red">{{ localNombreMessage }}</p>

                    <label for="apellido">Apellido</label>
                    <input type="text" class="form-control" id="apellido" v-model="localApellido" required />
                    <p v-if="localApellidoAlert" class="color-red">{{ localApellidoMessage }}</p>

                    <label for="nacionalidad">Nacionalidad</label>
                    <input type="text" class="form-control" id="nacionalidad" v-model="localNacionalidad" required />
                    <p v-if="localNacionalidadAlert" class="color-red">{{ localNacionalidadMessage }}</p>

                    <label for="domicilio">Domicilio</label>
                    <input type="text" class="form-control" id="domicilio" v-model="localDomicilio" required />
                    <p v-if="localDomicilioAlert" class="color-red">{{ localDomicilioMessage }}</p>

                    <label for="mail">Mail</label>
                    <input type="text" class="form-control" id="mail" v-model="localMail" required />
                    <p v-if="localMailAlert" class="color-red">{{ localMailMessage }}</p>

                    <label for="telefono">Telefono</label>
                    <input type="text" class="form-control" id="telefono" v-model="localTelefono" required />
                    <p v-if="localTelefonoAlert" class="color-red">{{ localTelefonoMessage }}</p>

                    <br />
                    <button @click="agregarPasajero()" type="button"
                      class="btn btn-lg btn-block btn-primary options">Guardar Cambios</button>
                  </div>
                </div>
              </form>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="options text-center">
              <button @click="listaReservas" type="button"
                class="btn btn-lg btn-block btn-primary options text-center">Volver Al Menú</button>
            </div>
          </div>
          <br />
        </div>
      </div> -->
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
    reservas: null,
    reservasActivas: null,
    reservasFinalizadas: null,
    reservaSeleccionada: null,
    vuelo_id: null,
    actividad_id: null,
    alojamiento_id: null,
    pasajerosSeleccionados: null,
    pasajeroToEdit: null,
    dni: null,
    nombre: null,
    apellido: null,
    mail: null,
    nacionalidad: null,
    telefono: null,
    domicilio: null,
    fechaEntrada: null,
    fechaSalida: null,
    showList: {
      type: Boolean,
      default: true
    },
    showDetalle: {
      type: Boolean,
      default: false
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
    vueloEliminado: {
      type: Boolean,
      default: true
    },
    reservaConfirmada: {
      type: Boolean,
      default: true
    },
    actividadEliminada: {
      type: Boolean,
      default: true
    },
    alojamientoEliminado: {
      type: Boolean,
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
    }
  },
  data() {
    return {
      localReservas: this.reservas,
      localReservasActivas: this.reservasActivas,
      localReservasFinalizadas: this.reservaFinalizadas,
      localReservaSeleccionada: this.reservaSeleccionada,
      localVueloId: this.vuelo_id,
      localActividadId: this.actividad_id,
      localAlojamientoId: this.alojamiento_id,
      localPasajerosSeleccionados: this.pasajerosSeleccionados,
      localPasajeroToEdit: this.pasajeroToEdit,
      localDni: this.dni,
      localNombre: this.nombre,
      localApellido: this.apellido,
      localMail: this.mail,
      localNacionalidad: this.nacionalidad,
      localTelefono: this.telefono,
      localDomicilio: this.domicilio,
      localFechaEntrada: this.fechaEntrada,
      localFechaSalida: this.fechaSalida,
      localShowList: this.showList,
      localShowDetalle: this.showDetalle,
      localShowEditarPasajero: this.showEditarPasajero,
      localShowAgregarPasajero: this.showAgregarPasajero,
      localShowAbonarReserva: this.showAbonarReserva,
      localVueloEliminado: this.vueloEliminado,
      localReservaConfirmada: this.reservaConfirmada,
      localActividadEliminada: this.actividadEliminada,
      localAlojamientoEliminado: this.alojamientoEliminado,
      localPasajeroEliminado: this.pasajeroEliminado,
      localPasajeroAgregado: this.pasajeroAgregado,
      localPasajeroModificado: this.pasajeroModificado,
      localReservaEliminada: this.reservaEliminada
    };
  },
  watch: {
    reservas(newVal) { this.localReservas = newVal; },
    reservasActivas(newVal) { this.localReservasActivas = newVal; },
    reservasFinalizadas(newVal) { this.localReservasFinalizadas = newVal; },
    reservaSeleccionada(newVal) { this.localReservaSeleccionada = newVal; },
    vuelo_id(newVal) { this.localVueloId = newVal; },
    actividad_id(newVal) { this.localActividadId = newVal; },
    alojamiento_id(newVal) { this.localAlojamientoId = newVal; },
    pasajerosSeleccionados(newVal) { this.localPasajerosSeleccionados = newVal; },
    pasajeroToEdit(newVal) { this.localPasajeroToEdit = newVal; },
    dni(newVal) { this.localDni = newVal; },
    nombre(newVal) { this.localNombre = newVal; },
    apellido(newVal) { this.localApellido = newVal; },
    mail(newVal) { this.localMail = newVal; },
    nacionalidad(newVal) { this.localNacionalidad = newVal; },
    telefono(newVal) { this.localTelefono = newVal; },
    domicilio(newVal) { this.localDomicilio = newVal; },
    fechaEntrada(newVal) { this.localFechaEntrada = newVal; },
    fechaSalida(newVal) { this.localFechaSalida = newVal; },
    showList(newVal) { this.localShowList = newVal; },
    showDetalle(newVal) { this.localShowDetalle = newVal; },
    showEditarPasajero(newVal) { this.localShowEditarPasajero = newVal; },
    showAgregarPasajero(newVal) { this.localShowAgregarPasajero = newVal; },
    showAbonarReserva(newVal) { this.localShowAbonarReserva = newVal; },
    vueloEliminado(newVal) { this.localVueloEliminado = newVal; },
    reservaConfirmada(newVal) { this.localReservaConfirmada = newVal; },
    actividadEliminada(newVal) { this.localActividadEliminada = newVal; },
    alojamientoEliminado(newVal) { this.localAlojamientoEliminado = newVal; },
    pasajeroEliminado(newVal) { this.localPasajeroEliminado = newVal; },
    pasajeroAgregado(newVal) { this.localPasajeroAgregado = newVal; },
    pasajeroModificado(newVal) { this.localPasajeroModificado = newVal; },
    reservaEliminada(newVal) { this.localReservaEliminada = newVal; }
  },
  methods: {
    volver() {
      this.$parent.cargaMenu();
    },
    cargaReserva(reserva) {
      this.localShowList = false;
      this.localReservaSeleccionada = reserva;
      this.localShowDetalle = true;
      this.localFechaEntrada = new Date();
      this.localFechaSalida = new Date();
      this.localPasajerosSeleccionados = reserva.pasajeros;
      if (this.localReservaSeleccionada.vuelo != null) {
        this.localVueloId = this.localReservaSeleccionada.vuelo.id;
      }
      else {
        this.localVueloId = null;
      }

      if (this.localReservaSeleccionada.actividad != null) {
        this.localActividadId = this.localReservaSeleccionada.actividad.id;
      }
      else {
        this.localActividadId = null;
      }

      if (this.localReservaSeleccionada.alojamiento != null) {
        this.localAlojamientoId = this.localReservaSeleccionada.alojamiento.id;
      }
      else {
        this.localAlojamientoId = null;
      }
      
      if (this.localPasajerosSeleccionados[0] == null) {
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
          })
          .then(() => {
            this.actualizar();
          });
      }
    },
    listaReservas() {
      this.localShowDetalle = false;
      this.localShowList = true;
      this.localShowEditarPasajero = false;
      this.localShowAgregarPasajero = false;
      this.init();
    },
    imprimirReserva() {
      print()
    },
    eliminarVuelo() {
      if (confirm("Desea eliminar este vuelo?"))
        this.$axios
          .put("https://localhost:57935/api/reserva/" +
            this.localReservaSeleccionada.id, {
            id: this.localReservaSeleccionada.id,
            nroReserva: this.localReservaSeleccionada.nroReserva,
            usuario: this.localReservaSeleccionada.usuario.id,
            destino: this.localReservaSeleccionada.destino.id,
            alojamiento: this.localAlojamientoId,
            actividad: this.localActividadId,
            vuelo: null,
            esUnPaquete: this.localReservaSeleccionada.esUnPaquete,
            paquete: this.localReservaSeleccionada.paquete,
            importe: this.localReservaSeleccionada.importe,
            pasajeros: this.localReservaSeleccionada.pasajeros,
            reservaFinalizada: this.localReservaSeleccionada.reservaFinalizada
          })
          .then(() => {
            this.actualizar();
          })
          .catch(() => {
            this.localVueloEliminado = false;
            setTimeout(() => this.localVueloEliminado = true, 2000);
          });
    },
    eliminarActividad() {
      if (confirm("Deses eliminar actividad?"))
        if (this.localReservaSeleccionada.paquete == null) {
          this.$axios
            .put("https://localhost:57935/api/reserva/" +
              this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              alojamiento: this.localAlojamientoId,
              actividad: null,
              vuelo: this.localVueloId,
              esUnPaquete: this.localReservaSeleccionada.esUnPaquete,
              paquete: null,
              importe: this.localReservaSeleccionada.importe,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              reservaFinalizada: false
            })
            .then(() => {
              this.actualizar();
            })
            .catch(() => {
              this.localActividadEliminada = false;
              setTimeout(() => this.localActividadEliminada = true, 2000);
            });
        }
        else {
          this.$axios
            .put("https://localhost:57935/api/reserva/" +
              this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              alojamiento: null,
              actividad: null,
              vuelo: null,
              esUnPaquete: this.localReservaSeleccionada.esUnPaquete,
              paquete: this.localReservaSeleccionada.paquete.id,
              importe: this.localReservaSeleccionada.importe,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              reservaFinalizada: true
            })
            .then(() => {
              this.actualizar();
            })
            .catch(() => {
              this.localActividadEliminada = false;
              setTimeout(() => this.localActividadEliminada = true, 2000);
            });
        }
    },
    eliminarAlojamiento() {
      if (confirm("Deses eliminar alojamiento?"))
        if (this.localReservaSeleccionada.paquete == null) {
          this.$axios
            .put("https://localhost:57935/api/reserva/" +
              this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              alojamiento: null,
              actividad: this.localActividadId,
              vuelo: this.localVueloId,
              esUnPaquete: this.localReservaSeleccionada.esUnPaquete,
              paquete: null,
              importe: this.localReservaSeleccionada.importe,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              reservaFinalizada: false
            })
            .then(() => {
              this.actualizar();
            })
            .catch(() => {
              this.localAlojamientoEliminado = false;
              setTimeout(() => this.localAlojamientoEliminado = true, 2000);
            });
        }
        else {
          this.$axios
            .put("https://localhost:57935/api/reserva/" +
              this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              alojamiento: null,
              actividad: null,
              vuelo: null,
              esUnPaquete: this.localReservaSeleccionada.esUnPaquete,
              paquete: this.localReservaSeleccionada.paquete.id,
              importe: this.localReservaSeleccionada.importe,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              reservaFinalizada: true
            })
            .then(() => {
              this.actualizar();
            })
            .catch(() => {
              this.localAlojamientoEliminado = false;
              setTimeout(() => this.localAlojamientoEliminado = true, 2000);
            });
        }
    },
    eliminarPasajero(pasajero) {
      if (confirm("Desea eliminar esta pasajero?"))
        this.$axios
          .delete("https://localhost:57935/api/pasajero/" + pasajero.id)
          .then(() => {
            this.actualizar();
          })
          .catch(() => {
            this.localPasajeroEliminado = false;
            setTimeout(() => this.localPasajeroEliminado = true, 2000);
          });
    },
    vistaModificarPasajero(pasajero) {
      this.localPasajeroToEdit = pasajero;
      this.localShowList = false;
      this.localShowDetalle = false;
      this.localShowEditarPasajero = true;
    },
    vistaAgregarPasajero() {
      this.localShowList = false;
      this.localShowDetalle = false;
      this.localShowAgregarPasajero = true;
    },
    vistaAbonarReserva() {
      this.localShowAbonarReserva = true;
      this.localShowList = false;
      this.localShowDetalle = false;
      this.localShowEditarPasajero = false;
    },
    agregarPasajero() {
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
            telefono: this.localTelefono
          })
          .then(() => {
            this.actualizar();
            this.localShowDetalle = true;
            this.localShowAgregarPasajero = false;
          })
          .catch(() => {
            this.localPasajeroAgregado = false;
            setTimeout(() => this.localPasajeroAgregado = true, 2000);
          });
    },
    modificarPasajero() {
      if (confirm("Desea Guardar Cambios?"))
        this.$axios
          .put("https://localhost:57935/api/pasajero/" + this.localPasajeroToEdit.id, {
            id: this.localPasajeroToEdit.id,
            nombre: this.localPasajeroToEdit.nombre,
            apellido: this.localPasajeroToEdit.apellido,
            dni: this.localPasajeroToEdit.dni,
            domicilio: this.localPasajeroToEdit.domicilio,
            mail: this.localPasajeroToEdit.mail,
            nacionalidad: this.localPasajeroToEdit.nacionalidad,
            reserva: this.localPasajeroToEdit.reserva,
            telefono: this.localPasajeroToEdit.telefono
          })
          .then(() => {
            this.actualizar();
            this.localShowDetalle = true;
            this.localShowEditarPasajero = false;
          })
          .catch(() => {
            this.localPasajeroModificado = false;
            setTimeout(() => this.localPasajeroModificado = true, 2000);
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
          if (this.localReservaSeleccionada.actividad != null) {
            this.localActividadId = this.localReservaSeleccionada.actividad.id;
          }
          else {
            this.localActividadId = null;
          }
          if (this.localReservaSeleccionada.alojamiento != null) {
            this.localAlojamientoId = this.localReservaSeleccionada.alojamiento.id;
          }
          else {
            this.localAlojamientoId = null;
          }
          this.localPasajerosSeleccionados = this.localReservaSeleccionada.pasajeros;
        });
    },
    eliminarReserva() {
      this.$parent.$parent.localReserva = null;
      // if (confirm("Desea eliminar reserva"))
      //   this.$axios
      //     .delete("https://localhost:57935/api/reserva/" + this.localReservaSeleccionada.id)
      //     .then(() => {
      //       this.localShowDetalle = false;
      //       this.localShowList = true;
      //       this.init();
      //     })
      //     .catch(() => {
      //       this.localReservaEliminada = false;
      //       setTimeout(() => this.localReservaEliminada = true, 2000);
      //     });
    },
    confirmarReserva() {
      if (confirm("Desea confirmar reserva?"))
        if (this.localReservaSeleccionada.paquete == null) {
          this.$axios
            .put("https://localhost:57935/api/reserva/" +
              this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              alojamiento: this.localAlojamientoId,
              actividad: this.localActividadId,
              vuelo: this.localVueloId,
              esUnPaquete: this.localReservaSeleccionada.esUnPaquete,
              paquete: null,
              importe: this.localReservaSeleccionada.importe,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              fechaEntrada: this.localFechaEntrada,
              fechaSalida: this.localFechaSalida,
              reservaFinalizada: true
            })
            .then(() => {
              this.localShowDetalle = false;
              this.localShowList = true;
              this.init();
            })
            .catch(() => {
              this.localReservaConfirmada = false;
              setTimeout(() => this.localReservaConfirmada = true, 2000);
            });
        }
        else {
          this.$axios
            .put("https://localhost:57935/api/reserva/" +
              this.localReservaSeleccionada.id, {
              id: this.localReservaSeleccionada.id,
              nroReserva: this.localReservaSeleccionada.nroReserva,
              usuario: this.localReservaSeleccionada.usuario.id,
              destino: this.localReservaSeleccionada.destino.id,
              alojamiento: null,
              actividad: null,
              vuelo: null,
              esUnPaquete: this.localReservaSeleccionada.esUnPaquete,
              paquete: this.localReservaSeleccionada.paquete.id,
              importe: this.localReservaSeleccionada.importe,
              pasajeros: this.localReservaSeleccionada.pasajeros,
              fechaEntrada: this.localFechaEntrada,
              fechaSalida: this.localFechaSalida,
              reservaFinalizada: true
            })
            .then(() => {
              this.localShowDetalle = false;
              this.localShowList = true;
              this.init();
            })
            .catch(() => {
              this.localReservaConfirmada = false;
              setTimeout(() => this.localReservaConfirmada = true, 2000);
            });
        }
    },
    isTrue(bool) {
      this.resultado = false;
      if (bool) {
        this.resultado = "Si";
      }
      else {
        this.resultado = "No";
      }
      return this.resultado;
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
}</style>