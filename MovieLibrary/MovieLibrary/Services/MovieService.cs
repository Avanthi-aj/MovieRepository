using System.Xml.Linq;
using AutoMapper;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.RequestModel;
using MovieLibrary.ResponseModel;
using MovieLibrary.Services.Interfaces;

namespace MovieLibrary.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorService _actorService;
        private readonly IGenreService _genreService;
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository,
                            IActorService actorService,
                            IGenreService genreService,
                            IProducerService producerService,
                            IMapper mapper)
        {
            _movieRepository = movieRepository;
            _actorService = actorService;
            _genreService = genreService;
            _producerService = producerService;
            _mapper = mapper;
        }
        public int Create(MovieRequestModel movie)
        {
            ValidateMovie(movie);
            return _movieRepository.Create(_mapper.Map<Movie>(movie), 
                string.Join(',', movie.Actors), string.Join(',', movie.Genres));
            
        }

        private void ValidateMovie(MovieRequestModel movie)
        {
            if (string.IsNullOrWhiteSpace(movie.Name))
            {
                throw new BadInputException("Movie Name cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(movie.Plot))
            {
                throw new BadInputException("Movie plot cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(movie.CoverImage))
            {
                throw new BadInputException("Movie CoverImage cannot be null or empty");
            }

            if (movie.YearOfRelease <= 0 || movie.YearOfRelease > DateTime.Now.Year)
            {
                throw new BadInputException("Year of release must be a valid year");
            }

            var producer = _producerService.Get(movie.Producer);
            if(producer == null)
            {
                throw new NotFoundException($"Producer with ID {movie.Producer} does not exist");
            }

            foreach( int genreId in movie.Genres){
                var genre = _genreService.Get(genreId);
                if(genre == null)
                {
                    throw new NotFoundException($"Genre with ID {genreId} does not exist");
                }
            }

            foreach (int actorId in movie.Actors)
            {
                var actor = _actorService.Get(actorId);
                if (actor == null)
                {
                    throw new NotFoundException($"Actor with ID {actorId} does not exist");
                }
            }
        }

        public void Delete(int id)
        {
            var movie = _movieRepository.Get(id);
            if(movie == null)
            {
                throw new NotFoundException($"Trying to delete the movie with ID {id} which is not present");
            }
            _movieRepository.Delete(id);
        }


        public MovieResponseModel Get(int id)
        {
            var movie = _movieRepository.Get(id);
            if (movie == null)
            {
                throw new NotFoundException($"Movie with ID {id} does not exist");
            }
            var movieResponse = _mapper.Map<MovieResponseModel>(movie);
            movieResponse.Actors = _actorService.GetByMovie(movieResponse.Id);
            movieResponse.Genres = _genreService.GetByMovie(movieResponse.Id);
            movieResponse.Producer = _producerService.Get(movie.Producer);
            return movieResponse;
        }

        public List<MovieResponseModel> GetAll(int year)
        {
            if (year == 0 || _movieRepository.GetAll(year).Count == 0)
            {
               return GetAll();
            }
            else
            {
                var movies = _movieRepository.GetAll(year);
                var movieResponse = _mapper.Map<List<MovieResponseModel>>(movies);
                for (int i = 0; i < movieResponse.Count; i++)
                {
                    movieResponse[i].Actors = _actorService.GetByMovie(movieResponse[i].Id);
                    movieResponse[i].Producer = _producerService.Get(movies[i].Producer);
                    movieResponse[i].Genres = _genreService.GetByMovie(movieResponse[i].Id);
                }
                return movieResponse;
            }  
        }
         public List<MovieResponseModel> GetAll()
        {
            var movies = _movieRepository.GetAll();
            var movieResponse = _mapper.Map<List<MovieResponseModel>>(movies);
            for(int i=0; i<movieResponse.Count; i++)
            {
                movieResponse[i].Actors = _actorService.GetByMovie(movieResponse[i].Id);
                movieResponse[i].Producer = _producerService.Get(movies[i].Producer);
                movieResponse[i].Genres = _genreService.GetByMovie(movieResponse[i].Id);

            }
            return movieResponse;
        }
        public void Update(int id, MovieRequestModel movie)
        {
            Get(id);
            ValidateMovie(movie);
            _movieRepository.Update(id, _mapper.Map<Movie>(movie),
                string.Join(',', movie.Actors), string.Join(',', movie.Genres));
           
        }
    }
}
