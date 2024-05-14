using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.RequestModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducersController(IProducerService producerService)
        {
           _producerService = producerService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ProducerRequestModel producer)
        {
            try
            {
                var producerResponse = _producerService.Create(producer);
                var uri = Url.Action("Get", "Producers", new { id = producerResponse }, Request.Scheme);
                return Created(uri, new { id = producerResponse });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProducerRequestModel producer)
        {
            try
            {
                _producerService.Update(id, producer);
                return Ok("Producer Updated Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var producers = _producerService.Get();
                return Ok(producers);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var producer = _producerService.Get(id);
                return Ok(producer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
