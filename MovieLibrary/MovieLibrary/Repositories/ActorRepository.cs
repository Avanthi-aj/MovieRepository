using System.Globalization;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDB)
        {
        }

        public int Create(Actor actor)
        {
            return StoredProcedure("usp_insert_actor", new
            {
                actor.Name,
                actor.Bio,
                actor.DOB,
                actor.Gender
            }).Id;
        }

        public void Update(int id, Actor actor)
        {
            actor.Id = id;
            StoredProcedure("usp_update_actor", new
            {
                actor.Id,
                actor.Name,
                actor.Bio,
                actor.DOB,
                actor.Gender
            });
        }

        public Actor Get(int id)
        {
            string sql = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Gender]
FROM Actors (NOLOCK)
WHERE [Id] = @id";

            return GetById(sql, new { Id = id });
        }

        public List<Actor> Get()
        {
            string sql = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Gender]
FROM Actors (NOLOCK)";

            return Get(sql).ToList();

        }

        public List<Actor> GetByMovie(int movieId)
        {
            string sql = @"
SELECT a.[Id]
	,a.[Name]
	,a.[Bio]
	,a.[DOB]
    ,a.[Gender]
FROM actors AS a (NOLOCK)
INNER JOIN Actors_Movies AS m ON a.[Id] = m.[ActorId]
WHERE m.[MovieId] = @movieId";

            return Get(sql, new { movieId }).ToList();
        }

        public void Delete(int id)
        {
            string sql = @"
DELETE
FROM Actors
WHERE [Id] = @id";

            Delete(sql, new { Id = id });
        }

    }
}
