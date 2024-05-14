using Moq;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Test.MockRepositories
{
    public class MovieMock
    {
        public static readonly Mock<IMovieRepository> MovieRepoMock = new Mock<IMovieRepository>();

        private static readonly List<Movie> _movieList = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Name = "movie",
                YearOfRelease = 2000,
                Plot = "plot here",
                CoverImage = "image",
                Producer = 1
             } 
        };

       
        public static void MockCreate()
        {
            MovieRepoMock.Setup(x => x.Create(It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>())).Returns(1);
        }

        public static void MockUpdate()
        {
            MovieRepoMock.Setup(x => x.Update(It.IsAny<int>(),
            It.IsAny<Movie>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        public static void MockGet()
        {
            MovieRepoMock.Setup(x => x.GetAll()).Returns(_movieList);
        }

        public static void MockGetById()
        {
            MovieRepoMock.Setup(x => x.Get(It.Is<int>(
                Id => _movieList.FirstOrDefault(movie => movie.Id == Id) != null)))
               .Returns(_movieList.First);
        }

            public static void MockDelete()
        {
            MovieRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }
    }
}