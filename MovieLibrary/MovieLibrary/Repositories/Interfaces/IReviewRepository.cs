using MovieLibrary.Entities;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        void Create(Review review);
        void Update(int id, Review review);
        Review Get(int id);
        List<Review> Get();
        void Delete(int id);
    }
}
