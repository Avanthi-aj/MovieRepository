using Moq;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Test.MockRepositories
{
    public class GenreMock
    {
        public static readonly Mock<IGenreRepository> GenreRepoMock = new Mock<IGenreRepository>();

        private static readonly List<Genre> _genreList = new List<Genre>
        {
            new Genre
            {
                Id = 1,
                Name = "genre",

            }
        };

        private static readonly Dictionary<int, List<int>> Genresmovies = new Dictionary<int, List<int>>{
            {
                1,
                new List<int>
                {
                   1
                }
            }
        };

        public static void MockCreate()
        {
            GenreRepoMock.Setup(x => x.Create(It.IsAny<Genre>())).Returns(1);
        }

        public static void MockUpdate()
        {
            GenreRepoMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Genre>()));
        }

        public static void MockDelete()
        {
            GenreRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }

        public static void MockGet()
        {
            GenreRepoMock.Setup(x => x.Get()).Returns(_genreList);
        }

        public static void MockGetById()
        {
            GenreRepoMock.Setup(x => x.Get(It.Is<int>(
                Id => _genreList.FirstOrDefault(genre => genre.Id == Id) != null)))
               .Returns(_genreList.First);
        }
        public static void MockGetByMovieID()
        {
            GenreRepoMock.Setup(x => x.GetByMovie(It.IsAny<int>())).Returns((int movieId) =>
            {
                List<Genre> genres = new List<Genre>();

                if (Genresmovies.ContainsKey(movieId))
                {
                    var genreIds = Genresmovies[movieId];
                    genres = _genreList.Where(genre => genreIds.Contains(genre.Id)).ToList();
                }

                return genres;
            });
        }
    }
}
