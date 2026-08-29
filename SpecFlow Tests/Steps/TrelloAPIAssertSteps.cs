using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class TrelloAPIAssertSteps
{
    private readonly TestContext _testContext;

    public TrelloAPIAssertSteps(TestContext testContext)
    {
        _testContext = testContext;
    }

    [Then(@"I receive an (.*) response")]
    public void ThenResponseStatusCodeShouldBe200(HttpStatusCode statusCode)
    {
        Assert.That(_testContext.Response.StatusCode, Is.EqualTo(statusCode));
    }

    [Then(@"I receive a response matching the schema '(.*)'")]
    public void ThenResponseShouldContainListOfCards(string schemaPath)
    {
        var responseContent = JToken.Parse(_testContext.Response.Content!);
        var jsonSchema = JSchema.Parse(File.ReadAllText($"Resources/Schemas/{schemaPath}"));
        Assert.That(responseContent.IsValid(jsonSchema), Is.True);
    }

    [Then(@"I receive an error message '(.*)'")]
    public void ThenIReceiveAnErrorMessage(string errorMessage)
    {
        Assert.That(_testContext.Response.Content, Does.Contain(errorMessage));
    }

    [Then(@"I receive an 'id' in the response")]
    public void ThenIReceiveAnIdInTheResponse()
    {
        var fieldName = "id";

        var responseContent = JToken.Parse(_testContext.Response.Content!);

        Assert.That(responseContent[fieldName], Is.Not.Null);

        _testContext.CreatedCardId = responseContent[fieldName]!.ToString();
    }

    [Then(@"I receive (.*) response body")]
    public void ThenIReceiveExpectedResponseBody(string expectedResponseBody)
    {
        expectedResponseBody = expectedResponseBody == "empty" ? string.Empty : expectedResponseBody;
        Assert.That(_testContext.Response.Content, Is.EqualTo(expectedResponseBody));
    }

    [Then(@"The '(.*)' attribute is updated to '(.*)'")]
    public void ThenAttributeIsUpdated(string attributeName, string expectedValue)
    {
        var responseContent = JToken.Parse(_testContext.Response.Content!);
        Assert.That(responseContent[attributeName]!.ToString(), Is.EqualTo(expectedValue));
    }
}
