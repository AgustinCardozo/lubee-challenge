<template>
  <div class="container mt-4">
    <h2 class="mb-3">Listado de Publicaciones (TS)</h2>

    <div class="row fw-bold border-bottom py-2 bg-light d-none d-md-flex">
      <div class="col-md-1">ID</div>
      <div class="col-md-3">Tipo Propiedad</div>
      <div class="col-md-2">Operación</div>
      <div class="col-md-2">Habitaciones</div>
      <div class="col-md-2">M2 / Antigüedad</div>
      <div class="col-md-2">Acciones</div>
    </div>

    <div
      v-for="pub in publications"
      :key="pub.id"
      class="row py-3 border-bottom align-items-center"
    >
      <div class="col-12 col-md-1">
        <span class="d-md-none fw-bold">ID: </span>{{ pub.id }}
      </div>
      <div class="col-12 col-md-3">
        <span class="d-md-none fw-bold">Propiedad: </span>{{ pub.propertyType }}
      </div>
      <div class="col-12 col-md-2">
        <span class="d-md-none fw-bold">Operación: </span>{{ pub.operationType }}
      </div>
      <div class="col-12 col-md-2">
        <span class="d-md-none fw-bold">Habitaciones: </span>{{ pub.rooms }}
      </div>
      <div class="col-12 col-md-2">
        <span class="d-md-none fw-bold">M2 / Edad: </span>{{ pub.m2 }}m² / {{ pub.age }} años
      </div>
      <div class="col-12 col-md-2 d-grid gap-2 d-md-block">
        <button @click="viewDetail(pub.id)" class="btn btn-sm btn-info me-2">Ver</button>
        <button @click="deleteItem(pub.id)" class="btn btn-sm btn-danger">Eliminar</button>
      </div>
    </div>

    <div v-if="loading" class="text-center mt-3">Cargando publicaciones...</div>
    <div v-if="error" class="alert alert-danger mt-3">{{ error }}</div>

  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import PublicationService from '@/services/publicationServices';
import { Publication } from '@/types/Publication';

const publications = ref<Publication[]>([]);
const loading = ref<boolean>(false);
const error = ref<string | null>(null);

// Obtener todas las publicaciones
const fetchPublications = async () => {
  loading.value = true;
  error.value = null;
  try {
    const response = await PublicationService.getAllPublications();
    publications.value = response.data;
  } catch (err) {
    error.value = 'Error al cargar las publicaciones. Verifique su API.';
    console.error(err);
  } finally {
    loading.value = false;
  }
};

// Eliminar una publicación. Recibe un ID que debe ser un número (number)
const deleteItem = async (id: number) => {
  if (confirm(`¿Estás seguro de que quieres eliminar la publicación con ID ${id}?`)) {
    try {
      await PublicationService.deletePublication(id);
      alert('Publicación eliminada correctamente.');
      await fetchPublications();
    } catch (err) {
      error.value = `Error al eliminar la publicación con ID ${id}.`;
      console.error(err);
    }
  }
};

// Se ejecuta al montar el componente
onMounted(fetchPublications);

const viewDetail = (id: number) => {
    alert(`Navegando al detalle de la publicación ${id}`);
};
</script>
