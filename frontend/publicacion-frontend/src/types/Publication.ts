export interface Publication {
  id: number;
  propertyType: string;
  operationType: string;
  description: string;
  rooms: number;
  m2: number;
  age: number;
  locationCoordinates: string;
}

export type PublicationPayload = Omit<Publication, 'id'>;

export interface PublicationImage {
  id: number;
  publicationId: number;
  url: string;
}

export interface PublicationWithImages extends Publication {
  images?: PublicationImage[];
}