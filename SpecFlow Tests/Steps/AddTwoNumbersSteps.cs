using TechTalk.SpecFlow;

namespace SpecFlow_Tests.Steps;

[Binding]
public class AddTwoNumbersSteps
{
    private int _numberOne;
    private int _numberTwo;
    private int _result; 

    [Given(@"I have entered 50 into the calculator")]
    public void GivenIHaveEntered50IntoTheCalculator()
    {
        _numberOne = 50;
    }

    [Given(@"I have entered 70 into the calculator")]
    public void GivenIHaveEntered70IntoTheCalculator()
    {
        _numberTwo = 70;
    }

    [When(@"I press add")]
    public void WhenIPressAdd()
    {
        _result = _numberOne + _numberTwo;
    }

    [Then(@"the result should be 120 on the screen")]
    public void ThenTheResultShouldBeOnTheScreen()
    {
        Assert.That(_result, Is.EqualTo(120));
    }
}
