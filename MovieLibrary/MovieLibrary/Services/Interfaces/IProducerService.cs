using MovieLibrary.Entities;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IProducerService
    {
        void Create(ProducerRequestModel producer);
        void Update(int id, ProducerRequestModel producer);
        ProducerResponseModel Get(int id);
        List<ProducerResponseModel> Get();
        void Delete(int id);
    }
}
