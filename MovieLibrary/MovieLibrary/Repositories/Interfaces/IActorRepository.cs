using MovieLibrary.Models;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IActorRepository
    {
        public int Create(Actor actor);
        public void Update(int id, Actor actor);
        public void Delete(int id);
        public Actor Get(int id);
        public List<Actor> Get();
        public List<Actor> GetByMovie(int id);
       
    }
}
