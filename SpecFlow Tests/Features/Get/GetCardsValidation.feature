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

	
Scenario Outline: Get Cards In A List Authorization Validation
	Given request without authorization
	And request has url segments:
		| name | value |
		| id   | 6a8c73244a9a844697f317f2  |
	And request has query parameters:
		| name  | value   |
		| key   | <key>   |
		| token | <token> |
	When I send a 'Get' request to the Trello API '/1/lists/{id}/cards' endpoint
	Then I receive an Unauthorized response 
	And I receive an error message '<errorMessage>'
	Examples: 
	| key                              | token                                                                        | errorMessage |
	| 5db25c32469ff85185d010c9b2736345 | invalid_token                                                                             |       invalid app token       |
	| invalid_key                      | ATTA4af94b6e84868b13ca0a02b030c78f04d55c679edd1fe1d33a9f5f269b1f36f0DEB27D05 |       invalid key			|
	|                                  |                                                                              |       unauthorized		|  
	
Scenario Outline: Get Cards By Id Id Validation
	Given request with authorization
	And request has url segments:
		| name | value |
		| id   | <id>  |
	When I send a 'Get' request to the Trello API '/1/cards/{id}' endpoint
	Then I receive an <responseCode> response 
	And I receive an error message '<errorMessage>'
	Examples: 
	| id         | responseCode | errorMessage |
	| invalid_id |          BadRequest | invalid id   |
	| 6a8c73244a9a844697f31821 |          NotFound | not found |

Scenario Outline: Get Cards By Id Authorization Validation
	Given request without authorization
	And request has url segments:
		| name | value |
		| id   | 6a8c73244a9a844697f31824  |
	And request has query parameters:
		| name  | value   |
		| key   | <key>   |
		| token | <token> |
	When I send a 'Get' request to the Trello API '/1/cards/{id}' endpoint
	Then I receive an Unauthorized response 
	And I receive an error message '<errorMessage>'
	Examples: 
	| key                              | token                                                                        | errorMessage |
	| 5db25c32469ff85185d010c9b2736345 | invalid_token                                                                             |       invalid app token       |
	| invalid_key                      | ATTA4af94b6e84868b13ca0a02b030c78f04d55c679edd1fe1d33a9f5f269b1f36f0DEB27D05 |       invalid key			|
	|                                  |                                                                              |       unauthorized		|  