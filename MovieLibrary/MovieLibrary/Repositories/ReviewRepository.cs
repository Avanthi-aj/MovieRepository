using Microsoft.Extensions.Options;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(IOptions<ConnectionString> connectionString) :
            base(connectionString.Value.IMDB)
        {
        }
        public int Create(Review review)
        {

            return StoredProcedure("usp_insert_review", new
            {
                review.Message,
                review.MovieId
            }).Id;

        }

        public void Update(int id, Review review)
        {
            review.Id = id;
            StoredProcedure("usp_update_review", new
            {
                review.Id,
                review.Message,
                review.MovieId
            });
        }

        public Review Get(int id, int movieId)
        {
            string sql = @"
SELECT [Id]
    ,[Message]
    ,[MovieId]
FROM Reviews (NOLOCK)
WHERE [Id]= @id 
AND [MovieId] = @movieId";

            return GetById(sql, new { Id = id, MovieId = movieId });
        }

        public List<Review> Get(int movieId)
        {
            string sql = @"
SELECT [Id]
    ,[Message]
    ,[MovieId]
FROM Reviews (NOLOCK)
WHERE [MovieId] = @movieId";

            return Get(sql, new { movieId }).ToList();
        }



        public void Delete(int id, int movieId)
        {
            string sql = @"
DELETE 
FROM Reviews 
WHERE [Id] = @id 
AND [MovieId] = @movieId";

            Delete(sql, new { Id = id, MovieId = movieId });
        }

    }
}
