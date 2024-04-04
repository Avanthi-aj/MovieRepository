using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("api/movies/{movieId:int}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reviewService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                return Ok(_reviewService.Get(id));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromRoute]int movieId ,[FromBody] ReviewRequestModel review)
        {
            review.MovieId = movieId;
            try
            {
                _reviewService.Create(review);
                return Ok("Review Created Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int movieId,[FromRoute]int id , [FromBody] ReviewRequestModel review)
        {
            review.MovieId = movieId;
            try
            {
                _reviewService.Update(id,review);
                return Ok("Review Updated Successfully");
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
                _reviewService.Delete(id);
                return Ok("Review Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
