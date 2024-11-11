using MLIMS.Repositories;

namespace MLIMS.Services
{
    public abstract class Service<T> where T : class
    {
        private readonly Repository<T> _repository;

        protected Service(Repository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<T> CreateAsync(T entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task<IEnumerable<dynamic>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<dynamic?> GetByIdAsync(int id, string langCode)
        {
            return await _repository.GetByIdAsync(id, langCode);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
