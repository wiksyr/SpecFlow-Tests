Feature: Post Cards Validation
	As a Trello API user 
	I want to validate the endpoints for post cards 
	So that I can confirm that they are working only with expected inputs and have authorization mechanism

Scenario Outline: Post Cards Id Validation
	Given request with authorization
	And request has query parameters:
		| name   | value |
		| idList | <id>  |
		| name       |   Test Create Card    |
	When I send a 'Post' request to the Trello API 'CreateCard' endpoint
	Then I receive an <responseCode> response 
	And I receive an error message '<errorMessage>'
	Examples: 
	| id         | responseCode | errorMessage |
	| invalid_id |          BadRequest | invalid value for idList   |
	| 6a8c73244a9a844697f317f1 |          NotFound | could not find |

	
Scenario Outline: Post Cards Authorization Validation
	Given request without authorization
	And request has query parameters:
		| name  | value   |
		| key   | <key>   |
		| token | <token> |
		| idList | 6a8c73244a9a844697f317f2  |
		| name       |   Test Create Card    |
	When I send a 'Post' request to the Trello API 'CreateCard' endpoint
	Then I receive an Unauthorized response 
	And I receive an error message '<errorMessage>'
	Examples: 
	| key                              | token                                                                        | errorMessage |
	| 5db25c32469ff85185d010c9b2736345 | invalid_token                                                                             |       invalid app token       |
	| invalid_key                      | ATTA4af94b6e84868b13ca0a02b030c78f04d55c679edd1fe1d33a9f5f269b1f36f0DEB27D05 |       invalid key			|
	|                                  |                                                                              |       missing scopes		|  