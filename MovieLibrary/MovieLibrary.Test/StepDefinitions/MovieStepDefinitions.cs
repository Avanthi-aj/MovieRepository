using MovieLibrary.Test.MockRepositories;
using MovieLibrary.Tests.MockResources;
using MovieLibrary.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;


namespace MovieLibrary.Test.StepDefinitions
{
    [Scope(Feature = "Movie Management in Movie Library")]
    [Binding]
    public class MovieStepDefinition : BaseStepDefinition { 
        public MovieStepDefinition(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
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
            ActorMock.MockGetByMovieID();
            ActorMock.MockGetById();
            ProducerMock.MockGetById();
            GenreMock.MockGetByMovieID();
            GenreMock.MockGetById();
            MovieMock.MockGet();
            MovieMock.MockGetById();
            MovieMock.MockCreate();
            MovieMock.MockUpdate();
            MovieMock.MockDelete();
        }
    }
}