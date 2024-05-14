using MovieLibrary.ResponseModel;
using MovieLibrary.RequestModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IMovieService
    {
        public int Create(MovieRequestModel movie);
        public void Update(int id, MovieRequestModel movie);
        public void Delete(int id);
        public MovieResponseModel Get(int id);
        public List<MovieResponseModel> GetAll();
        public List<MovieResponseModel> GetAll(int year);
    }
}
