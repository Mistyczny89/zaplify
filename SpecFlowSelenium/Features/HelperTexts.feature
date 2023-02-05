Feature: Helper texts

When you have any inteaction with fields eg click or fill 
you should see proper helper text. 

Scenario: Helper after leaving empty fields
	Given I am on the login page
	When I click on Email field
	And I click on Password field
	And I click on Email field
	Then I should see 'Required' information under 'Email' field
	And I should see 'No password info' information under 'Password' field

Scenario: Helper when password is to short
	Given I am on the login page
	When I type 'Good Syntax Email' in Email Field
	And I click on Password field
	And I click on Email field
	And I type '5 digit password' in Passowrd Field
	Then I should see 'Short password info' information under 'Password' field

Scenario: Helper when email have bad syntax
	Given I am on the login page
	When I type 'Bad Syntax Email' in Email Field
	And I click on Password field
	Then I should see 'Invalid email' information under 'Email' field

Scenario: No any helper when email have good syntax
	Given I am on the login page
	When I type 'Good Syntax Email' in Email Field
	And I click on Password field
	Then Information under Email field should not exist

Scenario: Helper when email have good syntax and its backpaced
	Given I am on the login page
	When I type 'Good Syntax Email' in Email Field
	And I send backspace in 'Email' field 2 time(s)
	And I click on Password field
	Then I should see 'Invalid email' information under 'Email' field

Scenario: Helper when password is to short after backspace
	Given I am on the login page
	When I type 'Good Syntax Email' in Email Field
	And I click on Password field
	And I click on Email field
	And I type '6 digit password' in Passowrd Field
	And I send backspace in 'Password' field 1 time(s)
	Then I should see 'Short password info' information under 'Password' field