using AutoMapper;
using MovieLibrary.Entities;
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

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public void Create(GenreRequestModel genre)
        {
            _genreRepository.Create(_mapper.Map<Genre>(genre));
        }

        public void Delete(int id)
        {
            try
            {
                ValidateById(id);
                _genreRepository.Delete(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public GenreResponseModel Get(int id)
        {
            try
            {
                ValidateById(id);
                return _mapper.Map<GenreResponseModel>(_genreRepository.Get(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GenreResponseModel> Get()
        {
            return _mapper.Map<List<GenreResponseModel>>(_genreRepository.Get());
        }

        public void Update(int id, GenreRequestModel genre)
        {
            try
            {
                ValidateById(id);
                _genreRepository.Update(id,_mapper.Map<Genre>(genre));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateById(int id)
        {
            var genre = _genreRepository.Get(id);
            if (genre == null)
            {
                throw new ArgumentException("Genre does not exist");
            }
        }
    }
}
