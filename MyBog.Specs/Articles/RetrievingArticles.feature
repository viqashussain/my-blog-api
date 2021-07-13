Feature: RetrievingArticles
	As a public user	
	I can retrieve a list of all the articles

Background: 
	Given I have the following article categories stored
		| Name       |
		| Clean Code |
		| Frameworks |
	And I have the following article tags stored 
		| Name       |
		| JavaScript |
		| CSharp     |
		| React      |
		| Angular    |
	Given I have the following articles stored
		| Title                            | CreationDate | Html                               | PublishDate | CategoryName | ArticleImageFileName | PreviewImageFileName | PreviewText   | ThumbnailImageFileName |
		| Why Angular is better than React | 2018-01-01   | <b>Google!</b>                     | 2019-01-01  | Frameworks   | xx1                  | x1                   | Angular is... | y1                     |
		| Everything about Uncle Bob       | 2019-02-02   | <u>Let's start with the stars!</u> | 2019-01-02  | Clean Code   | xx2                  | x2                   | Uncle bob...  | y2                     |
		| Lifecyle hooks                   | 2018-01-01   | <b>ngOnInit</b>                    | 2019-01-01  | Frameworks   | xx3                  | x3                   | Life...       | y3                     |
	And the article 'Lifecyle hooks' have the following tags 
		| Name    |
		| Angular |
	And the article 'Why Angular is better than React' have the following tags 
		| Name    |
		| Angular |
		| React   |
	And the article 'Everything about Uncle Bob' have the following tags 
		| Name       |
		| CSharp     |
		| JavaScript |

Scenario: I can retrieve all preview articles
	When I retrieve a list of all the article previews
	Then the following article previews should be returned
		| Title                            | CreationDate | PreviewText   | PublishDate | CategoryName | Tags              | PreviewImageFileName | ThumbnailImageFileName |
		| Why Angular is better than React | 2018-01-01   | Angular is... | 2019-01-01  | Frameworks   | Angular,React     | x1                   | y1                     |
		| Everything about Uncle Bob       | 2019-02-02   | Uncle bob...  | 2019-01-02  | Clean Code   | CSharp,JavaScript | x2                   | y2                     |
		| Lifecyle hooks                   | 2018-01-01   | Life...       | 2019-01-01  | Frameworks   | Angular           | x3                   | y3                     |

Scenario: I can retrieve an article
	When I retrieve the article with title 'Why Angular is better than React'
	Then the following article should be returned
		| Title                            | CreationDate | Html           | PublishDate | CategoryName | Tags          | ArticleImageFileName | ThumbnailImageFileName |
		| Why Angular is better than React | 2018-01-01   | <b>Google!</b> | 2019-01-01  | Frameworks   | Angular,React | xx1                  | y1                     |

Scenario: I can retrieve articles by hashtag
	When I retrieve the articles with hashtag 'Angular'
	Then the following article previews should be returned
		| Title                            | CreationDate | PreviewText   | PublishDate | CategoryName | Tags          | PreviewImageFileName | ThumbnailImageFileName |
		| Why Angular is better than React | 2018-01-01   | Angular is... | 2019-01-01  | Frameworks   | Angular,React | x1                   | y1                     |
		| Lifecyle hooks                   | 2018-01-01   | Life...       | 2019-01-01  | Frameworks   | Angular       | x3                   | y3                     |
																														   
Scenario: I can retrieve articles by category
	When I retrieve the articles by category 'Frameworks'
	Then the following article previews should be returned
		| Title                            | CreationDate | PreviewText   | PublishDate | CategoryName | Tags          | PreviewImageFileName | ThumbnailImageFileName |
		| Why Angular is better than React | 2018-01-01   | Angular is... | 2019-01-01  | Frameworks   | Angular,React | x1                   | y1                     |
		| Lifecyle hooks                   | 2018-01-01   | Life...       | 2019-01-01  | Frameworks   | Angular       | x3                   | y3                     |

Scenario: Articles previews are retrieved with pages numbers ordered by publish date
	Given I have the following articles stored
		| Title            | PublishDate | CategoryName |
		| Article page 2_1 | 2018-03-03  | Frameworks   |
		| Article page 2_2 | 2018-03-02  | Frameworks   |
		| Article page 2_3 | 2018-03-01  | Frameworks   |
		| Article page 1_1 | 2018-04-03  | Frameworks   |
		| Article page 1_2 | 2018-04-02  | Frameworks   |
		| Article page 1_3 | 2018-04-01  | Frameworks   |
		| Article page 3_1 | 2018-02-03  | Frameworks   |
		| Article page 3_2 | 2018-02-02  | Frameworks   |
		| Article page 3_3 | 2018-02-01  | Frameworks   |
		| Article page 4_1 | 2018-02-01  | Frameworks   |
	When I retrieve a list of all the article previews
	Then the following article previews should be returned with page numbers
		| Title            | PageNumber |
		| Article page 2_1 | 2          |
		| Article page 2_2 | 2          |
		| Article page 2_3 | 2          |
		| Article page 1_1 | 1          |
		| Article page 1_2 | 1          |
		| Article page 1_3 | 1          |
		| Article page 3_1 | 3          |
		| Article page 3_2 | 3          |
		| Article page 3_3 | 3          |
		| Article page 4_1 | 4          |
	