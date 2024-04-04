using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IActorService
    {
        void Create(ActorRequestModel actor);
        void Update(int id, ActorRequestModel actor);
        ActorResponseModel Get(int id);
        List<ActorResponseModel> Get();
        void Delete(int id);
    }
}
