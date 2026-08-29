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

    [AfterScenario("CreateCard")]
    public void AfterCreateCardScenario()
    {
        var request = RestRequestProvider.GetRestRequestWithAuthorization()
            .AddUrlSegment("id", _testContext.CreatedCardId);
        request.Resource = Endpoint.DeleteCard.GetEndpointUrl();
        request.Method = Method.Delete; 
        _testContext.Client.ExecuteAsync(request).Wait();
    }
}
