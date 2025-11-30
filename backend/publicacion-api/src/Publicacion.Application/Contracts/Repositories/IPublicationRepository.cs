using Publicacion.Domain.Entities;

namespace Publicacion.Application.Contracts.Repositories
{
    public interface IPublicationRepository : IRepository<Publication>
    {
        Task<Publication> GetFirstByIdAsync(int id);
    }
}
