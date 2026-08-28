using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class TrelloAPISteps
{
    private static RestClient _client = new RestClient("https://api.trello.com");

    private RestRequest _request;
    private RestResponse _response;

    protected RestRequest GetRestRequestWithAuthorization()
    {
        return GetRestRequestWithoutAuthorization()
            .AddQueryParameter("key", "5db25c32469ff85185d010c9b2736345")
            .AddQueryParameter("token", "ATTA4af94b6e84868b13ca0a02b030c78f04d55c679edd1fe1d33a9f5f269b1f36f0DEB27D05");
    }
    protected RestRequest GetRestRequestWithoutAuthorization()
    {
        return new RestRequest();
    }

    [Given(@"request with authorization")]
    public void GivenRequestWithAuthorization()
    {
        _request = GetRestRequestWithAuthorization();
    }

    [Given(@"request without authorization")]
    public void GivenRequestWithoutAuthorization()
    {
        _request = GetRestRequestWithoutAuthorization();
    }

    [Given(@"request has url segments:")]
    public void GivenRequestHasUrlSegments(Table urlSegments)
    {
        foreach (var row in urlSegments.Rows)
        {
            _request.AddUrlSegment(row["name"], row["value"]);
        }
    }

    [Given(@"request has query parameters:")]
    public void GivenRequestHasQueryParameters(Table queryParameters)
    {
        foreach (var row in queryParameters.Rows)
        {
            _request.AddQueryParameter(row["name"], row["value"]);
        }
    }

    [When(@"I send a '(.*)' request to the Trello API '(.*)' endpoint")]
    public void WhenISendRequestToCardsEndpoint(string method, string url)
    {
        _request.Method = Enum.Parse<Method>(method);
        _request.Resource = url;
        _response = _client.ExecuteAsync(_request).Result;
    }

    [Then(@"I receive an (.*) response")]
    public void ThenResponseStatusCodeShouldBe200(HttpStatusCode statusCode)
    {
        Assert.That(_response.StatusCode, Is.EqualTo(statusCode));
    }

    [Then(@"I receive a response matching the schema '(.*)'")]
    public void ThenResponseShouldContainListOfCards(string schemaPath)
    {
        var responseContent = JToken.Parse(_response.Content!);
        var jsonSchema = JSchema.Parse(File.ReadAllText($"Resources/Schemas/{schemaPath}"));
        Assert.That(responseContent.IsValid(jsonSchema), Is.True);
    }

    [Then(@"I receive an error message '(.*)'")]
    public void ThenIReceiveAnErrorMessage(string errorMessage)
    {
        Assert.That(_response.Content, Does.Contain(errorMessage));
    }
}
