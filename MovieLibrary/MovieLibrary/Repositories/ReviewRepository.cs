using Microsoft.Extensions.Options;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class ReviewRepository :BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDB)
        {
        }
        public void Create(Review review)
        {
            const string query = @"
INSERT INTO Foundation.Reviews(Message,Movie_Id)
VALUES (
	@Message
	,@MovieId
	)";
            Create(query, review);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Foundation.Reviews
WHERE [Id] = @id";

            if (!Delete(query, new { id }))
            {
                throw new InvalidOperationException("Could not delete review");
            }
        }

        public Review Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Message]
	,[Movie_Id] AS [MovieId]
FROM Foundation.Reviews
WHERE [Id] = @id";
            return QueryDBSingle(query, new { id });
        }

        public List<Review> Get()
        {
            const string query = @"
SELECT [Id]
	,[Message]
	,[Movie_Id] AS [MovieId]
FROM Foundation.Reviews";
            return QueryDB(query, null).ToList();
        }

        public void Update(int id, Review review)
        {
            const string query = @"

UPDATE Foundation.Reviews

SET [Message] = @Message

	,[Movie_Id] = @MovieId

WHERE [Id] = @id";

            review.Id = id;
         

            if (!Update(query, review))
            {
                throw new InvalidOperationException("Could not update review");
            }
        }
    }
}