using Microsoft.EntityFrameworkCore;
using Publicacion.Application.Contracts.Repositories;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence;

namespace Publicacion.Infrastructure.Repository
{
    public class PublicationRepository(PublicationContext _context) : Repository<Publication>(_context), IPublicationRepository
    {
        public async Task<Publication> GetFirstByIdAsync(int id)
        {
            return await _context.Set<Publication>().FirstAsync(x => x.Id == id);
        }
    }
}
