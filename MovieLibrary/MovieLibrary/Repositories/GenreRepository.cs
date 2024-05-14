using Microsoft.Extensions.Options;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IOptions<ConnectionString> connectionString) :
            base(connectionString.Value.IMDB)
        {
        }
        public int Create(Genre genre)
        {
            return StoredProcedure("usp_insert_genre", new
            {
                genre.Name,
            }).Id;
        }

        public void Update(int id, Genre genre)
        {
            genre.Id = id;
            StoredProcedure("usp_update_genre", new
            {
                genre.Id,
                genre.Name,
            });
        }

        public Genre Get(int id)
        {
            string sql = @"
SELECT [Id]
    ,[Name]
FROM Genres (NOLOCK)
WHERE [Id] = @id";

            return GetById(sql, new { Id = id });
        }

        public List<Genre> Get()
        {
            string sql = @"
SELECT [Id]
    ,[Name]
FROM Genres (NOLOCK)";

            return Get(sql).ToList();
        }

        public List<Genre> GetByMovie(int movieId)
        {
            string sql = @"
SELECT g.[Id]
	,g.[Name]
FROM genres AS g (NOLOCK)
INNER JOIN Movies_Genres AS m ON g.[Id] = m.[GenreId]
WHERE m.[MovieId] = @movieId";

            return Get(sql, new { movieId }).ToList();
        }

        public void Delete(int id)
        {
            string sql = @"DELETE 
FROM Genres 
WHERE [Id] = @id";

            Delete(sql, new { Id = id });
        }

    }
}
