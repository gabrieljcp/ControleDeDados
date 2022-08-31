<template>
  <v-container fluid>
    <v-form ref="form" v-model="valid" lazy-validation>
      <h1 align="center" style="arial">Agendamento de Consulta</h1>
      <v-text-field
        v-model="consulta.nomePaciente"
        :counter="50"
        :rules="nameRules"
        label="Nome do Paciente"
        required
      ></v-text-field>

      <v-text-field
        v-model="consulta.nomeTutor"
        :counter="50"
        :rules="nameRules"
        label="Nome do Tutor"
        required
      ></v-text-field>

      <v-text-field
        v-model="consulta.nomeMedico"
        :counter="50"
        :rules="nameRules"
        label="Nome do Médico"
        required
      ></v-text-field>

      <v-select
        v-model="consulta.nomeEspecialidade"
        :items="items"
        :rules="[(v) => !!v || 'Item obrigatório']"
        label="Selecione a Especialidade do Atendimento"
      ></v-select>

      <v-row align="center">
        <v-col class="pa-10 mx-4 mt-4 mt-sm-0">
          <div>Data da Consulta</div>
          <v-date-picker
            v-model="consulta.dataConsulta"
            year-icon="mdi-calendar-blank"
            prev-icon="mdi-skip-previous"
            next-icon="mdi-skip-next"
            color="green lighten-1"
            locale="BR"
          ></v-date-picker>
        </v-col>
        <v-col class="pa-0 mx-36 mt-4 mt-sm-0 sm">
          <div>Horário da Consulta</div>
          <v-time-picker
            v-model="consulta.horarioConsulta"
            color="green lighten-1"
            height="9"
            format="24hr"
          ></v-time-picker>
        </v-col>
      </v-row>

      <v-btn :disabled="!valid" color="success" class="mr-4" @click="submit">
        Agendar Consulta
      </v-btn>

      <v-btn color="error" class="mr-4" @click="reset">
        Limpar formulário
      </v-btn>
    </v-form>

    <v-toolbar color="white" class="mt-7" flat>
      <v-icon color="grey darken-2"> mdi-arrow-down </v-icon>

      <v-toolbar-title class="grey--text text--darken-4 ml-5">
        Consultas Agendadas
      </v-toolbar-title>
    </v-toolbar>

    <v-data-table
      :headers="headers"
      :items="consultas"
      :items-per-page="5"
      class="elevation-1 mt-4"
    ></v-data-table>
  </v-container>
</template>>

<script>
export default {
  data: () => ({
    valid: true,
    consulta: {
      nomePaciente: "",
      nomeTutor: "",
      nomeMedico: "",
      nomeEspecialidade: "",
      dataConsulta: "",
      horarioConsulta: "",
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
        text: "Nome do Paciente",
        align: "start",
        sortable: false,
        value: "nomePaciente",
      },
      { text: "Nome do Tutor", value: "nomeTutor" },
      { text: "Nome do Medico", value: "nomeMedico" },
      { text: "Especialidade", value: "nomeEspecialidade" },
      { text: "Data da Consulta", value: "dataConsulta" },
      { text: "Horário da Consulta", value: "horarioConsulta" },
    ],
    consultas: [
      {
        nomePaciente: "Frozen Yogurt",
        nomeTutor: "Gabriel",
        nomeMedico: "Lucas",
        especialidade: "Ortopedia",
        data: "09-10-2022",
        horario: "15:00",
      },
    ],
  }),

  methods: {
    async submit() {
      debugger;

      try {
        var response = await this.$axios({
          method: "POST",
          url: "https://localhost:7234/Consultas",
          data: this.consulta,
        });

        debugger;

        var responseGet = await this.$axios({
          method: "GET",
          url: "https://localhost:7234/Consultas",
          data: this.consulta,
        });
        debugger;
        this.consultas = responseGet.data;
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