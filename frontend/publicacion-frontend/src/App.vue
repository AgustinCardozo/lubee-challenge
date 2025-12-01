<template>
  <div>
    <nav class="navbar navbar-dark bg-primary">
      <div class="container-fluid justify-content-center">
        <div class="d-flex">
          <a class="navbar-brand me-2" href="#" @click.prevent="goHome">
            <img src="./assets/logo_lubee.png" alt="Logo" style="height: 40px;">
          </a>
        </div>
      </div>
    </nav>

      <main class="container-fluid">
      <PublicationList ref="publicationListRef" v-if="currentView === 'list'" @edit="editPublication" @create="currentView = 'create'" />
      <PublicationForm v-if="currentView === 'create'" @done="goHome" />
      <PublicationForm v-if="currentView === 'edit'" :id="editId" @done="goHome" />
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

type PublicationListInstance = { clearFilters?: () => void };
const publicationListRef = ref<PublicationListInstance | null>(null);

const editPublication = (id: number) => {
  editId.value = id;
  currentView.value = 'edit';
};

const goHome = () => {
  // If the list component is mounted, clear its filters when returning home
  if (publicationListRef.value && typeof publicationListRef.value.clearFilters === 'function') {
    publicationListRef.value.clearFilters();
  }

  currentView.value = 'list';
  editId.value = undefined;
};
</script>

<style>
body {
  background-color: #f8f9fa;
}
</style>