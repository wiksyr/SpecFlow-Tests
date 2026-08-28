using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using SpecFlow_Tests.Consts;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class GetCardsInAListSteps
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

    [Given("request with authorization")]
    public void GivenRequestWithAuthorization()
    {
        _request = GetRestRequestWithAuthorization();
    }

    [Given("request has \"id\" query parameter")]
    public void GivenRequestHasIdQueryParameter()
    {
        _request.AddUrlSegment("id", UrlParams.ExistingListId);
    }

    [When("I send a GET request to the Trello API endpoint")]
    public void WhenISendGETRequestToCardsEndpoint()
    {
        _request.Method = Method.Get;
        _request.Resource = CardsEndpoints.GetCardsInList; 
        _response = _client.ExecuteAsync(_request).Result;
    }

    [Then("I receive a 200 OK response")]
    public void ThenResponseStatusCodeShouldBe200()
    {
        Assert.That(_response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
    }

    [Then("I receive a response with the list of cards in the specified list")]
    public void ThenResponseShouldContainListOfCards()
    {
        var responseContent = JToken.Parse(_response.Content!);
        var jsonSchema = JSchema.Parse(File.ReadAllText("Resources/Schemas/get_cards.json"));
        Assert.That(responseContent.IsValid(jsonSchema), Is.True);
    }
}
