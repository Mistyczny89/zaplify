Feature: Login page should have all neccessary elements

I want to see properly login page on Zaplify

Scenario: Visit login pahe and check existing of elements
	Given I am on the login page
	Then zaplify logo shoud be visible
	And 'Welcome back' information should be visible
	And 'Efficient day' information should be visible
	And 'Email' field should be visible
	And 'Password' field should be visible
	And 'LogIn' field should be visible
	And Password toggle button should be visible

Scenario: Placeholders in login fields
	Given I am on the login page
	Then Email placeholder should be visible
	And Password placeholder should be visible

Scenario: Click of zaplify logo
	Given I am on the login page
	When I click on zaplify logo
	Then I should be on page 'Zaplify Main Page'