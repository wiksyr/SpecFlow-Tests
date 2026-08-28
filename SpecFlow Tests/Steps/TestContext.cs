using RestSharp;

namespace SpecFlow_Tests.Steps;

public class TestContext
{
    public RestRequest Request { get; set; }
    public RestResponse Response { get; set; }
}
