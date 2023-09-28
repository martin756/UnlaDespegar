<template>
  <div class="text-center">
    <h4 class="mb-3">Abone su reserva</h4>
    <div class="row justify-content-center options">
      <div class="col-md-8 order-md-1">
        <form class="needs-validation" novalidate ref="abonarForm" @submit.prevent="submitForm">
          <div class="d-block my-3 t-align-start">
            <div class="custom-control custom-radio">
              <input id="credit" name="paymentMethod" type="radio" class="custom-control-input" checked="" required="">
              <label class="custom-control-label" for="credit">Tarjeta de crédito</label>
            </div>
            <div class="custom-control custom-radio">
              <input id="debit" name="paymentMethod" type="radio" class="custom-control-input" required="">
              <label class="custom-control-label" for="debit">Tarjeta de débito</label>
            </div>
          </div>
          <div class="row">
            <div class="col-md-6 mb-3">
              <label for="cc-name">Nombre en tarjeta</label>
              <input type="text" class="form-control" id="cc-name" placeholder="" required="">
              <small class="text-muted">Nombre completo como aparece en la tarjeta</small>
              <div class="invalid-feedback">
                Nombre en tarjeta requerida
              </div>
            </div>
            <div class="col-md-6 mb-3">
              <label for="cc-number">Numero de tarjeta</label>
              <input type="text" class="form-control" id="cc-number" placeholder="" required="">
              <div class="invalid-feedback">
                Numero de tarjeta requerida
              </div>
            </div>
          </div>
          <div class="row justify-content-center">
            <div class="col-md-3 mb-3">
              <label for="cc-expiration">Fecha de expiración</label>
              <input type="text" class="form-control" id="cc-expiration" placeholder="" required="">
              <div class="invalid-feedback">
                Fecha de expiración requerida
              </div>
            </div>
            <div class="col-md-3 mb-3">
              <label for="cc-expiration">CVV</label>
              <input type="text" class="form-control" id="cc-cvv" placeholder="" required="">
              <div class="invalid-feedback">
                Código de seguridad requerido
              </div>
            </div>
          </div>
          <hr class="mb-4">
          <button class="btn btn-primary btn-lg btn-block" type="submit"
            v-if="!this.$parent.localReservaSeleccionada.reservaFinalizada">
            Confirmar Reserva
          </button>
        </form>
      </div>
    </div>
    <br />
    <div class="row">
      <div class="options text-center">
        <button @click="volver" type="button" class="btn btn-lg btn-block btn-primary">
          Volver
        </button>
      </div>
    </div>
    <br/>
  </div>
</template>

<script>
export default {
  name: "Abonar",
  methods: {
    volver() {
      this.$parent.localShowEditarPasajero = false;
      this.$parent.localShowAgregarPasajero = false;
      this.$parent.localShowDetalle = true;
      this.$parent.localShowAbonarReserva = false;
    },
    submitForm() {
      const form = this.$refs.abonarForm;
      if (!form.checkValidity()) {
        form.classList.add('was-validated');
        return;
      }
      this.$parent.confirmarReserva();
    },
  },
}
</script>

<style scoped>
.options {
  margin: auto;
}
.btn-primary {
  color: #fff;
  background-color: darkred;
  border-color: black;
}
.container {
  max-width: 960px;
}
.custom-control-input:checked ~ .custom-control-label::before {
  color: #fff;
  border-color: darkred;
  background-color: darkred;
}
.border-top { border-top: 1px solid #e5e5e5; }
.border-bottom { border-bottom: 1px solid #e5e5e5; }
.border-top-gray { border-top-color: #adb5bd; }
.box-shadow { box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05); }
.lh-condensed { line-height: 1.25; }
</style>