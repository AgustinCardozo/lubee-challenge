using Publicacion.Application.DTOs;

namespace Publicacion.Application.Contracts.UseCases
{
    public interface IPublicationUseCase
    {
        public Task AddAsync(PublicationDto publicationDto);
        public Task DeleteAsync(int id);
        public Task<bool> ExistAsync(int id);
        public Task<PublicationDto?> GetByIdAsync(int id);
        public Task<List<PublicationDto>> GetGetAllAsync();
        public Task UpdateAsync(int id, PublicationDto publicationDto);
    }
}
