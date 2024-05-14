using MovieLibrary.ResponseModel;
using MovieLibrary.RequestModel;


namespace MovieLibrary.Services.Interfaces
{
    public interface IReviewService
    {
        public int Create(int movieId,ReviewRequestModel review);
        public void Update(int id,int movieId, ReviewRequestModel review);
        public void Delete(int id, int movieId);
        public ReviewResponseModel Get(int id,int movieId);
        public List<ReviewResponseModel> Get(int movieId);
    }
}
