Feature: Login button activation

Login button should be inactive, when fields are not filled or filled unproperly.

  Scenario: Unactive Log in button on empty fields 
    Given I am on login page
    When the field email is empty
    And the field password is empty
    Then Log in button should be unactivve

  Scenario: Unactive Log in button when unproperly filled fields 
    Given I am on login page
    When I type 'TestEmail' in Email Field
    And the field password is empty
    Then Log in button should be unactivve
