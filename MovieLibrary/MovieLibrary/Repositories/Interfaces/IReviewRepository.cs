using MovieLibrary.Models;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public int Create(Review review);
        public void Update(int id, Review review);
        public void Delete(int movieId,int id);
        public Review Get(int id, int movieId);
        public List<Review> Get(int movieId);
    }
}
