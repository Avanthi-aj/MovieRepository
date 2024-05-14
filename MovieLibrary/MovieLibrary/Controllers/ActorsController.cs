using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.RequestModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ActorRequestModel actor)
        {
            try
            {
                var actorResponse = _actorService.Create(actor);
                var uri = Url.Action("Get", "Actors", new { id = actorResponse }, Request.Scheme);
                return new CreatedResult(uri,new { Id = actorResponse });
            }
           catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ActorRequestModel actor)
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

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var actors = _actorService.Get();
                return Ok(actors);
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
                var actor = _actorService.Get(id);
                return Ok(actor);
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
                _actorService.Delete(id);
                return Ok("Actor Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
