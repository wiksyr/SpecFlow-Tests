using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class TrelloAPIAssertSteps : TestContext
{
    [Then(@"I receive an (.*) response")]
    public void ThenResponseStatusCodeShouldBe200(HttpStatusCode statusCode)
    {
        Assert.That(GetResponse().StatusCode, Is.EqualTo(statusCode));
    }

    [Then(@"I receive a response matching the schema '(.*)'")]
    public void ThenResponseShouldContainListOfCards(string schemaPath)
    {
        var responseContent = JToken.Parse(GetResponse().Content!);
        var jsonSchema = JSchema.Parse(File.ReadAllText($"Resources/Schemas/{schemaPath}"));
        Assert.That(responseContent.IsValid(jsonSchema), Is.True);
    }

    [Then(@"I receive an error message '(.*)'")]
    public void ThenIReceiveAnErrorMessage(string errorMessage)
    {
        Assert.That(GetResponse().Content, Does.Contain(errorMessage));
    }
}
