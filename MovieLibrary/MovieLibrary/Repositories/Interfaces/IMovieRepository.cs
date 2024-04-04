using MovieLibrary.Entities;

namespace MovieLibrary.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        void Create(Movie movie, string actors , string genres);
        void Update(int id, Movie movie,string actors, string genres);
        Movie Get(int id);
        List<Movie> Get();
        List<Movie> GetByYear(int year);
        void Delete(int id);

    }
}
