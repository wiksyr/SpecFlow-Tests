using RestSharp;

namespace SpecFlow_Tests.Steps;

public class TestContext
{
    public RestRequest Request { get; set; }
    public RestResponse Response { get; set; }
    public RestClient Client { get; } = new RestClient("https://api.trello.com");
    public string CreatedCardId { get; internal set; }
}
