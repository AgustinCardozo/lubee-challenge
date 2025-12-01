<template>
  <div class="container-fluid mt-4">
    <div class="d-flex justify-content-center mb-3">
      <h2 class="mb-0">Publicaciones</h2>

      <div class="d-flex align-items-center mx-auto">
        <input v-model="searchTerm" type="search" class="form-control form-control-sm me-2" placeholder="Buscar texto" aria-label="Buscar publicaciones" style="min-width:600px" />

        <input v-model.number="roomsFilter" type="number" min="0" class="form-control form-control-sm me-2" style="width:80px" placeholder="Habit." aria-label="Habitaciones" />

        <input v-model.number="m2Min" type="number" min="0" class="form-control form-control-sm me-2" style="width:85px" placeholder="m2 min" aria-label="Metros min" />
        <input v-model.number="m2Max" type="number" min="0" class="form-control form-control-sm me-2" style="width:85px" placeholder="m2 max" aria-label="Metros max" />

        <button v-if="hasFilters" @click.prevent="clearFilters" class="btn btn-outline-secondary btn-sm me-2">Limpiar</button>
      </div>

      <div>
        <button @click.prevent="emit('create')" class="btn btn-success">Crear Publicación</button>
      </div>
    </div>

    <div class="row fw-bold border-bottom py-2 bg-light d-none d-md-flex">
      <div class="col-md-1">ID</div>
      <div class="col-md-3">Tipo Propiedad</div>
      <div class="col-md-2">Operación</div>
      <div class="col-md-2">Habitaciones</div>
      <div class="col-md-2">M2 / Antigüedad</div>
      <div class="col-md-2">Acciones</div>
    </div>

    <div
      v-for="pub in filteredPublications"
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
        <!-- Eye: ver -> abre modal de detalle -->
        <button @click.prevent="openDetail(pub)" class="btn btn-sm btn-light text-primary me-2" title="Ver" aria-label="Ver publicación">
          <i class="bi bi-eye" aria-hidden></i>
        </button>

        <!-- Pencil: editar -->
        <button @click.prevent="emit('edit', pub.id)" class="btn btn-sm btn-light text-secondary me-2" title="Editar" aria-label="Editar publicación">
          <i class="bi bi-pencil" aria-hidden></i>
        </button>

        <!-- Trash: eliminar -> abre modal de confirmación -->
        <button @click.stop.prevent="promptDelete(pub)" class="btn btn-sm btn-light text-danger" title="Eliminar" aria-label="Eliminar publicación">
          <i class="bi bi-trash" aria-hidden></i>
        </button>
      </div>
    </div>

    <!-- Detail Modal -->
    <div v-if="showDetailModal">
      <div class="modal fade show d-block" tabindex="-1" role="dialog" aria-modal="true">
  <div class="modal-dialog modal-dialog-centered">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Detalle de Publicación #{{ selectedPublication?.id }}</h5>
              <button type="button" class="btn-close" @click="showDetailModal = false" aria-label="Close"></button>
            </div>
                    <div class="modal-body">
                      <div v-if="selectedPublication?.images?.length" class="mb-3">
                        <img :src="(selectedPublication.images[currentImageIndex] && selectedPublication.images[currentImageIndex].url) || ''" class="img-fluid mb-2" style="max-height:220px; width:100%; object-fit:cover" alt="Imagen publicación" />
                        <div class="d-flex gap-2">
                          <img v-for="(img, i) in selectedPublication.images" :key="img.id" :src="img.url" class="img-thumbnail" style="width:70px; height:50px; object-fit:cover; cursor:pointer" :class="{'border-primary': i===currentImageIndex}" @click="currentImageIndex = i" />
                        </div>
                      </div>

                      <p><strong>Tipo de propiedad:</strong> {{ selectedPublication?.propertyType }}</p>
                      <p><strong>Tipo de operación:</strong> {{ selectedPublication?.operationType }}</p>
                      <p><strong>Descripción:</strong> {{ selectedPublication?.description }}</p>
                      <p><strong>Habitaciones:</strong> {{ selectedPublication?.rooms }}</p>
                      <p><strong>M2:</strong> {{ selectedPublication?.m2 }} m²</p>
                      <p><strong>Antigüedad:</strong> {{ selectedPublication?.age }} años</p>
                      <p><strong>Coordenadas:</strong> {{ selectedPublication?.locationCoordinates }}</p>
                    </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" @click="showDetailModal = false">Cerrar</button>
              <button type="button" class="btn btn-primary" @click="editFromDetail">Editar</button>
            </div>
          </div>
        </div>
      </div>
      <div class="modal-backdrop fade show"></div>
    </div>

    <div v-if="showDeleteModal">
      <div class="modal fade show d-block" tabindex="-1" role="dialog" aria-modal="true">
        <div class="modal-dialog modal-dialog-centered">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Confirmar eliminación</h5>
              <button type="button" class="btn-close" @click="cancelDelete" aria-label="Close"></button>
            </div>
            <div class="modal-body">
              <p>¿Estás seguro que deseas eliminar la publicación <strong>#{{ selectedPublication?.id }}</strong>?</p>
              <p><strong>Propiedad:</strong> {{ selectedPublication?.propertyType }} — <strong>Operación:</strong> {{ selectedPublication?.operationType }}</p>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-warning" @click="cancelDelete">Cancelar</button>
              <button type="button" class="btn btn-danger" @click="confirmDelete">Eliminar</button>
            </div>
          </div>
        </div>
      </div>
      <div class="modal-backdrop fade show"></div>
    </div>

    <div v-if="loading" class="text-center mt-3">Cargando publicaciones...</div>
    <div v-if="error" class="alert alert-danger mt-3">{{ error }}</div>

  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from 'vue';
import PublicationService from '@/services/publicationServices';
import ImageService from '@/services/imageService';
import { Publication, PublicationWithImages, PublicationImage } from '@/types/Publication';

const publications = ref<PublicationWithImages[]>([]);
const loading = ref<boolean>(false);
const error = ref<string | null>(null);
const searchTerm = ref<string>('');

const propertyTypeFilter = ref<string>('');
const operationTypeFilter = ref<string>('');
const roomsFilter = ref<number | null>(null);
const m2Min = ref<number | null>(null);
const m2Max = ref<number | null>(null);

const clearFilters = () => {
  searchTerm.value = '';
  propertyTypeFilter.value = '';
  operationTypeFilter.value = '';
  roomsFilter.value = null;
  m2Min.value = null;
  m2Max.value = null;
};

const hasFilters = computed(() => {
  return !!(searchTerm.value || propertyTypeFilter.value || operationTypeFilter.value || roomsFilter.value != null || m2Min.value != null || m2Max.value != null);
});

const filteredPublications = computed(() => {
  const q = searchTerm.value.trim().toLowerCase();
  const qNumber = Number(q);
  return publications.value.filter((p) => {
    if (q) {
      const inText = [p.propertyType, p.operationType, p.description, p.locationCoordinates]
        .filter(Boolean)
        .some((s) => s!.toLowerCase().includes(q));
      if (!inText && !( !Number.isNaN(qNumber) && String(p.id).includes(String(qNumber)) )) return false;
    }

    if (propertyTypeFilter.value) {
      if (!p.propertyType || p.propertyType !== propertyTypeFilter.value) return false;
    }

    if (operationTypeFilter.value) {
      const op = (p.operationType || '').toLowerCase();
      if (!op.includes(operationTypeFilter.value.toLowerCase())) return false;
    }

    if (roomsFilter.value != null) {
      if (p.rooms !== roomsFilter.value) return false;
    }

    if (m2Min.value != null) {
      if (p.m2 < m2Min.value) return false;
    }
    if (m2Max.value != null) {
      if (p.m2 > m2Max.value) return false;
    }

    return true;
  });
});

const emit = defineEmits(['edit', 'create']);

  const selectedPublication = ref<PublicationWithImages | null>(null);
  const showDetailModal = ref<boolean>(false);
  const showDeleteModal = ref<boolean>(false);
  const deletingId = ref<number | null>(null);
  const currentImageIndex = ref<number>(0);

  const openDetail = async (pub: Publication) => {
    try {
      loading.value = true;
      const resp = await PublicationService.getPublicationById(pub.id);
      // Obtener la publicación (sin asumir que trae imágenes)
      const data = resp.data as PublicationWithImages;

      try {
        const imgsResp = await ImageService.getImagesByPublicationId(pub.id);
        let imgs = imgsResp.data as PublicationImage | PublicationImage[] | null;
        if (imgs && !Array.isArray(imgs)) imgs = [imgs];
        data.images = (imgs as PublicationImage[]) || [];
      } catch (imgErr) {
        console.warn('Fallo al cargar imágenes desde el endpoint /imagenes', imgErr);
        data.images = [];
      }

      selectedPublication.value = data;
      currentImageIndex.value = 0;
      showDetailModal.value = true;
    } catch (err) {
      error.value = `Error al cargar detalle de la publicación ${pub.id}`;
      console.error(err);
    } finally {
      loading.value = false;
    }
  };

  // Preparar modal de eliminación (muestra detalles en modal)
  const promptDelete = (pub: Publication) => {
    deletingId.value = pub.id;
    selectedPublication.value = pub;
    showDeleteModal.value = true;
  };

  // Confirmar y ejecutar eliminación
  const confirmDelete = async () => {
    if (deletingId.value == null) return;
    try {
      await PublicationService.deletePublication(deletingId.value);
      showDeleteModal.value = false;
      deletingId.value = null;
      selectedPublication.value = null;
      await fetchPublications();
    } catch (err) {
      error.value = `Error al eliminar la publicación con ID ${deletingId.value}.`;
      console.error(err);
    }
  };

  const cancelDelete = () => {
    showDeleteModal.value = false;
    deletingId.value = null;
    selectedPublication.value = null;
  };

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

// Se ejecuta al montar el componente
onMounted(fetchPublications);

// Emitir edición desde el modal de detalle
const editFromDetail = () => {
  if (selectedPublication.value) {
    emit('edit', selectedPublication.value.id);
    showDetailModal.value = false;
  }
};

defineExpose({ clearFilters });
</script>
