using System.ComponentModel.DataAnnotations;

namespace api_pizza.Services.Pizza_service.Pizza_Dto
{
    public class UpdatePizzaDto : BasicPizzaDto
    {
        [Required]
        public string Id { get; set; }
    }
}
