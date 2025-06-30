using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface IBaseWithIdRepository<T> where T : BaseEntityWithId
    {
        Task<T> CreateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T?> GetByIdAsync(int id);

        //Task<IEnumerable<T>> SearchSchools();
    }
}
