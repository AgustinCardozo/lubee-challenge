<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <div class="container-fluid">
        <a class="navbar-brand" href="#" @click.prevent="goHome"><img src="./assets/logo_lubee.png" alt="Logo" style="height: 40px;"></a>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <button class="nav-link btn btn-link text-white" @click="currentView = 'list'">Listado</button>
            </li>
            <li class="nav-item">
              <button class="nav-link btn btn-link text-white" @click="currentView = 'create'">Crear Publicación</button>
            </li>
             <li class="nav-item">
              <button class="nav-link btn btn-link text-white" @click="editPublication(3)">Editar</button>
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <main class="container-fluid">
      <PublicationList v-if="currentView === 'list'" />
      <PublicationForm v-if="currentView === 'create'" />
      <PublicationForm v-if="currentView === 'edit'" :id="editId" />
    </main>

  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import PublicationList from '@/components/PublicationList.vue';
import PublicationForm from '@/components/PublicationForm.vue';

// Variable reactiva para controlar qué componente se muestra
const currentView = ref<'list' | 'create' | 'edit'>('list');
const editId = ref<number | undefined>(undefined); // Almacena el ID de la publicación a editar

const editPublication = (id: number) => {
  editId.value = id;
  currentView.value = 'edit';
};

const goHome = () => {
  currentView.value = 'list';
  editId.value = undefined;
};
</script>

<style>
/* Estilos globales */
body {
  background-color: #f8f9fa;
}
</style>