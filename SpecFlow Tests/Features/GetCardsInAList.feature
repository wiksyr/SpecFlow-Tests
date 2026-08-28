Feature: Get Cards In A List
	As a Trello API user 
	I want to get list of cards in a list 
	So that I query one single endpoint to retrieve the list of the cards

@TrelloAPI
Scenario: Get Trello Cards In A List
	Given request with authorization 
	And request has 'id' query parameter with a value '6a8c73244a9a844697f317f2'
	When I send a GET request to the Trello API endpoint
	Then I receive a 200 OK response
	And I receive a response with the list of cards in the specified list


Scenario: Get Trello Card By Id
	Given request with authorization
	And request has "id" query parameter
	When I send a GET request to the Trello API endpoint
	Then I receive a 200 OK response
	And I receive a response with the card details for the specified card Id
