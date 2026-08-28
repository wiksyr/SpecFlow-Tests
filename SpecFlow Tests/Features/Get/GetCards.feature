Feature: Get Cards
	As a Trello API user 
	I want to get list of cards in a list 
	So that I query one single endpoint to retrieve the list of the cards

@TrelloAPIGetCardsInAList
Scenario: Get Trello Cards In A List
	Given request with authorization 
	And request has url segments:
		| name | value |
		| id   | 6a8c73244a9a844697f317f2 |
	When I send a GET request to the Trello API '/1/lists/{id}/cards' endpoint
	Then I receive an OK response
	And I receive a response matching the schema 'get_cards.json'

@TrelloAPIGetCardById
Scenario: Get Trello Card By Id
	Given request with authorization
	And request has url segments:
		| name | value |
		| id   | 6a8c73244a9a844697f31824 |
	When I send a GET request to the Trello API '/1/cards/{id}' endpoint
	Then I receive an OK response
	And I receive a response matching the schema 'get_card.json'
