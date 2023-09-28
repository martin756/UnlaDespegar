<template>
  <div @load="cargaEdit">
    <h4 class="mb-3">Editar Usuario</h4>
    <div class="row">
      <div class="options text-center">
        <form class="needs-validation" novalidate>
          <div class="row options">
            <div>
              <label for="dni">DNI</label>
              <input type="number" min="1" class="form-control" id="dni" v-model="localDni" required />
              <div v-if="localDniAlert" class="alert alert-danger" role="alert">{{ localDniMessage }}</div>

              <label for="nombre">Nombre</label>
              <input type="text" class="form-control" id="nombre" v-model="localNombre" required />
              <div v-if="localNombreAlert" class="alert alert-danger" role="alert">{{ localNombreMessage }}</div>

              <label for="apellido">Apellido</label>
              <input type="text" class="form-control" id="apellido" v-model="localApellido" required />
              <div v-if="localApellidoAlert" class="alert alert-danger" role="alert">{{ localApellidoMessage }}</div>

              <label for="nacionalidad">Nacionalidad</label>
              <input type="text" class="form-control" id="nacionalidad" v-model="localNacionalidad" required />
              <div v-if="localNacionalidadAlert" class="alert alert-danger" role="alert">{{ localNacionalidadMessage }}</div>

              <label for="domicilio">Domicilio</label>
              <input type="text" class="form-control" id="domicilio" v-model="localDomicilio" required />
              <div v-if="localDomicilioAlert" class="alert alert-danger" role="alert">{{ localDomicilioMessage }}</div>

              <label for="mail">Mail</label>
              <input type="text" class="form-control" id="mail" v-model="localMail" required />
              <div v-if="localMailAlert" class="alert alert-danger" role="alert">{{ localMailMessage }}</div>

              <label for="password">Contraseña</label>
              <input type="password" class="form-control" id="password" v-model="localPassword" required />
              <div v-if="localPasswordAlert" class="alert alert-danger" role="alert">{{ localPasswordMessage }}</div>

              <label for="telefono">Telefono</label>
              <input type="text" class="form-control" id="telefono" v-model="localTelefono" required />
              <div v-if="localTelefonoAlert" class="alert alert-danger" role="alert">{{ localTelefonoMessage }}</div>

              <br />
              <button @click="submit" type="button" class="btn btn-lg btn-block btn-success options button-submit">
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
        <button @click="volver" type="button" class="btn btn-lg btn-block btn-danger options text-center">
          Volver Al Menú
        </button>
      </div>
    </div>
    <br>
  </div>
</template>

<script>
export default {
  name: "EditarPerfil",
  props: {
    showList: {
      type: Boolean,
      default: true
    },
    editElement: {
      type: Boolean,
      default: false
    },

    dni: null,
    dniAlert: {
      type: Boolean,
      default: false
    },
    dniMessage: null,

    nombre: null,
    nombreAlert: {
      type: Boolean,
      default: false
    },
    nombreMessage: null,

    apellido: null,
    apellidoAlert: {
      type: Boolean,
      default: false
    },
    apellidoMessage: null,

    nacionalidad: null,
    nacionalidadAlert: {
      type: Boolean,
      default: false
    },
    nacionalidadMessage: null,

    domicilio: null,
    domicilioAlert: {
      type: Boolean,
      default: false
    },
    domicilioMessage: null,

    mail: null,
    mailAlert: {
      type: Boolean,
      default: false
    },
    mailMessage: null,

    password: null,
    passwordAlert: {
      type: Boolean,
      default: false
    },
    passwordMessage: null,

    telefono: null,
    telefonoAlert: {
      type: Boolean,
      default: false
    },
    telefonoMessage: null,

    current_user: null,
    user_to_modify_id: {
      type: Number,
      default: 0
    },
    isValid: null
  },
  data() {
    return {
      localShowList: this.showList,
      localEditElement: this.editElement,

      localDni: this.dni,
      localDniAlert: this.dniAlert,
      localDniMessage: this.dniMessage,
      
      localNombre: this.nombre,
      localNombreAlert: this.nombreAlert,
      localNombreMessage: this.nombreMessage,
      
      localApellido: this.apellido,
      localApellidoAlert: this.apellidoAlert,
      localApellidoMessage: this.apellidoMessage,

      localNacionalidad: this.nacionalidad,
      localNacionalidadAlert: this.nacionalidadAlert,
      localNacionalidadMessage: this.nacionalidadMessage,

      localDomicilio: this.domicilio,
      localDomicilioAlert: this.domicilioAlert,
      localDomicilioMessage: this.domicilioMessage,
      
      localMail: this.mail,
      localMailAlert: this.mailAlert,
      localMailMessage: this.mailMessage,
      
      localPassword: this.password,
      localPasswordAlert: this.passwordAlert,
      localPasswordMessage: this.passwordMessage,
      
      localTelefono: this.telefono,
      localTelefonoAlert: this.telefonoAlert,
      localTelefonoMessage: this.telefonoMessage,

      localCurrentUser: this.current_user,
      localUserToModifyId: this.user_to_modify_id,
      localIsValid: this.isValid
    };
  },
  watch: {
    showList(newVal) { this.localShowList = newVal; },
    editElement(newVal) { this.localEditElement = newVal; },

    dni(newVal) { this.localDni = newVal; },
    dniAlert(newVal) { this.localDniAlert = newVal; },
    dniMessage(newVal) { this.localDniMessage = newVal; },
    nombre(newVal) { this.localNombre = newVal; },
    nombreAlert(newVal) { this.localNombreAlert = newVal; },
    nombreMessage(newVal) { this.localNombreMessage = newVal; },
    apellido(newVal) { this.localApellido = newVal; },
    apellidoAlert(newVal) { this.localApellidoAlert = newVal; },
    apellidoMessage(newVal) { this.localApellidoMessage = newVal; },
    nacionalidad(newVal) { this.localNacionalidad = newVal; },
    nacionalidadAlert(newVal) { this.localNacionalidadAlert = newVal; },
    nacionalidadMessage(newVal) { this.localNacionalidadMessage = newVal; },
    domicilio(newVal) { this.localDomicilio = newVal; },
    domicilioAlert(newVal) { this.localDomicilioAlert = newVal; },
    domicilioMessage(newVal) { this.localDomicilioMessage = newVal; },
    mail(newVal) { this.localMail = newVal; },
    mailAlert(newVal) { this.localMailAlert = newVal; },
    mailMessage(newVal) { this.localMailMessage = newVal; },
    password(newVal) { this.localPassword = newVal; },
    passwordAlert(newVal) { this.localPasswordAlert = newVal; },
    passwordMessage(newVal) { this.localPasswordMessage = newVal; },
    telefono(newVal) { this.localTelefono = newVal; },
    telefonoAlert(newVal) { this.localTelefonoAlert = newVal; },
    telefonoMessage(newVal) { this.localTelefonoMessage = newVal; },

    current_user(newVal) { this.localCurrentUser = newVal; },
    user_to_modify_id(newVal) { this.localUserToModifyId = newVal; },
    isValid(newVal) { this.localIsValid = newVal; },
  },
  methods: {
    volver() {
      this.$parent.cargaMenu();
    },
    cargaEdit() {
      this.localDni = this.$parent.localCurrentUser[0].dni;
      this.localNombre = this.$parent.localCurrentUser[0].nombre;
      this.localApellido = this.$parent.localCurrentUser[0].apellido;
      this.localNacionalidad = this.$parent.localCurrentUser[0].nacionalidad;
      this.localDomicilio = this.$parent.localCurrentUser[0].domicilio;
      this.localMail = this.$parent.localCurrentUser[0].mail;
      this.localPassword = this.$parent.localCurrentUser[0].password;
      this.localTelefono = this.$parent.localCurrentUser[0].telefono;
      this.localUserToModifyId = this.$parent.localCurrentUser[0].id;
    },
    validar() {
      this.localIsValid = true;

      const campos = [
        { nombre: 'localDni', message: 'Ingrese un DNI', alert: 'localDniAlert' },
        { nombre: 'localNombre', message: 'Ingrese un nombre', alert: 'localNombreAlert' },
        { nombre: 'localApellido', message: 'Ingrese un apellido', alert: 'localApellidoAlert' },
        { nombre: 'localNacionalidad', message: 'Ingrese una nacionalidad', alert: 'localNacionalidadAlert' },
        { nombre: 'localDomicilio', message: 'Ingrese un domicilio', alert: 'localDomicilioAlert' },
        { nombre: 'localMail', message: 'Ingrese un email', alert: 'localMailAlert' },
        { nombre: 'localPassword', message: 'Ingrese una contraseña', alert: 'localPasswordAlert' },
        { nombre: 'localTelefono', message: 'Ingrese un telefono', alert: 'localTelefonoAlert' }
      ];

      for (const campo of campos) {
        if (!this[campo.nombre]) {
          this[campo.alert] = true;
          this[campo.nombre + 'Message'] = campo.message;
          this.localIsValid = false;
        } else {
          this[campo.alert] = false;
        }
      }

      return this.localIsValid;
    },
    actualizarDatos() {
      this.$parent.localCurrentUser[0].dni = this.localDni;
      this.$parent.localCurrentUser[0].nombre = this.localNombre;
      this.$parent.localCurrentUser[0].apellido = this.localApellido;
      this.$parent.localCurrentUser[0].nacionalidad = this.localNacionalidad;
      this.$parent.localCurrentUser[0].domicilio = this.localDomicilio;
      this.$parent.localCurrentUser[0].mail = this.localMail
      this.$parent.localCurrentUser[0].password = this.localPassword;
      this.$parent.localCurrentUser[0].telefono = this.localTelefono;
      this.$parent.localCurrentUser[0].id = this.localUserToModifyId;
      this.$parent.cargaMenu();
    },
    submit() {
      if (this.validar()) {
        this.$axios
          .put(
            "https://localhost:57935/api/usuario/" + this.localUserToModifyId,
            {
              id: this.localUserToModifyId,
              dni: this.localDni,
              nombre: this.localNombre,
              apellido: this.localApellido,
              nacionalidad: this.localNacionalidad,
              domicilio: this.localDomicilio,
              mail: this.localMail,
              contraseña: this.localPassword,
              telefono: this.localTelefono
            }
          )
          .then(() => this.actualizarDatos());
      }
    },
    init() {
      this.cargaEdit();
    }
  },
  mounted() {
    this.init();
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.container {
  max-width: 960px;
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

.btn {
  width: 200px;
}

.btn-primary {
  color: #fff;
  background-color: darkred;
  border-color: black;
}
</style>