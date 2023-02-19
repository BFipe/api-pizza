using api_pizza.Data;
using api_pizza.Entities;
using api_pizza.Services.Pizza_service.Pizza_Dto;
using AutoMapper;
using MongoDB.Driver;

namespace api_pizza.Services.Pizza_service
{
    public class PizzaRepository : IPizzaRepository
    {
        private ICatalogContext _catalogContext;
        private IMapper _mapper;

        public PizzaRepository(ICatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetPizzaDto>> GetAsync(QueryParameters queryParameters)
        {
            var getPizzas = await _catalogContext
               .Pizzas
               .Find(q => true)
               .Skip(queryParameters.Page * queryParameters.ContentPerPage)
               .Limit(queryParameters.ContentPerPage)
               .ToListAsync();

            return _mapper.Map<List<GetPizzaDto>>(getPizzas);
        }

        public async Task<bool> UpdateAsync(UpdatePizzaDto entity)
        {
            var updatePizza = _mapper.Map<Pizza>(entity);
            var result = await _catalogContext
               .Pizzas
               .ReplaceOneAsync(filter: q => q.Id == updatePizza.Id, replacement: updatePizza);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> CreateAsync(CreatePizzaDto entity)
        {
            var createPizza = _mapper.Map<Pizza>(entity);
            Task task = _catalogContext.Pizzas.InsertOneAsync(createPizza);
            await task;
            return task.IsCompleted;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _catalogContext
           .Pizzas
           .DeleteOneAsync(filter: q => q.Id == id);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
