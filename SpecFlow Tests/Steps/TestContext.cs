using RestSharp;

namespace SpecFlow_Tests.Steps;

public class TestContext
{
    private static readonly ThreadLocal<RestRequest> _request = new(); 
    private static readonly ThreadLocal<RestResponse> _response = new();

    public RestRequest GetRequest() => _request.Value!;

    public RestResponse GetResponse() => _response.Value!;

    public void SetRequest(RestRequest request) => _request.Value = request;

    public void SetResponse(RestResponse response) => _response.Value = response;
}
