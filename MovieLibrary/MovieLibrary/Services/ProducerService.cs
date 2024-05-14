using AutoMapper;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Repositories;
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
        public int Create(ProducerRequestModel producer)
        {
            ValidateProducer(producer);
            return _producerRepository.Create(_mapper.Map<Producer>(producer));
           
        }
        private void ValidateProducer(ProducerRequestModel producer)
        {
            if (string.IsNullOrWhiteSpace(producer.Name))
            {
                throw new BadInputException("Producer Name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(producer.Bio))
            {
                throw new BadInputException("Producer Bio cannot be null or empty.");
            }
            if (producer.DOB > DateTime.Now)
            {
                throw new BadInputException("DOB cannot be in the future.");
            }
            string[] validGenders = { "Male", "Female", "Other" };
            if (producer.Gender != null && !validGenders.Contains(producer.Gender))
            {
                throw new BadInputException("Invalid gender value.");
            }
        }

        public void Delete(int id)
        {
            var producer = _producerRepository.Get(id);
            if (producer == null)
            {
                throw new NotFoundException($"Trying to delete the producer with ID {id} which is not present");
            }
            _producerRepository.Delete(id);
        }

        public ProducerResponseModel Get(int id)
        {
            var producer = _producerRepository.Get(id);
            if (producer == null)
            {
                throw new NotFoundException($"Producer with Id {id} does not exists");
            }
            return _mapper.Map<ProducerResponseModel>(producer);
        }

        public List<ProducerResponseModel> Get()
        {
            var producers = _producerRepository.Get();
            if (producers.Count == 0)
            {
                throw new NotFoundException($"No producer has been added");
            }
            return _mapper.Map<List<ProducerResponseModel>>(producers);
        }

        public void Update(int id, ProducerRequestModel producer)
        {
            Get(id);
            ValidateProducer(producer);
            _producerRepository.Update(id, _mapper.Map<Producer>(producer));
            
        }

    }
}
