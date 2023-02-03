Feature: Logging on site

Check if log in works only with proper credencials.
If crecensials are wrong there should be dedicated information.

  Scenario: Wrong password
    Given I am on the login page
    When I type 'GoodEmail@test.com' in Email Field
    And I type 'WrongPassword' in Passowrd Field
    And I click on Log in button
    Then I should see Email or password incorrect
	And Log in button should be in disabled state


 Scenario: Log on site
    Given I am on the login page
    When I log on the site
    Then I see welcoming info