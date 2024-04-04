using AutoMapper;
using MovieLibrary.Entities;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;
using MovieLibrary.Services.Interfaces;


namespace MovieLibrary.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository,
                            IGenreRepository genreRepository,
                            IActorRepository actorRepository,
                            IProducerRepository producerRepository,
                            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _actorRepository = actorRepository;
            _producerRepository = producerRepository;
            _mapper = mapper;
        }
        public void Create(MovieRequestModel movierequestmodel)
        {
            try
            {
                ValidateMovieRequest(movierequestmodel);
                _movieRepository.Create(_mapper.Map<Movie>(movierequestmodel),
                     string.Join(',', movierequestmodel.Actors), string.Join(',', movierequestmodel.Genres));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                ValidateMovieById(id);
                _movieRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public MovieResponseModel Get(int id)
        {
            try
            {
                ValidateMovieById(id);
                return _mapper.Map<MovieResponseModel>(_movieRepository.Get(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MovieResponseModel> Get()
        {
            return _mapper.Map<List<MovieResponseModel>>(_movieRepository.Get());
        }

        public List<MovieResponseModel> GetByYear(int year)
        {
            return _mapper.Map<List<MovieResponseModel>>(_movieRepository.Get().Where(m=>m.YearOfRelease == year));
        }

        public void Update(int id, MovieRequestModel movierequestmodel)
        {
            
            try
            {
                ValidateMovieRequest(movierequestmodel);
                ValidateMovieById(id);
                _movieRepository.Update(id,_mapper.Map<Movie>(movierequestmodel),
                    string.Join(',', movierequestmodel.Actors), string.Join(',', movierequestmodel.Genres));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateMovieById(int id)
        {
            var movie = _movieRepository.Get(id);
            if(movie == null)
            {
                throw new ArgumentException("Movie does not exist");
            }
        }

        public void ValidateMovieRequest(MovieRequestModel movierequest)
        {
            var producerExists = _producerRepository.Get().Any(producer => producer.Id == movierequest.Producer);
            if (!producerExists)
            {
                throw new ArgumentException("Producer does not exist");
            }
            foreach (var actorRequestModel in movierequest.Actors)
            {
                if (actorRequestModel == null)
                {
                    throw new ArgumentNullException("Actor cannot be null");
                }

                var actorExists = _actorRepository.Get().Any(actor => actor.Id == actorRequestModel);
                if (!actorExists)
                {
                    throw new ArgumentException("Actor does not exist");
                }
            }
            foreach (var genreRequestModel in movierequest.Genres)
            {
                if (genreRequestModel == null)
                {
                    throw new ArgumentNullException("Genre cannot be null");
                }

                var genreExists = _genreRepository.Get().Any(genre => genre.Id == genreRequestModel);
                if (!genreExists)
                {
                    throw new ArgumentException("Genre does not exist");
                }
            }
            return;
        }
    }
}
