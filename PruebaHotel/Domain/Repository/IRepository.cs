namespace PruebaHotel.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
