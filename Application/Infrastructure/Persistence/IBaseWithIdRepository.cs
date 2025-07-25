using Domain;


namespace Application.Infrastructure.Persistence
{
    public interface IBaseWithIdRepository<T> where T : BaseEntityWithId
    {
        Task<T?> CreateAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<T?> UpdateAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        //IEnumerable<T> SearchByFilterParameters(string filterValue, int currentPage, int pageSize);
        //Task<int> TotalCountAsync(string filterValue);
    }
}
