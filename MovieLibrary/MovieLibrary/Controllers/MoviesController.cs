using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovieRequestModel movie)
        {
            try
            {
                var movieResponse = _movieService.Create(movie);
                var uri = Url.Action("Get", "Movies", new { id = movieResponse }, Request.Scheme);
                return Created(uri, new { id = movieResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MovieRequestModel movie)
        {
            try
            {
                _movieService.Update(id, movie);
                return Ok("Movie Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int year)
        {
            return Ok(_movieService.GetAll(year));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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

        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");
                var task = new FirebaseStorage("imdb-6c81a.appspot.com")
                        .Child("images")
                        .Child(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName))
                        .PutAsync(file.OpenReadStream())
                        .GetAwaiter()
                        .GetResult();
                return Ok(task);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

    }
}
