using MovieLibrary.Tests.MockResources;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using MovieLibrary.Tests;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using MovieLibrary.Models;
using System.Buffers.Text;
using MovieLibrary.Repositories;
using MovieLibrary.Repositories.Interfaces;
using MovieLibrary.Test.MockRepositories;

namespace MovieLibrary.Test.StepDefinitions
{
    [Scope(Feature = "Actor Management in Movie Library")]
    [Binding]
    public class ActorStepDefinitions : BaseStepDefinition
    {
        public ActorStepDefinitions(CustomWebApplicationFactory factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient( _ => ActorMock.ActorRepoMock.Object);
                });
            }))
        {
        }
        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockGet();
            ActorMock.MockGetById();
            ActorMock.MockCreate();
            ActorMock.MockUpdate();
            ActorMock.MockDelete();
        }

    }
}