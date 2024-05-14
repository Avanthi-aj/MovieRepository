using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.RequestModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("movies/{movieId:int}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPost]
        public IActionResult Create([FromRoute] int movieId, [FromBody] ReviewRequestModel review)
        {
            try
            {
                var reviewResponse = _reviewService.Create(movieId, review);
                var uri = Url.Action("Get", "Reviews", new { id = reviewResponse, movieId }, Request.Scheme);
                return Created(uri, new { Id = reviewResponse });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromRoute] int movieId, [FromBody] ReviewRequestModel review)
        {
            try
            {
                _reviewService.Update(id, movieId, review);
                return Ok("Review Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromRoute] int movieId)
        {
            try
            {
                var reviews = _reviewService.Get(movieId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id, [FromRoute] int movieId)
        {
            try
            {
                var review = _reviewService.Get(id, movieId);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int movieId, int id)
        {
            try
            {
                _reviewService.Delete(id, movieId);
                return Ok("Review Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
