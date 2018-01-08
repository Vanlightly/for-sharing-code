Feature: BasicLoginWithTables
	When correct usernames and passwords are supplied a login success
	response is returned

@TableBased
Scenario Outline: Usernames and passwords produce different responses
	Given the following users exist:
	| username | password |
	| john     | monkey   |
	| mick     | 123456   |
	| joe      | 654321   |
	When the username '<username>' with password '<password>' is supplied
	Then the result should be '<result>'

Examples:
	| username | password | result           |
	| john     | monkey   | Success          |
	| john     | 12345    | WrongPassword    |
	| jane     | 123      | UserDoesNotExist |