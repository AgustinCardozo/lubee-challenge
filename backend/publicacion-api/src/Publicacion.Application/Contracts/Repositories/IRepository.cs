namespace Publicacion.Application.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task AddAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);
        Task<bool> ExistAsync(int id);
        public Task<List<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync<T>(T id);
        public Task UpdateAsync(TEntity entity);
    }
}
