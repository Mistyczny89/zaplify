Feature: Helper texts

When you have any inteaction with fields eg click or fill 
you should see proper helper text. 

  Scenario: Helper after leaving empty fields
    Given I am on the login page
    When I click of Email field 
	And I click of Password field
	And I click of Email field 
	Then I should see 'Required' information under Email field
	And I should see 'You must type in a password' information under Password field

 Scenario: Helper when password is to short
    Given I am on the login page
    When I type 'GoodEmail@test.com' in Email Field
	And I click of Password field
	And I click of Email field 
	And I type '12345' in Passowrd Field
	Then I should see 'Your password must contain at least 6 characters' information under Password field

 Scenario: Helper when email have bad syntax
    Given I am on the login page
    When I type 'IncorrectEmail' in Email Field
	And I click of Password field
	Then I should see 'Invalid email address' information under Email field

 Scenario: No any helper when email have good syntax
    Given I am on the login page
    When I type 'GoodEmail@test.com' in Email Field
	And I click of Password field
	Then Information under Email field should not exist

 Scenario: Helper when email have good syntax and its backpaced
    Given I am on the login page
    When I type 'GoodEmail@test.com' in Email Field
	And I send backspace in Email field 2 time(s)
	And I click of Password field
	Then I should see 'Invalid email address' information under Email field

 Scenario: Helper when password is to short after backspace
    Given I am on the login page
    When I type 'GoodEmail@test.com' in Email Field
	And I click of Password field
	And I click of Email field 
	And I type '123456' in Passowrd Field
	And I send backspace in Password field 1 time(s)
	Then I should see 'Your password must contain at least 6 characters' information under Password field



