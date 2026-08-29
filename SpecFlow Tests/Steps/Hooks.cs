using Newtonsoft.Json.Linq;
using RestSharp;
using SpecFlow_Tests.Consts;
using SpecFlow_Tests.Utils;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class Hooks
{
    private TestContext _testContext;

    public Hooks(TestContext testContext)
    {
        _testContext = testContext;
    }

    [AfterScenario("DeleteCard")]
    public void DeleteCardAfterScenario()
    {
        var request = RestRequestProvider.GetRestRequestWithAuthorization()
            .AddUrlSegment("id", _testContext.CreatedCardId);
        request.Resource = Endpoint.DeleteCard.GetEndpointUrl();
        request.Method = Method.Delete; 
        _testContext.Client.ExecuteAsync(request).Wait();
    }

    [BeforeScenario("CreateCard")]
    public void CreateCardBeforeScenario()
    {
        var request= RestRequestProvider.GetRestRequestWithAuthorization()
            .AddQueryParameter("idList", UrlParams.ExistingListId)
            .AddQueryParameter("name", "Test Card " + DateTime.Now.Ticks);
        request.Resource = Endpoint.CreateCard.GetEndpointUrl();
        request.Method = Method.Post;
        var response = _testContext.Client.ExecuteAsync(request).Result;
        var responseContent = JToken.Parse(response.Content!);
        _testContext.CreatedCardId = responseContent["id"]!.ToString();
    }
}
