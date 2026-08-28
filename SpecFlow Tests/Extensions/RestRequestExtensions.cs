using RestSharp;
using SpecFlow_Tests.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlow_Tests.Extensions;

public static class RestRequestExtensions
{
    public static RestRequest AddParameters(this RestRequest request, List<ParameterDto> parameters)
    {
        foreach (var parameter in parameters)
        {
            request.AddParameter(parameter.Name, parameter.Value, parameter.Type);
        }
        return request;
    }

    public static RestRequest WithMethod(this RestRequest request, string method) {
        request.Method = Enum.Parse<Method>(method);
        return request;
    }

    public static RestRequest WithResource(this RestRequest request, string resource) {
        request.Resource = resource;
        return request;
    }
}
