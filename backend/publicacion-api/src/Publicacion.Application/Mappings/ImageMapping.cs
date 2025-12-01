using Publicacion.Application.DTOs;
using Publicacion.Domain.Entities;

namespace Publicacion.Application.Mappings
{
    public static class ImageMapping
    {
        public static ImageDto MapToDto(Image image)
        {
            return new ImageDto(
                image.Id,
                image.Url,
                image.PublicationId
            );
        }
    }
}
