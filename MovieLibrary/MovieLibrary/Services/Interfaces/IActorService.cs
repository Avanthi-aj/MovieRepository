using MovieLibrary.ResponseModel;
using MovieLibrary.RequestModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IActorService
    {
        public int Create(ActorRequestModel actor);
        public void Update(int id, ActorRequestModel actor);
        public void Delete(int id);
        public ActorResponseModel Get(int id);
        public List<ActorResponseModel> Get();
        public List<ActorResponseModel> GetByMovie(int movieId);
    }
}
