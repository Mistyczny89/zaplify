Feature: Login button activation

Login button should be inactive, when fields are not filled or filled unproperly.

  Scenario: Unactive Log in button on empty fields 
    Given I am on the login page
    When the field email is empty
    And the field password is empty
    Then Log in button should be in disabled state

  Scenario: Log in button state - bad Email syntax
    Given I am on the login page
    When I type 'Bad Syntax Email' in Email Field
    And I type 'Registed User Pwd' in Passowrd Field
    Then Log in button should be in disabled state

 Scenario: Log in button state - good Email syntax
    Given I am on the login page
    When I type 'Good Syntax Email' in Email Field
    And I type 'Registed User Pwd' in Passowrd Field
    Then Log in button should be in active state