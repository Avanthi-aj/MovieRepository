using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IReviewService
    {
        void Create(ReviewRequestModel review);
        void Update(int id, ReviewRequestModel review);
        ReviewResponseModel Get(int id);
        List<ReviewResponseModel> Get();
        void Delete(int id);
    }
}
