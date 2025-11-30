using Microsoft.EntityFrameworkCore;
using Publicacion.Application.Contracts.Repositories;
using Publicacion.Domain.Entities;
using Publicacion.Infrastructure.Persistence;

namespace Publicacion.Infrastructure.Repository
{
    public class Repository<TEntity>(PublicationContext _context) : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _entity => _context.Set<TEntity>();

        public async Task AddAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Set<Publication>().AnyAsync(x => x.Id == id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync<T>(T id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
