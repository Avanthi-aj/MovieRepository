using MovieLibrary.ResponseModel;
using MovieLibrary.RequestModel;

namespace MovieLibrary.Services.Interfaces
{
    public interface IProducerService
    {
        public int Create(ProducerRequestModel producer);
        public void Update(int id, ProducerRequestModel producer);
        public void Delete(int id);
        public ProducerResponseModel Get(int id);
        public List<ProducerResponseModel> Get();
        
    }
}
