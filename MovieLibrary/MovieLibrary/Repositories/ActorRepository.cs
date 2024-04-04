using Microsoft.Extensions.Options;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {

        public ActorRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDB)
        {
        }
        public void Create(Actor actor)
        {
            const string query = @"
INSERT INTO Foundation.Actors(First_Name, Bio, DOB, Sex)
VALUES (
	@Name
	,@Bio
	,@DOB
	,@Gender
	)
";
            Create(query, actor);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Foundation.Actors
WHERE [Id] = @id";

            if (!Delete(query, new { id }))
            {
                throw new InvalidOperationException("Could not delete actor");
            }
        }

        public Actor Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[First_Name] AS [Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
FROM Foundation.Actors
WHERE [Id] = @id";
            return QueryDBSingle(query, new { id });
        }

        public List<Actor> Get()
        {
            const string query = @"
SELECT [Id]
	,[First_Name] AS [Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
FROM Foundation.Actors";
            return QueryDB(query, null).ToList();
        }

        public void Update(int id, Actor actor)
        {
            const string query = @"

UPDATE Foundation.Actors

SET [First_Name] = @Name

	,[Bio] = @Bio

	,[DOB] = @DOB

	,[Sex] = @Gender

WHERE [Id] = @id";

            actor.Id = id;

            if (!Update(query, actor))
            {
                throw new InvalidOperationException("Could not update actor");
            }
        }
    }
}
