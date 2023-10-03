<template>
  <div>
    <div v-if="!localShowAbonarReserva">
      <div v-if="localShowDetalle">
        <main role="main" class="container">
          <div class="d-flex align-items-start flex-column p-3 my-3 bg-purple rounded box-shadow">
            <h1>Número Reserva: {{ localReservaSeleccionada.id }}</h1>
            <h3>Destino: {{ localReservaSeleccionada.destino.pais }}, {{ localReservaSeleccionada.destino.region }},
              {{ localReservaSeleccionada.destino.ciudad }}</h3>
            <h3>Total: ${{ localReservaSeleccionada.importe }}</h3>
          </div>
          <div v-show="!localVueloEliminado" class="alert alert-danger" role="alert">
            El vuelo no ha sido agregado, por favor intente nuevamente.
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
          <div class="d-flex align-items-start flex-column my-3 p-3 bg-white rounded box-shadow">
            <h2>Pasajeros</h2>
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
                  <td>
                    <button v-if="localReservaSeleccionada.reservaFinalizada == false"
                      @click="vistaModificarPasajero(pasajero)" class="btn">
                      <i class="fas fa-edit"></i>
                    </button>
                  </td>
                  <td>
                    <button v-if="localReservaSeleccionada.reservaFinalizada == false" @click="eliminarPasajero(pasajero)"
                      class="btn">
                      <i class="fa fa-trash"></i>
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </main>
        <div showMenu class="row">
          <div class="options text-center">
            <button @click="volverMenu" type="button" class="btn btn-lg btn-block btn-primary">Volver</button>
            <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="vistaAbonarReserva" type="button"
              class="btn btn-lg btn-block btn-primary">Ir a Abonar Reserva</button>
            <button v-if="!localReservaSeleccionada.reservaFinalizada" @click="eliminarReserva" type="button"
              class="btn btn-lg btn-block btn-primary">Eliminar Reserva</button>
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
                      Guardar Cambios
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="options text-center">
              <button @click="volverReserva" type="button"
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
                    <button @click="agregarPasajero()" type="submit" class="btn btn-lg btn-block btn-primary options">
                      Guardar Cambios
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
          <br />
          <div class="row">
            <div class="options text-center">
              <button @click="volverReserva" type="button"
                class="btn btn-lg btn-block btn-primary options text-center">Volver Al Menú</button>
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
      localPasajeroEliminado: this.pasajeroEliminado,
      localPasajeroAgregado: this.pasajeroAgregado,
      localPasajeroModificado: this.pasajeroModificado,
      localReservaEliminada: this.reservaEliminada,
      localReservaConfirmada: this.reservaConfirmada,
      localShowDetalle: this.showDetalle,
      localShowEditarPasajero: this.showEditarPasajero,
      localShowAgregarPasajero: this.showAgregarPasajero,
      localShowAbonarReserva: this.showAbonarReserva,
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
    pasajeroEliminado(newVal) { this.localPasajeroEliminado = newVal; },
    pasajeroAgregado(newVal) { this.localPasajeroAgregado = newVal; },
    pasajeroModificado(newVal) { this.localPasajeroModificado = newVal; },
    reservaEliminada(newVal) { this.localReservaEliminada = newVal; },
    reservaConfirmada(newVal) { this.localReservaConfirmada = newVal; },
    showDetalle(newVal) { this.localShowDetalle = newVal; },
    showEditarPasajero(newVal) { this.localShowEditarPasajero = newVal; },
    showAgregarPasajero(newVal) { this.localShowAgregarPasajero = newVal; },
    showAbonarReserva(newVal) { this.localShowAbonarReserva = newVal; },
  },
  methods: {
    volver() {
      this.$parent.cargaMenu();
    },
    volverMenu() {
      this.$parent.cargaHome();
    },
    volverReserva() {
      this.localShowEditarPasajero = false;
      this.localShowAgregarPasajero = false;
      this.localShowDetalle = true;
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
            vuelo: null,
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
      this.localShowDetalle = false;
      this.localShowEditarPasajero = true;
    },
    vistaAgregarPasajero() {
      this.localShowDetalle = false;
      this.localShowAgregarPasajero = true;
    },
    vistaAbonarReserva() {
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
            this.$parent.localReserva = null;
            this.$parent.localShowReservation = false;
            this.$parent.cargaHome();
          }).catch(() => {
            this.localReservaEliminada = false;
            setTimeout(() => this.localReservaEliminada = true, 2000);
          });
      }
    },
    confirmarReserva() {
      if (confirm("Desea confirmar reserva?")) {
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
            reservaFinalizada: true
          }).then(() => {
            this.$parent.localReserva = null;
            this.$parent.localShowReservation = false;
            this.$parent.cargaHome();
          }).catch(() => {
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
    async init() {
      this.localReservaSeleccionada = this.$parent.localReserva;
      this.localFechaEntrada = null;
      this.localFechaSalida = null;
      if (this.localReservaSeleccionada.vuelo != null) {
        this.localVueloId = this.localReservaSeleccionada.vuelo.id;
      }
      else {
        this.localVueloId = null;
      }
      this.localPasajerosSeleccionados = this.localReservaSeleccionada.pasajeros;
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
          }).then(() => {
            this.actualizar();
          });
      }
      this.actualizar();
    }
  },
  async mounted() {
    await this.init();
  },
  components: { VistaAbonar }
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