Feature: BasicLogin
	When correct usernames and passwords are supplied a login success
	response is returned

@loginSuccess
Scenario: Correct username and password produces a success response
	Given that the user 'john' exists and his password is 'monkey'
	When the username 'john' with password 'monkey' is supplied
	Then the result should be 'Success'

@loginSuccess
Scenario: Correct username with different case and password produces a success response
	Given that the user 'john' exists and his password is 'monkey'
	When the username 'John' with password 'monkey' is supplied
	Then the result should be 'Success'

@loginFailure
Scenario: User does not exist
	Given that the user 'john' exists and his password is 'monkey'
	When the username 'jane' with password '12345' is supplied
	Then the result should be 'UserDoesNotExist'

@loginFailure
Scenario: Password is wrong
	Given that the user 'john' exists and his password is 'monkey'
	When the username 'john' with password '12345' is supplied
	Then the result should be 'WrongPassword'
