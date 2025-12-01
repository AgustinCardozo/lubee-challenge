using Publicacion.Application.DTOs;

namespace Publicacion.Application.Contracts.UseCases.Images
{
    public interface IImageUseCase
    {
        public Task<List<ImageDto>> GetByPublicationIdAsync(int publicationId);
    }
}
