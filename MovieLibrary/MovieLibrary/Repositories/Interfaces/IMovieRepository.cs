using MovieLibrary.Models;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        public int Create(Movie movie, string actors, string genres);
        public void Update(int id, Movie movie, string actors, string genres);
        public void Delete(int id);

        public List<Movie> GetAll();
        public List<Movie> GetAll(int year);
        public Movie Get(int id);
      
    }
}
