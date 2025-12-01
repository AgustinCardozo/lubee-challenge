import axios from 'axios';
import type { AxiosResponse } from 'axios';
import type { PublicationImage } from '@/types/Publication';

const API_URL_IMAGES = 'https://localhost:5000/lubee-publicacion/api/v1/imagenes';

const ImageService = {
  getImagesByPublicationId(publicationId: number): Promise<AxiosResponse<PublicationImage[]>> {
    return axios.get<PublicationImage[]>(`${API_URL_IMAGES}/${publicationId}`);
  },
};

export default ImageService;
