using RestSharp;
using SpecFlow_Tests.Consts;
using SpecFlow_Tests.Extensions;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class TrelloAPIActionSteps
{
    private static RestClient _client = new RestClient("https://api.trello.com");

    private readonly TestContext _testContext;

    public TrelloAPIActionSteps(TestContext testContext)
    {
        _testContext = testContext;
    }

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

    [Given(@"request (with|without) authorization")]
    public void GivenRequestWithAuthorization(bool withAuthorization)
    {
        _testContext.Request = withAuthorization ? GetRestRequestWithAuthorization() : GetRestRequestWithoutAuthorization();
    }

    [Given(@"request has url segments:")]
    public void GivenRequestHasUrlSegments(Table urlSegments)
    {
        foreach (var row in urlSegments.Rows)
        {
            _testContext.Request = _testContext.Request.AddUrlSegment(row["name"], row["value"]);
        }
    }

    [Given(@"request has query parameters:")]
    public void GivenRequestHasQueryParameters(Table queryParameters)
    {
        foreach (var row in queryParameters.Rows)
        {
            _testContext.Request = _testContext.Request.AddQueryParameter(row["name"], row["value"]);
        }
    }

    [When(@"I send a '(.*)' request to the Trello API '(.*)' endpoint")]
    public void WhenISendRequestToCardsEndpoint(string method, Endpoint endpoint)
    {
        _testContext.Request = _testContext.Request.WithMethod(method).WithResource(endpoint.GetEndpointUrl());
        _testContext.Response = _client.ExecuteAsync(_testContext.Request).Result;
    }
}
