using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class MovieRepository :BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDB)
        {
        }
        public void Create(Movie movie, string actors, string genres)
        {
            ExecuteStoredProcedure<int>("usp_insert_movie", new
            {
                movie.Name,
                movie.YearOfRelease,
                movie.Producer,
                movie.Plot,
                movie.CoverImage,
                actors,
                genres
            });
        }

        public void Delete(int id)
        {
            string query = @"
DELETE
FROM Foundation.Movies
WHERE [Id] = @id";
            if (!Delete(query, new { id }))
            {
                throw new InvalidOperationException("Could not delete movie");
            }
        }

        public Movie Get(int id)
        {
            string query = @"
SELECT [Id]
	,[Name]
	,[Year_Of_Release] AS [YearOfRelease]
	,[Plot]
    ,[Poster] AS [CoverImage]
    ,[Producer_Id] as [Producer]
FROM Foundation.Movies
WHERE[Id] = @id";
            return QueryDBSingle(query, new { id });

        }

        public List<Movie> Get()
        {
            string query = @"
SELECT [Id]
	,[Name]
	,[Year_Of_Release] AS [YearOfRelease]
	,[Plot]
    ,[Poster] AS [CoverImage]
    ,[Producer_Id] as [Producer]
FROM Foundation.Movies";
            return QueryDB(query, null).ToList();

        }

        public List<Movie> GetByYear(int year)
        {
            string query = @"
SELECT [Id]
	,[Name]
	,[Year_Of_Release] AS [YearOfRelease]
	,[Plot]
    ,[Poster] AS [CoverImage]
    ,[Producer_Id] as [Producer]
FROM Foundation.Movies
WHERE[Year_Of_Release] = @year";
            return QueryDB(query, new { year }).ToList();

        }

        public void Update(int id, Movie movie, string actors, string genres)
        {
            movie.Id = id;
            ExecuteStoredProcedure<int>("usp_update_movie", new
            {
                movie.Id,
                movie.Name,
                movie.YearOfRelease,
                movie.Producer,
                movie.Plot,
                movie.CoverImage,
                actors,
                genres
            });

        }
    }
}
