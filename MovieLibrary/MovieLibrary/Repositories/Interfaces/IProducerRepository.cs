using MovieLibrary.Entities;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        void Create(Producer producer);
        void Update(int id, Producer producer);
        Producer Get(int id);
        List<Producer> Get();
        void Delete(int id);
    }
}
