Feature: Google Search

A short summary of the feature

@SearchEpic
Scenario: Search text on google
	Given I am on the google search page
	When I search for term '<term>'
	Then Then I should see results for search '<term>'

	Examples: 
	| term  |
	| music |
	| video |
