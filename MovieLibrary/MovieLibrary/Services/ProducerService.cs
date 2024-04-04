using AutoMapper;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;
        public ProducerService(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }
    
        public void Create(ProducerRequestModel producer)
        {
           _producerRepository.Create(_mapper.Map<Producer>(producer));
        }

        public void Delete(int id)
        {
            try
            {
                ValidateById(id);
                _producerRepository.Delete(id);
            }
            catch 
            {
                throw;
            }
        }

        public ProducerResponseModel Get(int id)
        {
            try
            {
                ValidateById(id);
                return _mapper.Map<ProducerResponseModel>(_producerRepository.Get(id));
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<ProducerResponseModel> Get()
        {
            return _mapper.Map<List<ProducerResponseModel>>(_producerRepository.Get());
        }

        public void Update(int id, ProducerRequestModel producer)
        {
            try
            {
                ValidateById(id);
                _producerRepository.Update(id, _mapper.Map<Producer>(producer));
            }
            catch(Exception)
            {
                throw;
            }
        }
        private void ValidateById(int id)
        {
            var producer = _producerRepository.Get(id);
            if (producer == null)
            {
                throw new ArgumentException("Producer does not exist");
            }
        }
    }
}
