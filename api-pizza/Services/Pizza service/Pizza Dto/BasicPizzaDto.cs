using System.ComponentModel.DataAnnotations;

namespace api_pizza.Services.Pizza_service.Pizza_Dto
{
    public class BasicPizzaDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public int ParentId { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public List<int> Size { get; set; }
        [Required]
        public List<double> Price { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public List<int> Dough { get; set; }
    }
}
