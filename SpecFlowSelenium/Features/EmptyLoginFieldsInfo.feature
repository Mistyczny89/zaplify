Feature: Empty fields

When you leave Email and Password fields empty anter you have interaction with them eg. click on them
You should see information reminding that there is field fill required 

  Scenario: Leaving empty fields
    Given I am on the login page
    When I click of Email field 
	And I click of Password field
	And I click of Email field 
	Then I should see 'Required' information under Email field
	And I should see 'You must type in a password' information under Password field

