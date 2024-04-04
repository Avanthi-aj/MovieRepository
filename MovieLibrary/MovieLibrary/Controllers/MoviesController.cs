using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService) {
            _movieService = movieService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_movieService.Get());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var movie = _movieService.Get(id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetByYear")]
        public IActionResult GetByYear([FromQuery]int year)
        {
            return Ok(_movieService.GetByYear(year));
        }
        [HttpPost]
        public IActionResult Create([FromBody]MovieRequestModel movie)
        {
            try
            {
                _movieService.Create(movie);
                return Ok("Movie Created Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id , [FromBody]MovieRequestModel movie)
        {
            try
            {
                _movieService.Update(id,movie);
                return Ok("Movie Updated Successfully");
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
                _movieService.Delete(id);
                return Ok("Movie Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
