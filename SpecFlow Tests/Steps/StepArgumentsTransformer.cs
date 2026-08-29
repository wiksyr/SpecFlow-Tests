using SpecFlow_Tests.Consts;
using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class StepArgumentsTransformer
{
    [StepArgumentTransformation("(with|without)")]
    public bool With(string withOrWithout)
    {
        return withOrWithout == "with";
    }

    [StepArgumentTransformation("(GetCard|GetCards|CreateCard|UpdateCard|DeleteCard)")]
    public Endpoint Endpoint(string endpoint)
    {
        return Enum.Parse<Endpoint>(endpoint);
    }
}
