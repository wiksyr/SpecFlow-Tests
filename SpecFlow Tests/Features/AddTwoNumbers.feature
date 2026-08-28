Feature: Add two numbers
	As a calculator user 
	I want to add two numbers 
	So that I can confirm that the calculation is correct

@tag1
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
