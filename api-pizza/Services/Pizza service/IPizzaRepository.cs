using api_pizza.Entities;
using api_pizza.Services.Pizza_service.Pizza_Dto;

namespace api_pizza.Services.Pizza_service
{
    public interface IPizzaRepository
    {
        Task<IEnumerable<GetPizzaDto>> GetAsync(QueryParameters queryParameters);
        Task<bool> CreateAsync(CreatePizzaDto entity);
        Task<bool> UpdateAsync(UpdatePizzaDto entity);
        Task<bool> DeleteAsync(string id);
    }
}
