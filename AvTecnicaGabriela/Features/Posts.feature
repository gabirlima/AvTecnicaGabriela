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
	Then returned JSON objects is not null

	Examples: 
	| id |
	| 1  |
	| 10 |
	| 17 |

Scenario: Try search posts by invalid ID
	When I send a request to search post with id "0"
	Then returned 404 request status

Scenario Outline: Search posts by user ID
	When I send a request to search post with user id <userid>
	Then returned JSON objects is not null

	Examples: 
	| userid |
	| 2		 |
	| 5		 |
	| 7		 |

Scenario: Register post
	When I send a request to register a post
	Then returned 200 request status
		And I can search the post that I registered

Scenario: Update post
	Given I registered a post
	When I send a request to update the post
	Then returned 200 request status
		And the post was updated

Scenario: Delete post
	Given I registered a post
	When I send a request to delete the post
	Then returned 200 request status
		And the post was deleted

Scenario: Try update post that does not exist
	When I send a request to update post with invalid id
	Then returned 404 request status

Scenario: Try delete post that does not exist
	When I send a request to delete post with invalid id
	Then returned 404 request status
