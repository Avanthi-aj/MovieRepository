
using MovieLibrary.Entities;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        void Create(Genre genre);
        void Update(int id, Genre genre);
        Genre Get(int id);
        List<Genre> Get();
        void Delete(int id);
    }
}
