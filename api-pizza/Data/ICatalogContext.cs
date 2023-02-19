using api_pizza.Entities;
using MongoDB.Driver;

namespace api_pizza.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Pizza> Pizzas { get; }
    }
}
