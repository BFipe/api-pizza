using api_pizza.Entities;
using MongoDB.Driver;

namespace api_pizza.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MongoDb"));
            var database = client.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName"));

            Pizzas = database.GetCollection<Pizza>(Environment.GetEnvironmentVariable("CollectionName"));
            CatalogContextSeed.InsertDefaultData(Pizzas);
        }
        public IMongoCollection<Pizza> Pizzas { get; }
    }
}
