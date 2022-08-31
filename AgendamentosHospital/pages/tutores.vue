<template>
  <v-container fluid>
    <v-form ref="form" v-model="valid" lazy-validation>
      <h1 align="center" style="arial">Cadastro de Tutores</h1>
      <v-text-field
        v-model="tutores.nomeTutor"
        :counter="50"
        :rules="nameRules"
        label="Nome do Tutor"
        required
      ></v-text-field>

      <v-text-field
        v-model="tutores.endereco"
        label="Endereço"
        required
      ></v-text-field>

      <v-text-field
        v-model="tutores.email"
        :rules="emailRules"
        label="E-mail"
        required
      ></v-text-field>

      <v-text-field
        v-model="tutores.telefone"
        :counter="11"
        placeholder="(99)99999-9999"
        label="Telefone"
        type="number"
        required
      ></v-text-field>

      <v-text-field
        v-model="tutores.nomePaciente"
        label="Nome do Paciente"
        required
      ></v-text-field>

      <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
        Cadastrar Tutor
      </v-btn>

      <v-btn color="error" class="mr-4" @click="reset">
        Limpar formulário
      </v-btn>
    </v-form>

    <v-toolbar color="white" class="mt-7" flat>
      <v-icon color="grey darken-2"> mdi-arrow-down </v-icon>

      <v-toolbar-title class="grey--text text--darken-4 ml-5">
        Tutores Cadastrados
      </v-toolbar-title>
    </v-toolbar>

    <v-data-table
      :headers="headers"
      :items="tutor"
      :items-per-page="5"
      class="elevation-1 mt-4"
    ></v-data-table>
  </v-container>
</template>>

<script>
export default {
  data: () => ({
    valid: true,
    tutores: {
      nomeTutor: "",
      endereco: "",
      email: "",
      telefone: "",
      nomePaciente: "",
    },
    nameRules: [
      (v) => !!v || "Obrigatório",
      (v) => (v && v.length <= 50) || "O nome deve ter menos que 50 caracteres",
    ],
    emailRules: [
      (v) => !!v || "E-mail é obrigatório",
      (v) => /.+@.+/.test(v) || "E-mail deve ser válido",
    ],
    headers: [
      {
        text: "Nome do Tutor",
        align: "start",
        sortable: false,
        value: "nomeTutor",
      },
      { text: "Endereço", value: "endereco" },
      { text: "E-mail", value: "email" },
      { text: "Telefone", value: "telefone" },
      { text: "Nome do Paciente", value: "nomePaciente" },
    ],
    tutor: [
      {
        nomeTutor: "Gabriel Yogurt",
        endereco: "Brasília",
        email: "gabriel@email.com",
        telefone: "61469494694",
        nomePaciente: "Frozen Yogurt",
      },
    ],
  }),

  methods: {
    async submit() {
      debugger;

      try {
        var response = await this.$axios({
          method: "POST",
          url: "https://localhost:7234/Tutores",
          data: this.tutores,
        });

        debugger;

        var responseGet = await this.$axios({
          method: "GET",
          url: "https://localhost:7234/Tutores",
          data: this.tutores,
        });
        debugger;
        this.tutor = responseGet.data;
      } catch {}
    },
    reset() {
      this.$refs.form.reset();
    },
  },
};
</script>

<style>
</style>