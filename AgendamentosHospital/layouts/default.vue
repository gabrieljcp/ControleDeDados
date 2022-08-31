<template >
  <v-app light>
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      :clipped="clipped"
      fixed
      app
      color="#6495ED"
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
          dark
          selectable
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar :clipped-left="clipped" fixed app color="green">
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />

      <v-toolbar-title v-text="title" />
      <v-spacer />
    </v-app-bar>
    <v-main>
      <v-container
        :style="{
          'background-image':
            'url(https://img.freepik.com/fotos-premium/cao-de-exame-veterinario_137573-2346.jpg?w=2000)',
          'background-size': 'cover',
          widht: '100%',
        }"
      >
        <Nuxt />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: "DefaultLayout",
  data() {
    return {
      clipped: false,
      drawer: false,
      fixed: false,
      items: [
        {
          icon: "mdi-home",
          title: "Início",
          to: "/",
        },
        {
          icon: "mdi-stethoscope",
          title: "Agendar Consultas",
          to: "/consultas",
        },
        {
          icon: "mdi-account-multiple",
          title: "Tutores",
          to: "/tutores",
        },
        {
          icon: "mdi-tab",
          title: "Pacientes",
          to: "/pacientes",
        },
        {
          icon: "mdi-mail",
          title: "Médicos",
          to: "/medicos",
        },
        {
          icon: "mdi-atom",
          title: "Especialidades",
          to: "/especialidades",
        },
      ],
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: "HOSPITAL VETERINÁRIO MeuPet",
    };
  },
};
</script>
