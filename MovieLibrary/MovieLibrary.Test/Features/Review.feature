Feature:Review Management in Movie Library

Scenario: Create new Review
Given I am a client
When I make a post request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint         | Data                  | Response Code | Response Data |
| movies/1/reviews | {"Message":"message"} | 201           | {"id":1}      |

@invalidData
Examples:
| Endpoint         | Data                  | Response Code | Response Data                  |
| movies/1/reviews | {"Message":""}        | 400           | Message cannot be empty        |
| movies/5/reviews | {"Message":"message"} | 400           | Movie with ID 5 does not exist |




Scenario Outline: Update review
Given I am a client
When I make a put request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint           | Data                  | Response Code | Response Data               |
| movies/1/reviews/1 | {"Message":"message"} | 200           | Review Updated Successfully |

@invalidData
Examples:
| Endpoint           | Data                  | Response Code | Response Data                   |
| movies/5/reviews/1 | {"Message":"message"} | 400           | Movie with ID 5 does not exist  |
| movies/1/reviews/1 | {"Message":""}        | 400           | Message cannot be empty         |
| movies/1/reviews/5 | {"Message":"message"} | 400           | Review with ID 5 does not exist |
 

Scenario: Get all reviews
Given I am a client
When I make a get request to 'movies/1/reviews'
Then the response code is '200'
And response data should be '[{"id":1,"message":"message","movieId":1}]'


Scenario Outline: Get review By Id
Given I am a client
When I make a get request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint           | Response Code | Response Data                            |
| movies/1/reviews/1 | 200           | {"id":1,"message":"message","movieId":1} |

@validData
Examples:
| Endpoint           | Response Code | Response Data                            |
| movies/1/reviews/5 | 404           | Review with ID 5 does not exist		    |
| movies/5/reviews/1 | 404           | Movie with ID 5 does not exist		    |

	
Scenario Outline: Delete review
Given I am a client
When I make a delete request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint           | Response Code | Response Data               |
| movies/1/reviews/1 | 200           | Review Deleted Successfully |

@invalidData
Examples:
| Endpoint           | Response Code | Response Data                      |
| movies/1/reviews/5 | 400           | Review with ID 5 does not exist    |
| movies/5/reviews/1 | 400           | Movie with ID 5 does not exist     |

