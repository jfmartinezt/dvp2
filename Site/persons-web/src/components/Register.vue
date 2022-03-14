<template>
  <form id="frRegister" class="d-grid gap-3" @submit.prevent="addUser">
    <div v-if="showSuccess" class="alert alert-success" role="alert">
      Register success !
    </div>
    <div v-if="showError" class="alert alert-danger" role="alert">
      Register error: {{ result.description }}
    </div>
    <div class="form-group">
      <label for="input-name">First name</label>
      <input
        type="text"
        class="form-control"
        id="input-name"
        placeholder="Enter first name"
        required
        v-model="user.name"
      />
    </div>
    <div class="form-group">
      <label for="input-secondname">Second name</label>
      <input
        type="text"
        class="form-control"
        id="input-secondname"
        placeholder="Enter second name"
        v-model="user.surname"
        required
      />
    </div>
    <div class="form-group">
      <label for="select-documenttype">Document type</label>
      <select
        class="form-control"
        id="select-documenttype"
        placeholder="Document type"
        v-model="user.documentType"
        required
      >
        <option
          v-for="documentType in documentTypes"
          :key="documentType.id"
          :value="documentType.id"
        >
          {{ documentType.id }}
        </option>
      </select>
    </div>
    <div class="form-group">
      <label for="input-docnumber">Document number</label>
      <input
        type="text"
        class="form-control"
        id="input-docnumber"
        placeholder="Enter document number"
        v-model="user.documentNumber"
        required
      />
    </div>
    <div class="form-group">
      <label for="input-email">Email</label>
      <input
        type="email"
        class="form-control"
        id="input-email"
        placeholder="Enter email"
        required
        v-model="user.email"
      />
    </div>
    <div class="form-group">
      <label for="input-login">Login</label>
      <input
        type="text"
        class="form-control"
        id="input-login"
        placeholder="Enter username"
        required
        v-model="user.login"
      />
    </div>
    <div class="form-group">
      <label for="input-password">Password</label>
      <input
        type="password"
        class="form-control"
        id="input-password"
        placeholder="Enter password"
        required
        v-model="user.pass"
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
  name: "Register",
  data() {
    return {
      documentTypes: [],
      user: {
        name: "",
        surname: "",
        documentType: "",
        documentNumber: "",
        email: "",
        login: "",
        pass: "",
      },
      loading: false,
      result: {},
      showSuccess: false,
      showError: false,
    };
  },

  created() {
    this.documentTypes = [{ id: "CC", name: "Cedula" }];
  },

  methods: {
    addUser() {
      this.loading = true;

      let vm = this;
      let params = {
        name: this.user.name,
        surname: this.user.surname,
        document_type: this.user.documentType,
        document_number: this.user.documentNumber,
        email: this.user.email,
        login: this.user.login,
        pass: this.user.pass,
      };

      $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "http://localhost:54066/Persons/user-add",
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
          vm.result = msg.responseJSON.description;
        },
      });
    },
  },
};
</script>
