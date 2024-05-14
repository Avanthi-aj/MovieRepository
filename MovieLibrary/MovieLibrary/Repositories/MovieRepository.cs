using Microsoft.Extensions.Options;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDB)
        {

        }
        public int Create(Movie movie, string actors, string genres)
        {
            return StoredProcedure("usp_insert_movie", new
            {
                movie.Name,
                movie.YearOfRelease,
                movie.Plot,
                movie.CoverImage,
                movie.Producer,
                actors,
                genres
            }).Id;
        }

        public void Update(int id, Movie movie, string actors, string genres)
        {
            movie.Id = id;
            StoredProcedure("usp_update_movie", new
            {
                movie.Id,
                movie.Name,
                movie.YearOfRelease,
                movie.Plot,
                movie.CoverImage,
                movie.Producer,
                actors,
                genres
            });
        }
        public List<Movie> GetAll()
        {
            string query1 = @"
SELECT [Id]
	,[Name]
	,[YearOfRelease]
	,[Plot]
	,[ProducerId] AS [Producer]
	,[CoverImage]
FROM Movies (NOLOCK)";

            return Get(query1).ToList();
        }

        public List<Movie> GetAll(int year)
        {
            string query = @"
SELECT [Id]
	,[Name]
	,[YearOfRelease]
	,[Plot]
	,[ProducerId] AS [Producer]
	,[CoverImage]
FROM Movies (NOLOCK)
WHERE [YearOfRelease] = @year";

            return Get(query, new { year }).ToList();

        }

        public Movie Get(int id)
        {
            string sql = @"
SELECT [Id]
	,[Name]
	,[YearOfRelease]
	,[Plot]
	,[ProducerId] AS [Producer]
	,[CoverImage]
FROM Movies (NOLOCK)
WHERE [Id] = @id";

            return GetById(sql, new { Id = id });
        }

        public void Delete(int id)
        {
            string sql = @"
DELETE 
FROM Movies 
WHERE [Id] = @id";

            Delete(sql, new { Id = id });
        }


    }
}
