Feature: Login button activation

Login button should be inactive, when fields are not filled or filled unproperly.

  Scenario: Unactive Log in button on empty fields 
    Given I am on the login page
    When the field email is empty
    And the field password is empty
    Then Log in button should be in disabled state

  Scenario Outline: Log in button state according to Email syntax
    Given I am on the login page
    When I type '<email>' in Email Field
    And I type '<password>' in Passowrd Field
    Then Log in button should be in <state> state


    Examples: 
    | email              | password    | state    |
    | IncorrectEmail     | AnyPassword | disabled |
    | GoodEmail@test.com | AnyPassword | active   |

