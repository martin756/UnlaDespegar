<template>
  <div class="container">
    <div class="text-center">
      <div v-show="!localLoginExitoso" class="alert alert-danger" role="alert">
        Mail o contraseña incorrecta.
      </div>
      <form class="form-signin">
        <h1 class="h3 mb-3 font-weight-normal">Iniciar Sesión</h1>
        <label for="mail">Mail</label>
        <input type="text" class="form-control options" id="mail" v-model="localMail" required />
        <div v-if="localMailAlert" class="alert alert-danger" role="alert">{{ localMailMessage }}</div>
        <br />
        <label for="password">Contraseña</label>
        <input type="password" class="form-control options" id="password" v-model="localPassword" required />
        <div v-if="localPasswordAlert" class="alert alert-danger" role="alert">{{ localPasswordMessage }}</div>
        <br />
        <button @click="login" class="btn btn-lg btn-primary btn-block options" type="submit">Iniciar Sesion</button>
      </form>
      <br>
      <button @click="volver" class="btn btn-lg btn-primary btn-block options" type="submit">Cancelar</button>
    </div>
  </div>
</template>
  
<script>
export default {
  name: "Login",
  props: {
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

    loginExitoso: {
      type: Boolean,
      default: true
    },
  },
  data() {
    return {
      localMail: this.mail,
      localMailAlert: this.mailAlert,
      localMailMessage: this.mailMessage,

      localPassword: this.password,
      localPasswordAlert: this.passwordAlert,
      localPasswordMessage: this.passwordMessage,

      localLoginExitoso: this.loginExitoso
    }
  },
  watch: {
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

    loginExitoso(newVal) {
      this.localLoginExitoso = newVal;
    }
  },
  methods: {
    volver() {
      this.$parent.cargaHome();
    },
    cargaAdmin() {
      this.$parent.cargaAdmin();
    },
    validar() {
      this.localIsValid = true;

      const campos = [
        { nombre: 'localMail', message: 'Ingrese un email', alert: 'localMailAlert' },
        { nombre: 'localPassword', message: 'Ingrese una contraseña', alert: 'localPasswordAlert' }
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
    login(e) {
      e.preventDefault();
      if (this.validar()) {
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
              this.localLoginExitoso = false;
              setTimeout(() => this.localLoginExitoso = true, 2000)
            }
          });
      }
    }
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

.form-control {
  width: 500px;
}

.btn-primary {
  color: #fff;
  background-color: darkred;
  border-color: black;
}
</style>