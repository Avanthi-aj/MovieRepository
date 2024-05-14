using Moq;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Test.MockRepositories
{
    public class ReviewMock
    {
        public static readonly Mock<IReviewRepository> ReviewRepoMock = new Mock<IReviewRepository>();

        private static readonly List<Review> _reviewList = new List<Review>
        {
            new Review
            {
                Id = 1,
                Message = "message",
                MovieId = 1
            }
        };

       
        public static void MockCreate()
        {
            ReviewRepoMock.Setup(x => x.Create(It.IsAny<Review>())).Returns(1);
        }

        public static void MockUpdate()
        {
            ReviewRepoMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Review>()));
        }

        public static void MockGet()
        {
            ReviewRepoMock.Setup(repo => repo.Get(It.Is<int>(
                 movieId => _reviewList.FirstOrDefault(review => review.MovieId == movieId) != null)))
                .Returns(_reviewList);
        }
        public static void MockGetById()
        {
            ReviewRepoMock.Setup(repo => repo.Get(It.Is<int>(
                 Id => _reviewList.FirstOrDefault(review => review.Id == Id) != null), It.Is<int>(
                 movieId => _reviewList.FirstOrDefault(review => review.MovieId == movieId) != null)))
               .Returns(_reviewList.First);
        }

        public static void MockDelete()
        {
            ReviewRepoMock.Setup(x => x.Delete(It.IsAny<int>(),It.IsAny<int>()));
        }

    }
}
