using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;

namespace MovieLibrary.Test.StepDefinitions
{
    public class BaseStepDefinition
    {
        protected WebApplicationFactory<TestStartup> _factory;
        protected HttpClient _client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public BaseStepDefinition(WebApplicationFactory<TestStartup> baseFactory)
        {
            _factory = baseFactory;
        }
        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri($"http://localhost/")
            });
        }

        [When(@"I make a post request to '(.*)' with the following data '(.*)'")]
        public virtual async Task WhenIMakeAPostRequestToWithTheFollowingData(string endPoint, string data)
        {
            var uri = new Uri(endPoint, UriKind.Relative);
            var value = new StringContent(data, Encoding.UTF8, "application/json");
            Response = await _client.PostAsync(uri, value);
        }

        [When(@"I make a put request to '(.*)' with the following data '(.*)'")]
        public virtual async Task MakePut(string endPoint,string data)
        {
            var uri = new Uri(endPoint, UriKind.Relative);
            var value = new StringContent(data, Encoding.UTF8, "application/json");
            Response = await _client.PutAsync(uri, value);
        }

        [When(@"I make a delete request to '(.*)'")]
        public virtual async Task MakeDelete(string endPoint)
        {
            var uri = new Uri(endPoint, UriKind.Relative);
            Response = await _client.DeleteAsync(uri);
        }

        [When(@"I make a get request to '(.*)'")]
        public virtual async Task MakeGet(string endpoint)
        {
            var uri = new Uri(endpoint, UriKind.Relative);
            Response = await _client.GetAsync(uri);
        }


        [Then(@"the response code is '(.*)'")]
        public void ThenTheResponseStatusCodeIs(int code)
        {
            var expectedStatusCode = (HttpStatusCode)code;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }


        [Then(@"response data should be '(.*)'")]
        public void ThenTheResponseDataShouldBe(string expectedResponse)
        {
            var actualResponse = Response.Content.ReadAsStringAsync().Result;
            Assert.Equal(expectedResponse, actualResponse);
        }

    }
}
