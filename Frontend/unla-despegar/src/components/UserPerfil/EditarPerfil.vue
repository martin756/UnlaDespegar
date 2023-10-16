<template>
  <div @load="cargaEdit">
    <h4 class="mb-3">Editar Usuario</h4>
    <div class="row">
      <div class="options text-center">
        <form class="needs-validation" novalidate ref="editarForm" @submit.prevent="submit">
          <div class="row options">
            <div>
              <label for="dni">DNI</label>
              <input type="number" min="1" class="form-control" id="dni" v-model="localDni" required />
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

              <label for="password">Contraseña</label>
              <input type="password" class="form-control" id="password" v-model="localPassword" required />
              <div class="invalid-feedback">Ingrese una contraseña</div>

              <label for="telefono">Teléfono</label>
              <input type="text" class="form-control" id="telefono" v-model="localTelefono" required />
              <div class="invalid-feedback">Ingrese un teléfono de contacto</div>

              <br />
              <button type="submit" class="btn btn-lg btn-block btn-primary options button-submit">
                <i class="fas fa-save"></i> Guardar Cambios
              </button>
              <br />
              <button @click="volver" type="button" class="btn btn-lg btn-block btn-primary options text-center">
                <i class="fas fa-arrow-left"></i> Volver Al Menú
              </button>
            </div>
          </div>
        </form>
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
    nombre: null,
    apellido: null,
    nacionalidad: null,
    domicilio: null,
    mail: null,
    password: null,
    telefono: null,

    current_user: null,
    user_to_modify_id: {
      type: Number,
      default: 0
    },
  },
  data() {
    return {
      localShowList: this.showList,
      localEditElement: this.editElement,

      localDni: this.dni,
      localNombre: this.nombre,
      localApellido: this.apellido,
      localNacionalidad: this.nacionalidad,
      localDomicilio: this.domicilio,
      localMail: this.mail,
      localPassword: this.password,
      localTelefono: this.telefono,

      localCurrentUser: this.current_user,
      localUserToModifyId: this.user_to_modify_id,
    };
  },
  watch: {
    showList(newVal) { this.localShowList = newVal; },
    editElement(newVal) { this.localEditElement = newVal; },

    dni(newVal) { this.localDni = newVal; },
    nombre(newVal) { this.localNombre = newVal; },
    apellido(newVal) { this.localApellido = newVal; },
    nacionalidad(newVal) { this.localNacionalidad = newVal; },
    domicilio(newVal) { this.localDomicilio = newVal; },
    mail(newVal) { this.localMail = newVal; },
    password(newVal) { this.localPassword = newVal; },
    telefono(newVal) { this.localTelefono = newVal; },

    current_user(newVal) { this.localCurrentUser = newVal; },
    user_to_modify_id(newVal) { this.localUserToModifyId = newVal; },
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
      const form = this.$refs.editarForm;
      if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
      }
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
  width: 100%;
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