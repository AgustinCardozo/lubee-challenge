<template>
  <div class="container mt-4">
    <h2 class="mb-4">{{ isEditing ? 'Editar Publicación' : 'Crear Nueva Publicación' }}</h2>

    <form @submit.prevent="savePublication" class="needs-validation" novalidate>
      <div class="mb-3">
        <label for="propertyType" class="form-label">Tipo de Propiedad:</label>
        <input
          type="text"
          class="form-control"
          id="propertyType"
          v-model="publication.propertyType"
          required
        >
        <div class="invalid-feedback">
          Por favor, ingrese el tipo de propiedad.
        </div>
      </div>

      <div class="mb-3">
        <label for="operationType" class="form-label">Tipo de Operación:</label>
        <input
          type="text"
          class="form-control"
          id="operationType"
          v-model="publication.operationType"
          required
        >
        <div class="invalid-feedback">
          Por favor, ingrese el tipo de operación.
        </div>
      </div>

      <div class="mb-3">
        <label for="description" class="form-label">Descripción:</label>
        <textarea
          class="form-control"
          id="description"
          rows="3"
          v-model="publication.description"
          required
        ></textarea>
        <div class="invalid-feedback">
          Por favor, ingrese una descripción.
        </div>
      </div>

      <div class="mb-3">
        <label for="rooms" class="form-label">Número de Habitaciones:</label>
        <input
          type="number"
          class="form-control"
          id="rooms"
          v-model.number="publication.rooms"
          required
          min="0"
        >
        <div class="invalid-feedback">
          Por favor, ingrese el número de habitaciones.
        </div>
      </div>

      <div class="mb-3">
        <label for="m2" class="form-label">Metros Cuadrados (m²):</label>
        <input
          type="number"
          class="form-control"
          id="m2"
          v-model.number="publication.m2"
          required
          min="0"
        >
        <div class="invalid-feedback">
          Por favor, ingrese los metros cuadrados.
        </div>
      </div>

      <div class="mb-3">
        <label for="age" class="form-label">Antigüedad (años):</label>
        <input
          type="number"
          class="form-control"
          id="age"
          v-model.number="publication.age"
          required
          min="0"
        >
        <div class="invalid-feedback">
          Por favor, ingrese la antigüedad.
        </div>
      </div>

      <div class="mb-3">
        <label for="locationCoordinates" class="form-label">Coordenadas de Ubicación:</label>
        <input
          type="text"
          class="form-control"
          id="locationCoordinates"
          v-model="publication.locationCoordinates"
          required
        >
        <div class="invalid-feedback">
          Por favor, ingrese las coordenadas de ubicación.
        </div>
      </div>

      <button type="submit" class="btn btn-primary me-2">
        {{ isEditing ? 'Guardar Cambios' : 'Crear Publicación' }}
      </button>
      <button type="button" @click="cancel" class="btn btn-secondary">Cancelar</button>

      <div v-if="loading" class="text-center mt-3">Guardando...</div>
      <div v-if="error" class="alert alert-danger mt-3">{{ error }}</div>
      <div v-if="successMessage" class="alert alert-success mt-3">{{ successMessage }}</div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed, watch } from 'vue';
import PublicationService from '@/services/publicationServices';
import { Publication, PublicationPayload } from '@/types/Publication';

// Las props que puede recibir el componente
interface Props {
  id?: number; // 'id' es opcional para el caso de creación
}
const props = defineProps<Props>();

// Estado inicial de una publicación vacía
const initialPublicationState: Publication = {
  id: 0, // El ID se manejará automáticamente por el backend para nuevas publicaciones
  propertyType: '',
  operationType: '',
  description: '',
  rooms: 0,
  m2: 0,
  age: 0,
  locationCoordinates: ''
};

const publication = ref<Publication>({ ...initialPublicationState });
const loading = ref<boolean>(false);
const error = ref<string | null>(null);
const successMessage = ref<string | null>(null);

//Para saber si estamos editando o creando
const isEditing = computed<boolean>(() => props.id !== undefined && props.id > 0);

// Carga los datos de una publicación si estamos en modo edición
const fetchPublicationToEdit = async (id: number) => {
  loading.value = true;
  error.value = null;
  try {
    const response = await PublicationService.getPublicationById(id);
    publication.value = response.data;
  } catch (err) {
    error.value = `Error al cargar la publicación con ID ${id}.`;
    console.error(err);
  } finally {
    loading.value = false;
  }
};

// Guardar (crear o actualizar) la publicación
const savePublication = async () => {
  const form = document.querySelector('.needs-validation') as HTMLFormElement;
  if (!form.checkValidity()) {
    form.classList.add('was-validated');
    return;
  }
  form.classList.remove('was-validated'); // Quitar la clase si es válido

  loading.value = true;
  error.value = null;
  successMessage.value = null;

  try {
    if (isEditing.value) {
      // Actualizar una publicación existente
      await PublicationService.updatePublication(publication.value.id, publication.value);
      successMessage.value = 'Publicación actualizada correctamente.';
    } else {
      // Crear una nueva publicación
      // Excluimos 'id' del payload para POST ya que el backend lo autogenera.
      const payload: PublicationPayload = {
        propertyType: publication.value.propertyType,
        operationType: publication.value.operationType,
        description: publication.value.description,
        rooms: publication.value.rooms,
        m2: publication.value.m2,
        age: publication.value.age,
        locationCoordinates: publication.value.locationCoordinates,
      };
      await PublicationService.createPublication(payload);
      successMessage.value = 'Publicación creada correctamente.';
      // Limpiar el formulario después de la creación exitosa
      publication.value = { ...initialPublicationState };
    }
  } catch (err) {
    error.value = `Error al ${isEditing.value ? 'guardar cambios' : 'crear publicación'}.`;
    console.error(err);
  } finally {
    loading.value = false;
  }
};

const cancel = () => {
  alert('Operación cancelada. Aquí iría una redirección o cierre de modal.');
  // En una aplicación real con vue-router, harías algo como: router.push('/publications');
};

// Hook de ciclo de vida: Al montar el componente, si hay un ID, carga los datos.
onMounted(() => {
  if (props.id) {
    fetchPublicationToEdit(props.id);
  }
});

// Observa cambios en props.id para recargar datos si el ID cambia (por ejemplo, si se reutiliza el componente)
watch(() => props.id, (newId) => {
  if (newId) {
    fetchPublicationToEdit(newId);
  } else {
    // Si el ID se limpia, reinicia el formulario para una nueva creación
    publication.value = { ...initialPublicationState };
  }
});
</script>
