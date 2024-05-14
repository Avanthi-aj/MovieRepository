using Microsoft.Extensions.Options;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(IOptions<ConnectionString> connectionString) :
            base(connectionString.Value.IMDB)
        { }
        public int Create(Producer producer)
        {
            return StoredProcedure("usp_insert_producer", new
            {
                producer.Name,
                producer.Bio,
                producer.DOB,
                producer.Gender
            }).Id;
        }

        public void Update(int id, Producer producer)
        {
            producer.Id = id;
            StoredProcedure("usp_update_producer", new
            {
                producer.Id,
                producer.Name,
                producer.Bio,
                producer.DOB,
                producer.Gender
            });
        }

        public Producer Get(int id)
        {
            string sql = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Gender]
FROM Producers (NOLOCK)
WHERE [Id] = @id";

            return GetById(sql, new { Id = id });
        }

        public List<Producer> Get()
        {
            string sql = @"
SELECT [Id]
	,[Name]
	,[Bio]
	,[DOB]
	,[Gender] 
FROM Producers (NOLOCK)";

            return Get(sql).ToList();
        }

    
        public void Delete(int id)
        {
            string sql = @"
DELETE 
FROM Producers 
WHERE [Id] = @id";

            Delete(sql, new { Id = id });
        }


    }
}
