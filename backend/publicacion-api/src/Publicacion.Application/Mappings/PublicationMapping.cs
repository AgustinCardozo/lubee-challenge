using Publicacion.Application.DTOs;
using Publicacion.Domain.Entities;

namespace Publicacion.Application.Mappings
{
    public static class PublicationMapping
    {
        public static PublicationDto MapToDto(Publication publication)
        {
            return new PublicationDto(
                publication.Id,
                publication.PropertyType,
                publication.OperationType,
                publication.Description,
                publication.Rooms,
                publication.M2, 
                publication.Age,
                publication.LocationCoordinates
            );
        }

        public static Publication MapToEntity(PublicationDto dto, int? id = null)
        {
            return new Publication
            {
                Id = id ?? dto.Id,
                PropertyType = dto.PropertyType,
                OperationType = dto.OperationType,
                Description = dto.Description,
                Rooms = dto.Rooms,
                M2 = dto.M2,
                Age = dto.Age,
                LocationCoordinates = dto.LocationCoordinates
            };
        }
    }
}
