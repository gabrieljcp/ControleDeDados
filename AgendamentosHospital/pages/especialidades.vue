<template>
  <v-container fluid>
    <v-form ref="form" v-model="valid" lazy-validation>
      <h1 align="center" style="arial">Cadastro de Especialidades</h1>

      <v-select
        v-model="especialidades.nomeEspecialidade"
        :items="items"
        :rules="[(v) => !!v || 'Item obrigatório']"
        label="Selecione a Especialidade"
        required
      ></v-select>

      <v-text-field
        v-model="especialidades.nomeMedico"
        :counter="50"
        :rules="nameRules"
        label="Nome do Médico"
        required
      ></v-text-field>

      <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
        Cadastrar
      </v-btn>

      <v-btn color="error" class="mr-4" @click="reset">
        Limpar formulário
      </v-btn>
    </v-form>

    <v-toolbar color="white" class="mt-7" flat>
      <v-icon color="grey darken-2"> mdi-arrow-down </v-icon>

      <v-toolbar-title class="grey--text text--darken-4 ml-5">
        Especialidades Cadastradas
      </v-toolbar-title>
    </v-toolbar>
    <v-data-table
      :headers="headers"
      :items="especialidade"
      :items-per-page="5"
      class="elevation-1 mt-4"
    ></v-data-table>
  </v-container>
</template>>

<script>
export default {
  data: () => ({
    valid: true,
    especialidades: {
      nomeMedico: "",
      nomeEspecialidade: "",
    },
    nameRules: [
      (v) => !!v || "Obrigatório",
      (v) => (v && v.length <= 50) || "O nome deve ter menos que 50 caracteres",
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
        text: "Nome da Especialidade",
        align: "start",
        sortable: false,
        value: "nomeEspecialidade",
      },
      { text: "Nome do Médico", value: "nomeMedico" },
    ],
    especialidade: [
      {
        nomeEspecialidade: "Ortopedia",
        nomeMedico: "Lucas",
      },
    ],
  }),

  methods: {
    async submit() {
      debugger;

      try {
        var response = await this.$axios({
          method: "POST",
          url: "https://localhost:7234/Especialidades",
          data: this.especialidades,
        });

        debugger;

        var responseGet = await this.$axios({
          method: "GET",
          url: "https://localhost:7234/Especialidades",
          data: this.especialidades,
        });
        debugger;
        this.especialidade = responseGet.data;
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