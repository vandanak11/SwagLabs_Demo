@Login Feature
Feature: Login
	In order to view SwagLabs Features
	I want to be logged into the site
	With Authorized credentials

@SmokeTest
Scenario: Login to SwagLabs Application
	Given I am in Login Page of SwagLabs Application
	And I have entered valid User name and Password
	When I click on Login Button
	Then I should be navigated to the home page
