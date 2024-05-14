using AutoMapper;
using Microsoft.Identity.Client;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Repositories;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper, IMovieService movieService)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _movieService = movieService;
        }
        public int Create(int movieId, ReviewRequestModel review)
        {
            review.MovieId = movieId;
            if (string.IsNullOrEmpty(review.Message))
            {
                throw new BadInputException($"Message cannot be empty");
            }
            _movieService.Get(movieId);
            return _reviewRepository.Create(_mapper.Map<Review>(review));
            
        }

        public void Delete(int id, int movieId)
        {
            _movieService.Get(movieId);
            Get(id,movieId);
            _reviewRepository.Delete(id, movieId);
        }

        public ReviewResponseModel Get(int id, int movieId)
        {
            _movieService.Get(movieId);
            var review = _reviewRepository.Get(id, movieId);
            if(review == null)
            {
                throw new BadInputException($"Review with ID {id} does not exist");
            }
            return _mapper.Map<ReviewResponseModel>(review);
        }

        public List<ReviewResponseModel> Get(int movieId)
        {
            _movieService.Get(movieId);
            return _mapper.Map<List<ReviewResponseModel>>(_reviewRepository.Get(movieId));
        }

        public void Update(int id, int movieId, ReviewRequestModel review)
        {
            review.MovieId = movieId;
            if (string.IsNullOrEmpty(review.Message))
            {
                throw new BadInputException($"Message cannot be empty");
            }
            Get(id, movieId);
            _reviewRepository.Update(id, _mapper.Map<Review>(review));
            
        }
    }
}
