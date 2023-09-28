<template>
  <div class="text-center">
    <h4 class="mb-3">Ingrese sus datos personales</h4>
    <div class="row options">

      <div v-show="!localMailValido" class="alert alert-danger" role="alert">
        Mail o contraseña incorrecta.
      </div>
      <div class="options text-center">
        <form class="needs-validation" novalidate>
          <div class="row options">
            <div>
              <label for="dni">DNI</label>
              <input type="number" min="1" class="form-control" id="dni" v-model="localDni" required />
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

              <label for="password">Contraseña</label>
              <input type="password" class="form-control" id="password" v-model="localPassword" required />
              <p v-if="localPasswordAlert" class="color-red">{{ localPasswordMessage }}</p>

              <label for="telefono">Telefono</label>
              <input type="text" class="form-control" id="telefono" v-model="localTelefono" required />
              <p v-if="localTelefonoAlert" class="color-red">{{ localTelefonoMessage }}</p>

              <br />
              <button @click="submit" type="button" class="btn btn-lg btn-block btn-primary options">
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
        <button @click="volver" type="button" class="btn btn-lg btn-block btn-primary options text-center">
          Volver Al Menú
        </button>
      </div>
    </div>
    <br />
  </div>
</template>

<script>
export default {
  name: "Registro",
  props: {
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

    mailValido: {
      type: Boolean,
      default: true
    },
    isValid: null
  },
  data() {
    return {
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

      localMailValido: this.mailValido,
      localIsValid: this.isValid
    };
  },
  watch: {
    dni(newVal) {
      this.localDni = newVal;
    },
    dniAlert(newVal) {
      this.localDniAlert = newVal;
    },
    dniMessage(newVal) {
      this.localDniMessage = newVal;
    },
    
    nombre(newVal) {
      this.localNombre = newVal;
    },
    nombreAlert(newVal) {
      this.localNombreAlert = newVal;
    },
    nombreMessage(newVal) {
      this.localNombreMessage = newVal;
    },
    
    apellido(newVal) {
      this.localApellido = newVal;
    },
    apellidoAlert(newVal) {
      this.localApellidoAlert = newVal;
    },
    apellidoMessage(newVal) {
      this.localApellidoMessage = newVal;
    },

    nacionalidad(newVal) {
      this.localNacionalidad = newVal;
    },
    nacionalidadAlert(newVal) {
      this.localNacionalidadAlert = newVal;
    },
    nacionalidadMessage(newVal) {
      this.localNacionalidadMessage = newVal;
    },

    domicilio(newVal) {
      this.localDomicilio = newVal;
    },
    domicilioAlert(newVal) {
      this.localDomicilioAlert = newVal;
    },
    domicilioMessage(newVal) {
      this.localDomicilioMessage = newVal;
    },
    
    mail(newVal) {
      this.localMail = newVal;
    },
    mailAlert(newVal) {
      this.localMailAlert = newVal;
    },
    mailMessage(newVal) {
      this.localMailMessage = newVal;
    },
    
    password(newVal) {
      this.localPassword = newVal;
    },
    passwordAlert(newVal) {
      this.localPasswordAlert = newVal;
    },
    passwordMessage(newVal) {
      this.localPasswordMessage = newVal;
    },
    
    telefono(newVal) {
      this.localTelefono = newVal;
    },
    telefonoAlert(newVal) {
      this.localTelefonoAlert = newVal;
    },
    telefonoMessage(newVal) {
      this.localTelefonoMessage = newVal;
    },

    mailValido(newVal) {
      this.localMailValido = newVal;
    },
    isValid(newVal) {
      this.localIsValid = newVal;
    }
  },
  methods: {
    volver() {
      this.$parent.cargaHome();
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
    submit() {
      if (this.validar()) {
        this.$axios
          .post("https://localhost:57935/api/usuario", {
            dni: this.localDni,
            nombre: this.localNombre,
            apellido: this.localApellido,
            nacionalidad: this.localNacionalidad,
            domicilio: this.localDomicilio,
            mail: this.localMail,
            contraseña: this.localPassword,
            telefono: this.localTelefono,
            isAdmin: false
          })
          .then(() => {
            this.volver();
          })
          .catch(() => {
            this.localMailValido = false;
            setTimeout(() => this.localMailValido = true, 2000)
          });
      }
    }
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