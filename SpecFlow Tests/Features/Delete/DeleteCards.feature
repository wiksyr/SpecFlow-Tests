Feature: Delete Cards
	As a Trello API user 
	I want to execute the DELETE Cards endpoint 
	So that I could delete the given by Id card

@CreateCard
Scenario: Check Delete Cards
	#Delete a card
	Given request with authorization
	And request has url segments:
		| name | value           |
		| id   | created_card_id |
	When I send a 'Delete' request to the Trello API 'DeleteCard' endpoint
	Then I receive an OK response
	# Check the card is deleted
	Given request with authorization
	And request has url segments:
		| name | value           |
		| id   | created_card_id |
	When I send a 'Get' request to the Trello API 'GetCard' endpoint
	Then I receive an NotFound response
