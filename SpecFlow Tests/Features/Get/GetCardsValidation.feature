Feature: Get Cards Validation
	As a Trello API user 
	I want to validate the endpoints for get cards 
	So that I can confirm that they are working only with expected inputs and have authorization mechanism

Scenario Outline: Get Cards In A List Id Validation
	Given request with authorization
	And request has url segments:
		| name | value |
		| id   | <id>  |
	When I send a 'Get' request to the Trello API '/1/lists/{id}/cards' endpoint
	Then I receive an <responseCode> response 
	And I receive an error message '<errorMessage>'
	Examples: 
	| id         | responseCode | errorMessage |
	| invalid_id |          BadRequest | invalid id   |
	| 6a8c73244a9a844697f31821 |          NotFound | not found |
