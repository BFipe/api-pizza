using api_pizza.Entities;
using api_pizza.Services.Pizza_service.Pizza_Dto;
using AutoMapper;

namespace api_pizza.Services.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Pizza, GetPizzaDto>().ReverseMap();
            CreateMap<Pizza, CreatePizzaDto>().ReverseMap();
            CreateMap<Pizza, UpdatePizzaDto>().ReverseMap();
        }
    }
}
