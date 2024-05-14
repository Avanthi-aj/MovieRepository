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
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository,IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public int Create(GenreRequestModel genre)
        {
            ValidateGenre(genre);
            return _genreRepository.Create(_mapper.Map<Genre>(genre));
        }

        private void ValidateGenre(GenreRequestModel genre)
        {
            if (string.IsNullOrEmpty(genre.Name))
            {
                throw new BadInputException("Genre Name cannot be Null or Empty");
            }
        }

        public void Delete(int id)
        {
            var genre = _genreRepository.Get(id);
            if(genre == null)
            {
                throw new NotFoundException($"Trying to delete the genre with ID {id} which is not present");
            }
            _genreRepository.Delete(id);
        }

        public GenreResponseModel Get(int id)
        {
            var genre = _genreRepository.Get(id);
            if (genre == null)
            {
                throw new NotFoundException($"Genre with ID {id} does not exists");
            }
            return _mapper.Map<GenreResponseModel>(genre);
        }

        public List<GenreResponseModel> Get()
        {
            var genres = _genreRepository.Get();
            return _mapper.Map<List<GenreResponseModel>>(genres);
        }

        public void Update(int id, GenreRequestModel genre)
        {
            Get(id);
            ValidateGenre(genre);
            _genreRepository.Update(id, _mapper.Map<Genre>(genre));
        }

        public List<GenreResponseModel> GetByMovie(int movieId)
        {
            var genre = _genreRepository.GetByMovie(movieId);
            return _mapper.Map<List<GenreResponseModel>>(genre);
        }
    }
}
