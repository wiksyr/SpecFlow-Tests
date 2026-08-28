Feature: PostCards
	As a Trello API user 
	I want to use POST '/1/cards' endpoint 
	So that I could create the card and validate its existance

Scenario: Check Post Cards
	Given request with authorization
	And request has query parameters:
		| name   | value                                                                        |
		| name   | Test Card                                                                    |
		| idList | 6a8c73244a9a844697f317f2                                                     |
	When I send a 'Post' request to the Trello API '/1/cards' endpoint
	Then I receive an OK response
	And I receive a response matching the schema 'post_card.json'
