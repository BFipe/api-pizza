﻿namespace api_pizza.Data
{
    public static class DataService
    {
        public static IServiceCollection AddDataServices(this IServiceCollection service)
        {
            service.AddScoped<ICatalogContext, CatalogContext>();
            return service;
        }
    }
}
