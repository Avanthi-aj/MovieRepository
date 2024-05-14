using MovieLibrary.Models;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public int Create(Genre genre);
        public void Update(int id, Genre genre);
        public void Delete(int id);
        public Genre Get(int id);
        public List<Genre> Get();
        public List<Genre> GetByMovie(int id);
    }
}
