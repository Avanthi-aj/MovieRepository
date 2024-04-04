using Microsoft.Extensions.Options;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class GenreRepository :BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDB)
        {
        }
        public void Create(Genre genre)
        {
            const string query = @"
INSERT INTO Foundation.Genres(Name)
VALUES (
	@Name
	)
";
            Create(query, genre);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Foundation.Genres
WHERE [Id] = @id";

            if (!Delete(query, new { id }))
            {
                throw new InvalidOperationException("Could not delete genre");
            }
        }

        public Genre Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[Name]
FROM Foundation.Genres
WHERE [Id] = @id";
            return QueryDBSingle(query, new { id });
        }

        public List<Genre> Get()
        {
            const string query = @"
SELECT [Id]
	,[Name]
FROM Foundation.Genres";
            return QueryDB(query, null).ToList();
        }

        public void Update(int id, Genre genre)
        {
            const string query = @"

UPDATE Foundation.Genres

SET [Name] = @Name


WHERE [Id] = @id";

            genre.Id = id;

            if (!Update(query, genre))
            {
                throw new InvalidOperationException("Could not update actor");
            }
        }
    }

}
