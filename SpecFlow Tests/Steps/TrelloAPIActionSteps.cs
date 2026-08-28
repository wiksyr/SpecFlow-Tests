using RestSharp;
using SpecFlow_Tests.Extensions;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class TrelloAPIActionSteps : TestContext
{
    private static RestClient _client = new RestClient("https://api.trello.com");

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
        SetRequest(GetRestRequestWithAuthorization());
    }

    [Given(@"request without authorization")]
    public void GivenRequestWithoutAuthorization()
    {
        SetRequest(GetRestRequestWithoutAuthorization());
    }

    [Given(@"request has url segments:")]
    public void GivenRequestHasUrlSegments(Table urlSegments)
    {
        foreach (var row in urlSegments.Rows)
        {
            SetRequest(GetRequest().AddUrlSegment(row["name"], row["value"]));
        }
    }

    [Given(@"request has query parameters:")]
    public void GivenRequestHasQueryParameters(Table queryParameters)
    {
        foreach (var row in queryParameters.Rows)
        {
            SetRequest(GetRequest().AddQueryParameter(row["name"], row["value"]));
        }
    }

    [When(@"I send a '(.*)' request to the Trello API '(.*)' endpoint")]
    public void WhenISendRequestToCardsEndpoint(string method, string url)
    {
        SetRequest(GetRequest().WithMethod(method).WithResource(url));
        SetResponse(_client.ExecuteAsync(GetRequest()).Result);
    }
}
