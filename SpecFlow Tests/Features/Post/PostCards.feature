Feature: PostCards
	As a Trello API user 
	I want to use POST '/1/cards' endpoint 
	So that I could create the card and validate its existance

@CreateCard
Scenario: Check Post Cards
	#Create a new card in a list
	Given request with authorization
	And request has query parameters:
		| name   | value                                                                        |
		| name   | Test Card                                                                    |
		| idList | 6a8c73244a9a844697f317f2                                                     |
	When I send a 'Post' request to the Trello API 'CreateCard' endpoint
	Then I receive an OK response
	And I receive a response matching the schema 'post_card.json'
	And I receive an 'id' in the response
	# Get the card by id to validate its existance
	Given request with authorization
	And request has url segments:
		| name | value                    |
		| id   | created_card_id |
	When I send a 'Get' request to the Trello API 'GetCard' endpoint
	Then I receive an OK response
