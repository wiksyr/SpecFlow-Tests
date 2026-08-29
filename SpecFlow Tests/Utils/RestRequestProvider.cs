using RestSharp;
using SpecFlow_Tests.Consts;

namespace SpecFlow_Tests.Utils;

public static class RestRequestProvider
{
    public static RestRequest GetRestRequestWithAuthorization()
    {
        return GetRestRequestWithoutAuthorization()
            .AddQueryParameter("key", UrlParams.ValidKey)
            .AddQueryParameter("token", UrlParams.ValidToken);
    }
    public static RestRequest GetRestRequestWithoutAuthorization()
    {
        return new RestRequest();
    }
}
