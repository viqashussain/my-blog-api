Feature: GettingTags
	As a public user	
	I can retrieve a list of all the available tags

Background: 
	Given I have the following article tags stored 
		| Name       |
		| JavaScript |
		| CSharp     |
		| React      |
		| Angular    |

Scenario: I can retrieve a tag
	When I retrieve the tag 'Angular'
	Then the following tag should be returned
		| Name    |
		| Angular |