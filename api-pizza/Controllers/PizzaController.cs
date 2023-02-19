using api_pizza.Services.Pizza_service;
using api_pizza.Services.Pizza_service.Pizza_Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace api_pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IMapper mapper, IPizzaRepository pizzaRepository)
        {
            _mapper = mapper;
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetPizzaDto>>> GetPizzas([FromQuery] QueryParameters? queryParameters)
        {
            var result = await _pizzaRepository.GetAsync(queryParameters ?? new QueryParameters());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddPizza([FromBody]CreatePizzaDto pizzaDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var result = await _pizzaRepository.CreateAsync(pizzaDto);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePizza([FromBody] UpdatePizzaDto pizzaDto)
        {
            var result = await _pizzaRepository.UpdateAsync(pizzaDto);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePizza([FromBody] string id)
        {
            var result = await _pizzaRepository.DeleteAsync(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
