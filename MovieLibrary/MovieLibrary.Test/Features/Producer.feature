Feature:Producer Management in Movie Library

Scenario Outline:Create new Producer
Given I am a client
When I make a post request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@valiData
Examples: 
| Endpoint   | Data                                                                    | Response Code | Response Data |
| /producers | {"Name":"producer","Bio":"bio","DOB": "2003-03-03","Gender":"Male"}     |      201      |     {"id":1}  |

@invaliData
Examples: 
| Endpoint   | Data                                                                      | Response Code | Response Data                            |
| /producers | {"Name" : "","Bio":"Bio here","DOB":"2002-11-19","Gender":"Male"}         | 400           |  Producer Name cannot be null or empty.  |
| /producers | {"Name" : "producer","Bio":"","DOB":"2002-11-19","Gender":"Male"}         | 400           |  Producer Bio cannot be null or empty.   |
| /producers | {"Name" : "producer","Bio":"Bio here","DOB":"2024-12-12","Gender":"Male"} | 400           |  DOB cannot be in the future.            |
| /producers | {"Name" : "producer","Bio":"Bio here","DOB":"2002-11-19","Gender":"M"}    | 400           |  Invalid gender value.                   |

Scenario Outline: Update Producer
Given I am a client
When I make a put request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'

@valiData
Examples: 
| Endpoint     | Data                                                                    | Response Code | Response Data                  |
| /producers/1 | {"Name":"producer","Bio":"bio","DOB": "2003-03-03","Gender":"Male"}     |      200      | Producer Updated Successfully  |

@invaliData
Examples: 
| Endpoint     | Data                                                                      | Response Code | Response Data                            |
| /producers/5 | {"Name" : "producer","Bio":"Bio here","DOB":"2002-11-19","Gender":"Male"} | 400           |  Producer with Id 5 does not exists      |
| /producers/1 | {"Name" : "","Bio":"Bio here","DOB":"2002-11-19","Gender":"Male"}         | 400           |  Producer Name cannot be null or empty.  |
| /producers/1 | {"Name" : "producer","Bio":"","DOB":"2002-11-19","Gender":"Male"}         | 400           |  Producer Bio cannot be null or empty.   |
| /producers/1 | {"Name" : "producer","Bio":"Bio here","DOB":"2024-12-12","Gender":"Male"} | 400           |  DOB cannot be in the future.            |
| /producers/1 | {"Name" : "producer","Bio":"Bio here","DOB":"2002-11-19","Gender":"M"}    | 400           |  Invalid gender value.                   |


Scenario: Get all Producers
Given I am a client
When I make a get request to '/producers'
Then the response code is '200'
And response data should be '[{"id":1,"name":"producer","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"}]'


Scenario: Get Producer By Id
Given I am a client
When I make a get request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint      | Response Code | Response Data                                                                      |
| /producers/1  |    200        | {"id":1,"name":"producer","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"} |

@invalidData
Examples:
| Endpoint      | Response Code | Response Data                         |
| /producers/5  |    404        | Producer with Id 5 does not exists    |



Scenario Outline: Delete Producer
Given I am a client
When I make a delete request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint     | Response Code | Response Data                 |
| /producers/1 | 200           | Producer Deleted Successfully |

@invalidData
Examples:
| Endpoint     | Response Code | Response Data                                             |
| /producers/5 | 400           | Trying to delete the producer with ID 5 which is not present |
