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

        public async Task<IEnumerable<Pizza>> GetAsync(QueryParameters queryParameters)
        {
            return await _catalogContext
               .Pizzas
               .Find(q => true)
               .Skip(queryParameters.Page * queryParameters.ContentPerPage)
               .Limit(queryParameters.ContentPerPage)
               .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Pizza entity)
        {
            var result = await _catalogContext
               .Pizzas
               .ReplaceOneAsync(filter: q => q.Id == entity.Id, replacement: entity);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> CreateAsync(Pizza entity)
        {
            Task task = _catalogContext.Pizzas.InsertOneAsync(entity);
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
