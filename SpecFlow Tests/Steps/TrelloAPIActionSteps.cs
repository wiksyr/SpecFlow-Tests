using Newtonsoft.Json.Schema;
using RestSharp;
using SpecFlow_Tests.Consts;
using SpecFlow_Tests.Extensions;
using SpecFlow_Tests.Utils;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class TrelloAPIActionSteps
{

    private readonly TestContext _testContext;

    public TrelloAPIActionSteps(TestContext testContext)
    {
        _testContext = testContext;
    }

    [Given(@"request (with|without) authorization")]
    public void GivenRequestWithAuthorization(bool withAuthorization)
    {
        _testContext.Request = withAuthorization ? RestRequestProvider.GetRestRequestWithAuthorization() : RestRequestProvider.GetRestRequestWithoutAuthorization();
    }

    [Given(@"request has url segments:")]
    public void GivenRequestHasUrlSegments(Table urlSegments)
    {
        foreach (var row in urlSegments.Rows)
        {
            var value = row["value"];
            value = value == "created_card_id" ? _testContext.CreatedCardId : value;
            _testContext.Request = _testContext.Request.AddUrlSegment(row["name"], value);
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
        _testContext.Response = _testContext.Client.ExecuteAsync(_testContext.Request).Result;
    }
}
