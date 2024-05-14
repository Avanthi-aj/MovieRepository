Feature:Actor Management in Movie Library

Scenario Outline: Create new Actor
Given I am a client
When I make a post request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples: 
| Endpoint | Data                                                             | Response Code |  Response Data  |
| /actors  | {"Name":"actor","Bio":"bio","DOB": "2003-03-03","Gender":"Male"} |   201         | {"id":1}        |

@invalidData
Examples: 
| Endpoint | Data                                                                   | Response Code | Response Data                      |
| /actors  | {"Name" : "","Bio":"Bio here","DOB":"2002-11-19","Gender":"Male"}      | 400           | Actor Name cannot be null or empty.|
| /actors  | {"Name" : "actor","Bio":"","DOB":"2002-11-19","Gender":"Male"}         | 400           | Actor Bio cannot be null or empty. |
| /actors  | {"Name" : "actor","Bio":"Bio here","DOB":"2042-11-12","Gender":"Male"} | 400           | DOB cannot be in the future.       |
| /actors  | {"Name" : "actor","Bio":"Bio here","DOB":"2002-11-19","Gender":"M"}    | 400           | Invalid gender value.              |



Scenario Outline: Update actor
Given I am a client
When I make a put request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint  | Data                                                                | Response Code | Response Data                |
| /actors/1 | {"name": "actor","bio": "bio","dob": "2003-03-03","gender": "Male"} | 200           |  Actor Updated Successfully  |

@invalidData
Examples: 
| Endpoint   | Data                                                                   | Response Code | Response Data                      |
| /actors/5  | {"Name" : "actor","Bio":"Bio here","DOB":"2002-11-19","Gender":"Male"} | 400           | Actor with Id 5 does not exists    |
| /actors/1  | {"Name" : "","Bio":"Bio here","DOB":"2002-11-19","Gender":"Male"}      | 400           | Actor Name cannot be null or empty.|
| /actors/1  | {"Name" : "actor","Bio":"","DOB":"2002-11-19","Gender":"Male"}         | 400           | Actor Bio cannot be null or empty. |
| /actors/1  | {"Name" : "actor","Bio":"Bio here","DOB":"2042-11-12","Gender":"Male"} | 400           | DOB cannot be in the future.       |
| /actors/1  | {"Name" : "actor","Bio":"Bio here","DOB":"2002-11-19","Gender":"M"}    | 400           | Invalid gender value.              |

Scenario: Get all Actors
Given I am a client
When I make a get request to '/actors'
Then the response code is '200'
And response data should be '[{"id":1,"name":"actor","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"}]'

Scenario Outline: Get Actor By Id
Given I am a client
When I make a get request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint | Response Code | Response Data                                                                    |
| actors/1  | 200           | {"id":1,"name":"actor","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"} |

@invalidData
Examples:
| Endpoint | Response Code | Response Data                                                                   |
| actors/5  | 404          | Actor with Id 5 does not exists                                                 |


Scenario Outline: Delete actor
Given I am a client
When I make a delete request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint  | Response Code | Response Data              |
| /actors/1 | 200           | Actor Deleted Successfully |

@invalidData
Examples:
| Endpoint  | Response Code | Response Data                                             |
| /actors/5 | 400           | Trying to delete the actor with ID 5 which is not present |