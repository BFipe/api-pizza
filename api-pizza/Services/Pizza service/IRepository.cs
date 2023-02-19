using api_pizza.Services.Pizza_service.Pizza_Dto;

namespace api_pizza.Services.Pizza_service
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync(QueryParameters queryParameters);
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
    }
}
