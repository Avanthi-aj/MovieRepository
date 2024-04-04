using AutoMapper;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IMapper mapper) {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public void Create(ActorRequestModel actor)
        {
            _actorRepository.Create(_mapper.Map<Actor>(actor));
        }

        public void Delete(int id)
        {
            try {
                ValidateById(id);
                _actorRepository.Delete(id);
            }
            catch
            {
                throw;
            }
            
        }

      
        public ActorResponseModel Get(int id)
        {
            try
            {
                ValidateById(id);
                return _mapper.Map<ActorResponseModel>(_actorRepository.Get(id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ActorResponseModel> Get()
        {
            return _mapper.Map<List<ActorResponseModel>>(_actorRepository.Get()); 
        }

        public void Update(int id, ActorRequestModel actor)
        {
            try
            {
                ValidateById(id);
                _actorRepository.Update(id, _mapper.Map<Actor>(actor));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateById(int id)
        {
            var actor = _actorRepository.Get(id);
            if (actor == null)
            {
                throw new ArgumentException("Actor does not exist");
            }
        }

    }
}
