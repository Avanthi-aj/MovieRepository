using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService) {
            _producerService = producerService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_producerService.Get());  
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                return Ok(_producerService.Get(id));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProducerRequestModel producer)
        {
            try
            {
                _producerService.Create(producer);
                return Ok("Producer Created Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody]ProducerRequestModel producer)
        {
            try
            {
                _producerService.Update(id,producer);
                return Ok("Producer Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            try
            {
                _producerService.Delete(id);
                return Ok("Producer Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
