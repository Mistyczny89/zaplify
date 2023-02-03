Feature: Password should be hidden by defauld

You should be able do show and hidden your password

Scenario: Check if password is hidden by default
	Given I am on the login page
	When I type '123456' in Passowrd Field
	Then I should see dots as my Password

Scenario: Check if number of characters in password are equal to number of dots
	Given I am on the login page
	When I type '123456' in Passowrd Field
	Then I should see dots as my Password
	And number of dots shoud be equal to number of characters in Password '123456'

Scenario: Check if toggle password visibility works
	Given I am on the login page
	When I type '123456' in Passowrd Field
	And I click on toggle password visibility button
	Then I should see '123456' in Password field

Scenario: Hide password after show
	Given I am on the login page
	When I type '123456' in Passowrd Field
	And I click on toggle password visibility button
	And I click on toggle password visibility button
	Then I should see dots as my Password


