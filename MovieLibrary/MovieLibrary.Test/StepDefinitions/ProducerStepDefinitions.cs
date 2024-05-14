using MovieLibrary.Tests.MockResources;
using MovieLibrary.Tests;
using MovieLibrary.Test.MockRepositories;
using Microsoft.Extensions.DependencyInjection;


namespace MovieLibrary.Test.StepDefinitions
{

    [Scope(Feature = "Producer Management in Movie Library")]
    [Binding]
    public class ProducerStepDefinitions : BaseStepDefinition
    {
        public ProducerStepDefinitions(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient(_ => ProducerMock.ProducerRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ProducerMock.MockGet();
            ProducerMock.MockGetById();
            ProducerMock.MockCreate();
            ProducerMock.MockUpdate();
            ProducerMock.MockDelete();
        }
    }
}