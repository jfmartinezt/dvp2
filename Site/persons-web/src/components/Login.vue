<template>
  <form id="frLogin" class="d-grid gap-3" @submit.prevent="login">
    <div v-if="showSuccess" class="alert alert-success" role="alert">
      Login success !
    </div>
    <div v-if="showError" class="alert alert-danger" role="alert">
      Login error: {{ result.description }}
    </div>
    <div class="form-group">
      <label for="input-loginr">Login</label>
      <input
        type="text"
        class="form-control"
        id="input-loginr"
        placeholder="Enter username"
        required
        v-model="loginData.login"
      />
    </div>
    <div class="form-group">
      <label for="input-passwordr">Password</label>
      <input
        type="password"
        class="form-control"
        id="input-passwordr"
        placeholder="Enter password"
        required
        v-model="loginData.pass"
      />
    </div>
    <button type="submit" class="btn btn-primary" :disabled="loading">
      Submit
    </button>
  </form>
</template>
<script>
import $ from "jquery";
export default {
  name: "Login",
  data() {
    return {
      loginData: {
        login: "",
        pass: "",
      },
      loading: false,
      showSuccess: false,
      showError: false,
      result: {}
    };
  },

  methods: {
    login() {
      this.loading = true;

      let vm = this;
      let params = {
        login: this.loginData.login,
        pass: this.loginData.pass,
      };

      $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "http://localhost:54066/Persons/user-login",
        data: JSON.stringify(params),
        success: function () {
          vm.loading = false;
          vm.showSuccess = true;
          vm.showError = false;
          vm.user = {};
        },
        error: function (msg) {
          vm.loading = false;
          vm.showSuccess = false;
          vm.showError = true;
          vm.result = msg.responseJSON;
        },
      });
    },
  },
};
</script>
