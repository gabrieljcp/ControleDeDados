<template>
  <v-container fluid>
    <v-form ref="form" v-model="valid" lazy-validation>
      <h1 align="center" style="arial">Cadastro de Médicos</h1>
      <v-text-field
        v-model="medicos.nomeMedico"
        :counter="50"
        :rules="nameRules"
        label="Nome do Médico"
        required
      ></v-text-field>

      <v-text-field v-model="medicos.crm" label="CRM" required></v-text-field>

      <v-text-field
        v-model="medicos.email"
        :rules="emailRules"
        label="E-mail"
        required
      ></v-text-field>

      <v-text-field
        v-model="medicos.telefone"
        :counter="11"
        placeholder="(99)99999-9999"
        label="Telefone"
        required
      ></v-text-field>

      <v-select
        v-model="medicos.nomeEspecialidade"
        :items="items"
        :rules="[(v) => !!v || 'Item obrigatório']"
        label="Selecione a Especialidade"
        required
      ></v-select>

      <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
        Cadastrar Médico
      </v-btn>

      <v-btn color="error" class="mr-4" @click="reset">
        Limpar formulário
      </v-btn>
    </v-form>

    <v-toolbar color="white" class="mt-7" flat>
      <v-icon color="grey darken-2"> mdi-arrow-down </v-icon>

      <v-toolbar-title class="grey--text text--darken-4 ml-5">
        Médicos Cadastrados
      </v-toolbar-title>
    </v-toolbar>

    <v-data-table
      :headers="headers"
      :items="medico"
      :items-per-page="5"
      class="elevation-1 mt-4"
    ></v-data-table>
  </v-container>
</template>>

<script>
export default {
  data: () => ({
    valid: true,
    medicos: {
      nomeMedico: "",
      crm: "",
      email: "",
      telefone: "",
      nomeEspecialidade: "",
    },
    nameRules: [
      (v) => !!v || "Obrigatório",
      (v) => (v && v.length <= 50) || "O nome deve ter menos que 50 caracteres",
    ],
    emailRules: [
      (v) => !!v || "E-mail é obrigatório",
      (v) => /.+@.+/.test(v) || "E-mail deve ser válido",
    ],
    items: [
      "Clínica Médica",
      "Oftalmologista",
      "Ortopedista",
      "Odontologia",
      "Neurologia",
      "Cardiologia",
      "Diagnóstico por Imagem",
    ],
    headers: [
      {
        text: "Nome do Médico",
        align: "start",
        sortable: false,
        value: "nomeMedico",
      },
      { text: "CRM", value: "crm" },
      { text: "E-mail", value: "email" },
      { text: "Telefone", value: "telefone" },
      { text: "Especialidade", value: "nomeEspecialidade" },
    ],
    medico: [
      {
        nomeMedico: "Gabriel Yogurt",
        crm: "650654095",
        email: "email@medico.com",
        telefone: "619690906",
        nomeEspecialidade: "Ortopedia",
      },
    ],
  }),

  methods: {
    async submit() {
      debugger;

      try {
        var response = await this.$axios({
          method: "POST",
          url: "https://localhost:7234/Medicos",
          data: this.medicos,
        });

        debugger;

        var responseGet = await this.$axios({
          method: "GET",
          url: "https://localhost:7234/Medicos",
          data: this.medicos,
        });
        debugger;
        this.medico = responseGet.data;
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