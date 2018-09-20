Feature: Posts
	In order to do automated tests with API
	As a tester
	I want to make actions with posts

Background: 
	Given the API is up

Scenario: Search all posts
	When I send a request to search all posts
	Then returned JSON objects is not null

Scenario Outline: Search posts by ID
	When I send a request to search post with id <id>
	Then returned <status> request status

	Examples: 
	| id | status |
	| 1  | 200    |
	| 10 | 200    |
	| 17 | 200    |
	| 0  | 404    |

Scenario Outline: Search posts by user ID
	When I send a request to search post with user id <userid>
	Then returned <status> request status

	Examples: 
	| userid | status |
	| 2      | 200    |
	| 5      | 200    |
	| 7      | 200    |
	| 0      | 404    |

Scenario: Register post
	When I send a request to register a post
	Then returned 201 request status

Scenario Outline: Update post
	When I send a request to update post with id <id>
	Then returned <status> request status

	Examples: 
	| id | status |
	| 10 | 200    |
	| 0  | 404    |

Scenario Outline: Delete post
	When I send a request to delete post with id <id>
	Then returned <status> request status
		And the post was deleted

	Examples: 
	| id | status |
	| 5  | 200    |
	| 0  | 404    |


