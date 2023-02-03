Feature: Login button activation

Login button should be inactive, when fields are not filled or filled unproperly.

  Scenario: Unactive Log in button on empty fields 
    Given I am on the login page
    When the field email is empty
    And the field password is empty
    Then Log in button should be unactivve

  Scenario: Unactive Log in button when Email field filled with incorrect syntax
    Given I am on the login page
    When I type 'TestEmail' in Email Field
    And I type 'TestPassword' in Passowrd Field
    Then Log in button should be disabled

 Scenario: Active Log in button when Email field filled with correct syntax
    Given I am on the login page
    When I type 'TestEmail@test.com' in Email Field
    And I type 'TestPassword' in Passowrd Field
    Then Log in button should be active
