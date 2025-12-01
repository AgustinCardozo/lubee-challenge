using Publicacion.Domain.Entities;

namespace Publicacion.Application.Contracts.Repositories
{
    public interface IImageRepository
    {
        Task<List<Image>> GetByPublicationIdAsync(int publicationId);
    }
}
