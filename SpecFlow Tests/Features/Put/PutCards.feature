Feature: Put Cards
	As a Trello API User
	I want to execute the PUT Cards endpoint 
	So that I could update the given by Id card

@CreateCard
@DeleteCard
Scenario: Check Put Cards
    #Update a card
	Given request with authorization
	And request has url segments:
		| name | value                    |
		| id   | created_card_id |
	And request has query parameters:
		| name | value             |
		| name | Updated Card Name |
	When I send a 'Put' request to the Trello API 'UpdateCard' endpoint
	Then I receive an OK response
	And I receive a response matching the schema 'put_cards.json'
	#Check update
	Given request with authorization
	And request has url segments:
		| name | value           |
		| id   | created_card_id |
	When I send a 'Get' request to the Trello API 'GetCard' endpoint
	Then I receive an OK response
	And The 'name' attribute is updated to 'Updated Card Name'
