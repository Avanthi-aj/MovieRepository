Feature:Genre Management in Movie Library

Scenario Outline: Create new Actor
Given I am a client
When I make a post request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint | Data             | Response Code | Response Data |
| /genres  | {"Name":"genre"} | 201           | {"id":1}      |

@invalidData
Examples:
| Endpoint | Data             | Response Code | Response Data                          |
| /genres  | {"Name":""}      | 400           | Genre Name cannot be Null or Empty     |
 


Scenario Outline: Update Gnere
Given I am a client
When I make a put request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint  | Data               | Response Code | Response Data              |
| /genres/1 | {"name": "comedy"} | 200           | Genre Updated Successfully |

@invalidData
Examples:
| Endpoint  | Data               | Response Code | Response Data                      |
| /genres/1 | {"name": ""}       | 400           | Genre Name cannot be Null or Empty |
| /genres/5 | {"name" : "genre"} | 400           | Genre with ID 5 does not exists    |


Scenario: Get all Genres
Given I am a client
When I make a get request to '/genres'
Then the response code is '200'
And response data should be '[{"id":1,"name":"genre"}]'

Scenario: Get Genre By Id
Given I am a client
When I make a get request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint | Response Code | Response Data           |
| genres/1 | 200           | {"id":1,"name":"genre"} |

@invalidData
Examples:
| Endpoint | Response Code | Response Data                   |
| genres/5 | 404           | Genre with ID 5 does not exists |


Scenario Outline: Delete genre
Given I am a client
When I make a delete request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint  | Response Code | Response Data              |
| /genres/1 | 200           | Genre Deleted Successfully |

@invalidData
Examples:
| Endpoint  | Response Code | Response Data                                             |
| /genres/5 | 400           | Trying to delete the genre with ID 5 which is not present |