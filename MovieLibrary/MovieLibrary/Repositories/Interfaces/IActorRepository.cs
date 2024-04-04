using MovieLibrary.Entities;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IActorRepository
    {
        void Create(Actor actor);
        void Update(int id, Actor actor);
        Actor Get(int id);
        List<Actor> Get();
        void Delete(int id);
    }
}
