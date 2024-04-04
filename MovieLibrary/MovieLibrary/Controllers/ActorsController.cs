using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_actorService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                var actor  = _actorService.Get(id);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
       
        [HttpPost]
        public IActionResult Create([FromBody] ActorRequestModel actor)
        {
            try
            {
                _actorService.Create(actor);
                return Ok("Actor Created SUccessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody]ActorRequestModel actor)
        {
            try
            {
                _actorService.Update(id,actor);
                return Ok("Actor Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _actorService.Delete(id);
                return Ok("Actor Deleted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
