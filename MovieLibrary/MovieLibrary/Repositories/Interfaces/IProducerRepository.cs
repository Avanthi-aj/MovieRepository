using MovieLibrary.Models;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IProducerRepository
    {
        public int Create(Producer producer);
        public void Update(int id, Producer producer);
        public void Delete(int id);
        public Producer Get(int id);
        public List<Producer> Get();
       
    }
}
