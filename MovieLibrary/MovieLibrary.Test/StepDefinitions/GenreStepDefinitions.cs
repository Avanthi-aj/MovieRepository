using MovieLibrary.Tests.MockResources;
using MovieLibrary.Tests;
using MovieLibrary.Test.MockRepositories;
using Microsoft.Extensions.DependencyInjection;


namespace MovieLibrary.Test.StepDefinitions
{
    [Scope(Feature = "Genre Management in Movie Library")]
    [Binding]
    public class GenreStepDefinitions : BaseStepDefinition
    {
        public GenreStepDefinitions(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockGet();
            GenreMock.MockGetById();
            GenreMock.MockCreate();
            GenreMock.MockUpdate();
            GenreMock.MockDelete();
        }
    }
}