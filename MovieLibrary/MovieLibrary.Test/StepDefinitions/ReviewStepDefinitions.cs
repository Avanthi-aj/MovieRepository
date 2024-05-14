using MovieLibrary.Tests.MockResources;
using MovieLibrary.Tests;
using MovieLibrary.Test.MockRepositories;
using Microsoft.Extensions.DependencyInjection;


namespace MovieLibrary.Test.StepDefinitions
{
    [Scope(Feature = "Review Management in Movie Library")]
    [Binding]
    public class ReviewStepDefinitions : BaseStepDefinition
    {
        public ReviewStepDefinitions(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => ReviewMock.ReviewRepoMock.Object);
                    services.AddTransient(_ => MovieMock.MovieRepoMock.Object);
                    services.AddTransient(_ => ActorMock.ActorRepoMock.Object);
                    services.AddTransient(_ => ProducerMock.ProducerRepoMock.Object);
                    services.AddTransient(_ => GenreMock.GenreRepoMock.Object);

                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            MovieMock.MockGetById();
            ReviewMock.MockGet();
            ProducerMock.MockGetById();
            ReviewMock.MockGetById();
            ReviewMock.MockCreate();
            ReviewMock.MockUpdate();
            ReviewMock.MockDelete();
            ActorMock.MockGetByMovieID();
            GenreMock.MockGetByMovieID();

        }
    }
}