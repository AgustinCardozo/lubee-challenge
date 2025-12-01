using Publicacion.Application.Contracts.Repositories;
using Publicacion.Application.Contracts.UseCases.Images;
using Publicacion.Application.DTOs;
using Publicacion.Application.Mappings;

namespace Publicacion.Application.UseCases.Images
{
    public class ImageUseCase(IImageRepository _imageRepository) : IImageUseCase
    {
        public async Task<List<ImageDto>> GetByPublicationIdAsync(int publicationId)
        {
            var images = await _imageRepository.GetByPublicationIdAsync(publicationId);

            if (images == null || images.Count == 0)
            {
                return new List<ImageDto>();
            }

            return images.Select(i => ImageMapping.MapToDto(i)).ToList();
        }
    }
}
