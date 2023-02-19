using System.ComponentModel.DataAnnotations;

namespace api_pizza.Services.Pizza_service.Pizza_Dto
{
    public class QueryParameters
    {
        [Range(0, int.MaxValue)]
        public int Page { get; set; } = 0;

        [Range(1, int.MaxValue)]
        public int ContentPerPage { get; set; } = 12;
    }
}
