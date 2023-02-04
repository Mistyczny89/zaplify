Feature: Logging on site

Check if log in works only with proper credencials.
If crecensials are wrong there should be dedicated information.

  Scenario: Wrong password
    Given I am on the login page
    When I type 'GoodEmail@test.com' in Email Field
    And I type 'WrongPassword' in Passowrd Field
    And I click on Log in button
    Then I should see 'Email or password incorrect' information
	And Log in button should be in disabled state

 Scenario: Log on site
    Given I am on the login page
    When I log on the site
    Then I see welcoming info

Scenario: Email and Password field after incorrect log in
    Given I am on the login page
    When I type 'GoodEmail@test.com' in Email Field
    And I type 'WrongPassword' in Passowrd Field
    And I click on Log in button
    Then 'Email' field should stay filled
    And  'Password' field should stay filled

 Scenario: Too many invalid requests
    Given I am on the login page
    When I type 'jacek.s+pawelm@zaplify.com' in Email Field
    And I type wrong password 5 times
    Then I should see 'Too many invalid requests, please try again later'
    
