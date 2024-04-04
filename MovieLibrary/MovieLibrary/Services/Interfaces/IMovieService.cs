using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IMovieService
    {
        void Create(MovieRequestModel movie);
        void Update(int id, MovieRequestModel movie);
        MovieResponseModel Get(int id);
        List<MovieResponseModel> Get();
        List<MovieResponseModel> GetByYear(int year);
        void Delete(int id);

    }
}
