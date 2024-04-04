using Microsoft.Extensions.Options;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class ProducerRepository : BaseRepository<Producer> , IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionString> connectionString)
            : base(connectionString.Value.IMDB)
        {
        }
        public void Create(Producer producer)
        {
            const string query = @"
INSERT INTO Foundation.Producers(First_Name, Bio, DOB, Sex)
VALUES (
	@Name
	,@Bio
	,@DOB
	,@Gender
	)
";
            Create(query, producer);
        }

        public void Delete(int id)
        {
            const string query = @"
DELETE
FROM Foundation.Producers
WHERE [Id] = @id";

            if (!Delete(query, new { id }))
            {
                throw new InvalidOperationException("Could not delete Producers");
            }
        }

        public Producer Get(int id)
        {
            const string query = @"
SELECT [Id]
	,[First_Name] AS [Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
FROM Foundation.Producers
WHERE [Id] = @id";
            return QueryDBSingle(query, new { id });
        }

        public List<Producer> Get()
        {
            const string query = @"
SELECT [Id]
	,[First_Name] AS [Name]
	,[Bio]
	,[DOB]
	,[Sex] AS [Gender]
FROM Foundation.Producers";
            return QueryDB(query, null).ToList();
        }

        public void Update(int id, Producer producer)
        {
            const string query = @"

UPDATE Foundation.Producers

SET [First_Name] = @Name

	,[Bio] = @Bio

	,[DOB] = @DOB

	,[Sex] = @Gender

WHERE [Id] = @id";

            producer.Id = id;

            if (!Update(query, producer))
            {
                throw new InvalidOperationException("Could not update Producers");
            }
        }
    }
}
