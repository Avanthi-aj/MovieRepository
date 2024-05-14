using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IGenreService
    {
        public int Create(GenreRequestModel genre);
        public void Update(int id, GenreRequestModel genre);
        public void Delete(int id);
        public GenreResponseModel Get(int id);
        public List<GenreResponseModel> Get();
        public List<GenreResponseModel> GetByMovie(int movieId);
    }
}
