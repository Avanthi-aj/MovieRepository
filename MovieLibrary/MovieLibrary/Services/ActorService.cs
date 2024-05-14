using AutoMapper;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
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
        public int Create(ActorRequestModel actor)
        {
            ValidateActor(actor);
            return _actorRepository.Create(_mapper.Map<Actor>(actor));
            
        }
        private void ValidateActor(ActorRequestModel actor)
        {
            if (string.IsNullOrWhiteSpace(actor.Name))
            {
                throw new BadInputException("Actor Name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(actor.Bio))
            {
                throw new BadInputException("Actor Bio cannot be null or empty.");
            }
            if (actor.DOB > DateTime.Now)
            {
                throw new BadInputException("DOB cannot be in the future.");
            }
            string[] validGenders = { "Male", "Female", "Other" };
            if (actor.Gender != null && !validGenders.Contains(actor.Gender))
            {
                throw new BadInputException("Invalid gender value.");
            }
        }

        public void Delete(int id)
        {
            var actor = _actorRepository.Get(id);
            if (actor == null)
            {
                throw new NotFoundException($"Trying to delete the actor with ID {id} which is not present");
            }
            _actorRepository.Delete(id);
        }

        public ActorResponseModel Get(int id)
        {
            var actor = _actorRepository.Get(id);
            if(actor == null)
            {
                throw new NotFoundException($"Actor with Id {id} does not exists");
            }
            return _mapper.Map<ActorResponseModel>(actor);
        }

        public List<ActorResponseModel> Get()
        {
            var actors = _actorRepository.Get();
            return _mapper.Map<List<ActorResponseModel>>(actors);
        }

        public void Update(int id, ActorRequestModel actor)
        {
           Get(id);
           ValidateActor(actor);
           _actorRepository.Update(id, _mapper.Map<Actor>(actor));
           
        }

        public List<ActorResponseModel> GetByMovie(int movieId)
        {
            var actors = _actorRepository.GetByMovie(movieId);
            return _mapper.Map<List<ActorResponseModel>>(actors);
        }
    }
}
