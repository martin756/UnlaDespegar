<template>
  <div class="container">
    <div class="text-center">
      <div v-show="!localLoginExitoso" class="alert alert-danger" role="alert">
        Mail o contraseña incorrecta.
      </div>
      <div v-show="!localUpdateExitoso" class="alert alert-success" role="alert">
        Contraseña actualizada!.
      </div>
      <form class="needs-validation" novalidate ref="loginForm" @submit.prevent="handleSubmit">
        <h1 class="h3 mb-3 font-weight-normal">{{localShowForgot ? "Recuperar Contraseña" : "Iniciar Sesión"}}</h1>
        <label for="mail">Mail</label>
        <input type="text" class="form-control options" id="mail" v-model="localMail" required/>
        <div class="invalid-feedback">Ingrese un mail</div>
        <br />
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
        <button v-if="!localShowForgot" @click="()=>{this.localShowForgot = true;}" 
          class="btn btn-forgot btn-lg btn-link btn-block options" type="button">Olvidé mi contraseña
        </button>
        <br />
        <button class="btn btn-lg btn-primary btn-block options" 
          type="submit">{{localShowForgot ? "Aceptar" : "Iniciar Sesión"}}
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
    newPasswordMessage: null,

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
    }
  },
  data() {
    return {
      localMail: this.mail,
      localPassword: this.password,
      localNewPassword: this.newPassword,

      localLoginExitoso: this.loginExitoso,
      localUpdateExitoso: this.updateExitoso,
      localShowForgot: this.showForgot
    }
  },
  watch: {
    mail(newVal) { this.localMail = newVal; },
    password(newVal) { this.localPassword = newVal; },
    newPassword(newVal) { this.localNewPassword = newVal; },
    newPasswordMessage(newVal) { this.localNewPasswordMessage = newVal; },

    loginExitoso(newVal) {this.localLoginExitoso = newVal; },
    updateExitoso(newVal) {this.localUpdateExitoso = newVal; },
    showForgot(newVal) {this.localShowForgot = newVal; }
  },
  methods: {
    volver() {
      if (this.localShowForgot) {
        this.localShowForgot = false;
      } else {
        this.$parent.cargaHome();
      }
    },
    cargaAdmin() {
      this.$parent.cargaAdmin();
    },
    handleSubmit() {
      const form = this.$refs.loginForm;
      if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
      }

      if (this.localShowForgot) {
        this.updatePassword()
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
            localStorage.setItem('token', response.data.data);
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
          this.localShowForgot = false;
          this.displayAlert("localUpdateExitoso");
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
  width: 200px;
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
</style>