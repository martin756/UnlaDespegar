<template>
  <div class="container">
    <div class="text-center">
      <div v-show="!localLoginExitoso" class="alert alert-danger" role="alert">
        Mail o contraseña incorrecta.
      </div>
      <div v-show="!localUpdateExitoso" class="alert alert-success" role="alert">
        Contraseña actualizada!.
      </div>
      <form class="needs-validation" novalidate ref="loginForm">
        <h1 class="h3 mb-3 font-weight-normal">{{localShowForgot || localShowValidationCode ? "Recuperar Contraseña" : "Iniciar Sesión"}}</h1>
        <div v-if="localShowMail">
          <label for="mail">Mail</label>
          <input type="text" class="form-control options" id="mail" v-model="localMail" required/>
          <div class="invalid-feedback">Ingrese un mail</div>
          <br />
        </div>
        <div v-if="localShowValidationCode">
          <label for="code">Ingrese el código de seguridad</label>
          <input type="password" class="form-control options" id="validationCode" v-model="localCode" required="" :pattern="localValidationCode.toString()" />
          <div class="invalid-feedback">{{!!localCode ? "El código no es correcto" : "Ingrese su código recibido"}}</div>
        </div>
        <div v-if="!localShowValidationCode && (localShowForgot || !localShowValidationMail)">
          <label for="password">{{ localShowForgot ? "Nueva Contraseña" : "Contraseña" }}</label>
          <input type="password" class="form-control options" id="password" v-model="localPassword" required/>
          <div class="invalid-feedback">Ingrese una contraseña</div>
          <br />
          <div v-if="localShowForgot">
            <label for="password">Repetir Contraseña</label>
            <input type="password" class="form-control options" id="newPassword" v-model="localNewPassword" 
              :pattern="localPassword" required="this.localShowForgot"/>
            <div class="invalid-feedback">Las contraseñas no coinciden</div>
            <br />
          </div>
        </div>
        <button v-if="!localShowValidationMail" @click="()=>{this.localShowValidationMail = true;}" 
          class="btn btn-forgot btn-lg btn-link btn-block options" type="button">Olvidé mi contraseña
        </button>
        <br />
        <button v-if="localShowMail && localShowValidationMail" @click="showValidationCodeForm"
          class="btn btn-lg btn-primary btn-block options" type="button">Recuperar contraseña
        </button>
        <button v-if="localShowValidationCode" @click="validateCode"
          class="btn btn-lg btn-primary btn-block options" type="button">Validar
        </button>
        <button v-if="!localShowValidationCode && (localShowForgot || !localShowValidationMail)" class="btn btn-lg btn-primary btn-block options" 
          type="button" @click="handleSubmit">{{localShowForgot ? "Aceptar" : "Iniciar Sesión"}}
        </button>
      </form>
      <br>
      <button @click="volver" class="btn btn-lg btn-primary btn-block options" type="button">Cancelar</button>
    </div>
  </div>
</template>
  
<script>
export default {
  name: "Login",
  props: {
    mail: null,
    password: null,
    newPassword: null,
    code: null,

    loginExitoso: {
      type: Boolean,
      default: true
    },
    updateExitoso: {
      type: Boolean,
      default: true
    },
    showForgot: {
      type: Boolean,
      default: false
    },
    showMail: {
      type: Boolean,
      default: true
    },
    showValidationCode: {
      type: Boolean,
      default: false
    },
    showValidationMail: {
      type: Boolean,
      default: false
    },
    validationCode: {
      type: Number,
      default: 12345678
    },
  },
  data() {
    return {
      localMail: this.mail,
      localPassword: this.password,
      localNewPassword: this.newPassword,
      localCode: this.code,

      localLoginExitoso: this.loginExitoso,
      localUpdateExitoso: this.updateExitoso,
      localShowForgot: this.showForgot,
      localShowMail: this.showMail,
      localShowValidationCode: this.showValidationCode,
      localShowValidationMail: this.showValidationMail,
      localValidationCode: this.validationCode,
    }
  },
  watch: {
    mail(newVal) { this.localMail = newVal; },
    password(newVal) { this.localPassword = newVal; },
    newPassword(newVal) { this.localNewPassword = newVal; },
    code(newVal) { this.localCode = newVal; },

    loginExitoso(newVal) {this.localLoginExitoso = newVal; },
    updateExitoso(newVal) {this.localUpdateExitoso = newVal; },
    showForgot(newVal) {this.localShowForgot = newVal; },
    showMail(newVal) {this.localShowMail = newVal; },
    showValidationCode(newVal) {this.localShowValidationCode = newVal; },
    showValidationMail(newVal) {this.localShowValidationMail = newVal; },
    validationCode(newVal) {this.localValidationCode = newVal; },
  },
  methods: {
    resetStates() {
      this.localShowForgot = false;
      this.localShowMail = true;
      this.localShowValidationCode = false;
      this.localShowValidationMail = false;
    },
    volver() {
      if (this.localShowForgot) {
        this.resetStates();
      } else {
        this.$parent.cargaHome();
      }
    },
    showValidationCodeForm() {
      const form = this.$refs.loginForm;
      if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
      } else {
        form.classList.remove('was-validated');
      }
      this.localShowMail = false;
      this.localShowValidationCode = true;
      console.log(this.validationCode);
    },
    validateCode() {
      const form = this.$refs.loginForm;
      if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
      } else {
        form.classList.remove('was-validated');
      }

      this.localCode = null;
      this.localShowValidationCode = false;
      this.localShowForgot = true;
    },
    cargaAdmin() {
      this.$parent.cargaAdmin();
    },
    handleSubmit() {
      const form = this.$refs.loginForm;
      if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
      } else {
        form.classList.remove('was-validated');
      }

      if (this.localShowForgot) {
        this.updatePassword();
      } else {
        this.login();
      }
    },
    login() {
      this.$axios
        .post('https://localhost:57935/api/auth/login', {
          mail: this.localMail,
          password: this.localPassword
        }).then((response) => {
          if (response.data.cod == 200) {
            sessionStorage.setItem('token', response.data.data);
            this.$parent.init();
          }
          if (response.data.cod == 401) {
            this.displayAlert("localLoginExitoso");
          }
        });
    },
    updatePassword() {
      this.$axios
        .put('https://localhost:57935/api/auth/updatePassword', {
          mail: this.localMail,
          password: this.localNewPassword
        }).then(() => {
          this.resetStates();
          this.displayAlert("localUpdateExitoso");
          this.localPassword = null;
          this.localNewPassword = null;
        }).catch(() => {
          this.displayAlert("localLoginExitoso");
        });
    },
    displayAlert(propName) {
      this[propName] = false;
      setTimeout(() => this[propName] = true, 2000)
    },
  },
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

.btn {
  width: 235px;
}

.btn-forgot {
  width: max-content;
  color: darkred;
}

.form-control {
  width: 500px;
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