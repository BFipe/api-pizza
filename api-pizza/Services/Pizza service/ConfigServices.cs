using api_pizza.Data;
using api_pizza.Services.Mapper;

namespace api_pizza.Services.Pizza_service
{
    public static class ConfigServices
    {
        public static IServiceCollection AddServiceLayerServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(MapperConfig));

            services.AddDataServices();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            return services;
        }
    }
}
