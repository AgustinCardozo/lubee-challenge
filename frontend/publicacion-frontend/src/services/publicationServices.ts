import axios from 'axios';
import type { AxiosResponse } from 'axios';
import type { Publication, PublicationPayload } from '@/types/Publication';

const API_URL = 'https://localhost:5000/lubee-publicacion/api/v1/Publication';

const PublicationService = {
  getAllPublications(): Promise<AxiosResponse<Publication[]>> {
    return axios.get<Publication[]>(API_URL);
  },

  getPublicationById(id: number): Promise<AxiosResponse<Publication>> {
    return axios.get<Publication>(`${API_URL}/${id}`);
  },

  createPublication(publicationData: PublicationPayload): Promise<AxiosResponse<Publication>> {
    return axios.post<Publication>(API_URL, publicationData, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  },

  updatePublication(id: number, publicationData: Publication): Promise<AxiosResponse<Publication>> {
    return axios.put<Publication>(`${API_URL}/${id}`, publicationData, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  },

  deletePublication(id: number): Promise<AxiosResponse<void>> {
    return axios.delete<void>(`${API_URL}/${id}`);
  }
};

export default PublicationService;