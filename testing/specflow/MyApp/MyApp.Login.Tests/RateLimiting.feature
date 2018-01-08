Feature: RateLimiting
	Login attempts of a given user must be limited to a certain amount X within a time period Y. 
	This is important to avoid brute force attacks on our users.

Background:
	Given that the user 'john' exists and his password is 'monkey'
	
@rateLimiting
Scenario: Number of attempts less than limit
	Given the limit period is 10 seconds
	And the limit in that period is 3
	When 2 logins with 0 seconds delay are attempted with user 'john' and password '123'
	Then the results should be 'WrongPassword,WrongPassword'

@rateLimiting
Scenario: Attempts inside rate limit
	Given the limit period is 10 seconds
	And the limit in that period is 3
	When 4 logins with 4 seconds delay are attempted with user 'john' and password '123'
	Then the results should be 'WrongPassword,WrongPassword,WrongPassword,WrongPassword'

@rateLimiting
Scenario: Attempts exceeds limit
	Given the limit period is 10 seconds
	And the limit in that period is 3
	When 5 logins with 0 seconds delay are attempted with user 'john' and password '123'
	Then the results should be 'WrongPassword,WrongPassword,WrongPassword,ReachedRateLimit,ReachedRateLimit'
