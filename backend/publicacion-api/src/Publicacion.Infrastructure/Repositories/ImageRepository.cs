using Microsoft.EntityFrameworkCore;
using Publicacion.Application.Contracts.Repositories;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence;

namespace Publicacion.Infrastructure.Repository
{
    public class ImageRepository(PublicationContext _context) : IImageRepository
    {
        public async Task<List<Image>> GetByPublicationIdAsync(int publicationId)
        {
            return await _context.Set<Image>()
                .Where(i => i.PublicationId == publicationId)
                .ToListAsync();
        }
    }
}
