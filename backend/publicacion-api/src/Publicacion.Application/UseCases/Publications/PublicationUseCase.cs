using Publicacion.Application.Contracts.Repositories;
using Publicacion.Application.Contracts.UseCases;
using Publicacion.Application.DTOs;
using Publicacion.Application.Mappings;
using Publicacion.Domain.Entities;

namespace Publicacion.Application.UseCases.Publications
{
    public class PublicationUseCase(IPublicationRepository _publicationRepository) : IPublicationUseCase
    {
        public async Task AddAsync(PublicationDto publicationDto)
        {
            var publication = PublicationMapping.MapToEntity(publicationDto);
            await _publicationRepository.AddAsync(publication);
        }

        public async Task DeleteAsync(int id)
        { 
            var publication = await _publicationRepository.GetFirstByIdAsync(id);
            await _publicationRepository.DeleteAsync(publication);
        }

        public Task<bool> ExistAsync(int id)
        {
            return _publicationRepository.ExistAsync(id);
        }

        public async Task<PublicationDto?> GetByIdAsync(int id)
        {
            Publication? publication = await _publicationRepository.GetByIdAsync(id);

            if (publication == null)
            {
                return null;
            }

            return PublicationMapping.MapToDto(publication);
        }

        public async Task<List<PublicationDto>> GetAllAsync()
        {
            List<Publication> publications = await _publicationRepository.GetAllAsync();
            return publications.Select(p => PublicationMapping.MapToDto(p)).OrderBy(p => p.Id).ToList();
        }

        public async Task UpdateAsync(int id, PublicationDto publicationDto)
        {
            var publication = PublicationMapping.MapToEntity(publicationDto, id);
            await _publicationRepository.UpdateAsync(publication);
        }
    }
}
