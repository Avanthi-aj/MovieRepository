using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IGenreService
    {
        void Create(GenreRequestModel genre);
        void Update(int id, GenreRequestModel genre);
        GenreResponseModel Get(int id);
        List<GenreResponseModel> Get();
        void Delete(int id);
    }
}
