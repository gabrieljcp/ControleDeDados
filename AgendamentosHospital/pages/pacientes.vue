<template>
  <v-container fluid>
    <v-form ref="form" v-model="valid" lazy-validation>
      <h1 align="center" style="arial">Cadastro de Pacientes</h1>
      <v-text-field
        v-model="paciente.nomePaciente"
        :counter="50"
        :rules="nameRules"
        label="Nome do Paciente"
        required
      ></v-text-field>

      <v-text-field
        v-model="paciente.especie"
        :counter="30"
        label="Espécie"
        required
      ></v-text-field>

      <v-text-field
        v-model="paciente.raca"
        :counter="50"
        label="Raça"
        required
      ></v-text-field>

      <v-radio-group v-model="paciente.castrado" label="Castrado?" row>
        <v-radio label="Sim" value="Sim"></v-radio>
        <v-radio label="Não" value="Não"></v-radio>
      </v-radio-group>

      <v-select
        v-model="paciente.corPelo"
        :items="items"
        :rules="[(v) => !!v || 'Item obrigatório']"
        label="Selecione a cor do pelo do animal"
        required
      ></v-select>

      <v-col class="pa-10 mx-4 mt-4 mt-sm-0">
        <div>Data de Nascimento</div>
        <v-date-picker
          v-model="paciente.dataNascimento"
          year-icon="mdi-calendar-blank"
          prev-icon="mdi-skip-previous"
          next-icon="mdi-skip-next"
          color="green lighten-1"
          locale="BR"
        ></v-date-picker>
      </v-col>

      <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
        Cadastrar paciente
      </v-btn>

      <v-btn color="error" class="mr-4" @click="reset">
        Limpar formulário
      </v-btn>
    </v-form>

    <v-toolbar color="white" class="mt-7" flat>
      <v-icon color="grey darken-2"> mdi-arrow-down </v-icon>

      <v-toolbar-title class="grey--text text--darken-4 ml-5">
        Pacientes Cadastrados
      </v-toolbar-title>
    </v-toolbar>

    <v-data-table
      :headers="headers"
      :items="pacientes"
      :items-per-page="5"
      class="elevation-1 mt-4"
    ></v-data-table>
  </v-container>
</template>>

<script>
export default {
  data: () => ({
    valid: true,
    paciente: {
      nomePaciente: "",
      especie: "",
      raca: "",
      castrado: "",
      corPelo: "",
      dataNascimento: "",
    },
    nameRules: [
      (v) => !!v || "Obrigatório",
      (v) => (v && v.length <= 50) || "O nome deve ter menos que 50 caracteres",
    ],
    items: [
      "Preta",
      "Branca",
      "Amarela",
      "Bege",
      "Marrom",
      "Cinza",
      "Golden",
      "Caramelo",
      "Preta e branca",
      "Preta e bege",
      "Preta e marrom",
      "Branca e bege",
      "Branca e marrom",
    ],
    headers: [
      {
        text: "Nome do Paciente",
        align: "start",
        sortable: false,
        value: "nomePaciente",
      },
      { text: "Espécie", value: "especie" },
      { text: "Raça", value: "raca" },
      { text: "Castrado", value: "castrado" },
      { text: "Cor do pêlo", value: "corPelo" },
      { text: "Data de Nascimento", value: "dataNascimento" },
    ],
    pacientes: [
      {
        nomePaciente: "Frozen Yogurt",
        especie: "Canina",
        raca: "Golden",
        castrado: "Sim",
        corPelo: "Preta",
        dataNascimento: "15-10-2010",
      },
    ],
  }),

  methods: {
    async submit() {
      debugger;

      try {
        var response = await this.$axios({
          method: "POST",
          url: "https://localhost:7234/Pacientes",
          data: this.paciente,
        });

        debugger;

        var responseGet = await this.$axios({
          method: "GET",
          url: "https://localhost:7234/Pacientes",
          data: this.paciente,
        });
        debugger;
        this.pacientes = responseGet.data;
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