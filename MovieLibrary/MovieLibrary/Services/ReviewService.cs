using AutoMapper;
using MovieLibrary.Entities;
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
        private IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public void Create(ReviewRequestModel review)
        {
            _reviewRepository.Create(_mapper.Map<Review>(review));
        }

        public void Delete(int id)
        {
            try
            {
                ValidateById(id);
                _reviewRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReviewResponseModel Get(int id)
        {
            try
            {
                ValidateById(id);
                return _mapper.Map<ReviewResponseModel>(_reviewRepository.Get(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReviewResponseModel> Get()
        {
            return _mapper.Map<List<ReviewResponseModel>>(_reviewRepository.Get());
        }

        public void Update(int id, ReviewRequestModel review)
        {
            try
            {
                ValidateById(id);
                _reviewRepository.Update(id, _mapper.Map<Review>(review));
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ValidateById(int id)
        {
            var review = _reviewRepository.Get(id);
            if (review == null)
            {
                throw new ArgumentException("Review does not exist");
            }
        }
    }
}
