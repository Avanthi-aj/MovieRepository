using Moq;
using MovieLibrary.Models;
using MovieLibrary.Repositories.Interfaces;

namespace MovieLibrary.Test.MockRepositories
{
    public class ProducerMock
    {

        public static readonly Mock<IProducerRepository> ProducerRepoMock = new Mock<IProducerRepository>();

        private static readonly List<Producer> _producerList = new List<Producer>
        {
            new Producer
            {
                Id = 1,
                Name = "producer",
                Bio = "bio",
                DOB = DateTime.Parse("2003-03-03"),
                Gender = "Male"

            }
        };

        public static void MockCreate()
        {
            ProducerRepoMock.Setup(x => x.Create(It.IsAny<Producer>())).Returns(1);
        }

        public static void MockUpdate()
        {
            ProducerRepoMock.Setup(x => x.Update(It.IsAny<int>(),It.IsAny<Producer>()));
        }


        public static void MockGet()
        {
            ProducerRepoMock.Setup(x => x.Get()).Returns(_producerList);
        }

        public static void MockGetById()
        {
            ProducerRepoMock.Setup(x => x.Get(It.Is<int>(
               Id => _producerList.FirstOrDefault(producer => producer.Id == Id) != null)))
              .Returns(_producerList.First);
        }

        public static void MockDelete()
        {
            ProducerRepoMock.Setup(x => x.Delete(It.IsAny<int>()));
        }

       
    }
}
