Feature: RetrievingAboutMeContent

Scenario: I can retrieve about me content
	Given I have the following about me data stored
		| HtmlContent             |
		| <b>My name is Viqas</b> |
	When I retrieve about me content
	Then the following about me content should be returned
		| HtmlContent             |
		| <b>My name is Viqas</b> |
