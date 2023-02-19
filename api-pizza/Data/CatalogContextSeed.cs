using api_pizza.Entities;
using MongoDB.Driver;

namespace api_pizza.Data
{
    public class CatalogContextSeed
    {
        public static void InsertDefaultData(IMongoCollection<Pizza> collection)
        {
            bool exist = collection.Find(p => true).Any();
            if (exist == false)
            {
                collection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Pizza> GetPreConfiguredProducts()
        {
            return new List<Pizza>()
            {
               new Pizza()
               {
                   Title =  "Barbecue chicken",
                   Img = "https://dodopizza-a.akamaihd.net/static/Img/Products/45cc8ffb190c4a28aaf1863a67f675c7_584x584.png",
                   ParentId=4,
                   Category =1,
                   Size= new List<int>(){26,30,40},
                   Price=new List<double>(){15.95,16.95,17.95},
                   Rating= 5,
                   Dough=new List<int>(){0,1},
               },

               new Pizza()
               {
                   Title =  "Burger-pizza",
                   Img = "https://dodopizza-a.akamaihd.net/static/Img/Products/1a9252b622b6494ebde59163374402a9_584x584.webp",
                   ParentId=2,
                   Category =0,
                   Size= new List<int>(){26,30,40},
                   Price=new List<double>(){15.99,16.99,17.99},
                   Rating= 5,
                   Dough=new List<int>(){0,1},
               },
                
                new Pizza()
               {
                   Title =  "Margarita",
                   Img = "https://dodopizza-a.akamaihd.net/static/Img/Products/748949429e25404ea10aab002c910d84_584x584.png",
                   ParentId=5,
                   Category =0,
                   Size= new List<int>(){26,30,40},
                   Price=new List<double>(){16.9,17.9,18.9},
                   Rating= 4,
                   Dough=new List<int>(){0,1},
               },
            };
        }
    }
}
