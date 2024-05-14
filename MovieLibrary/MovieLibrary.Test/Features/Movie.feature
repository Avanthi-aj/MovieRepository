Feature: Movie Management in Movie Library

Scenario Outline: Create Movie with invalid data
Given I am a client
When I make a post request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint | Data                                                                                                                 | Response Code | Response Data |
| /movies  | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[1]} | 201           | {"id":1}      |

@invalidData
Examples:
| Endpoint | Data                                                                                                                 | Response Code | Response Data                            |
| /movies  | {"name":"","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[1]}      | 400           | Movie Name cannot be null or empty       |
| /movies  | {"name":"movie","yearofrelease":3000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[1]} | 400           | Year of release must be a valid year     |
| /movies  | {"name":"movie","yearofrelease":2000,"plot":"","coverimage":"image","actors":[1],"producer":1,"genres":[1]}          | 400           | Movie plot cannot be null or empty       |
| /movies  | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"","actors":[1],"producer":1,"genres":[1]}      | 400           | Movie CoverImage cannot be null or empty |
| /movies  | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[6],"producer":1,"genres":[1]} | 400           | Actor with Id 6 does not exists          |
| /movies  | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":8,"genres":[1]} | 400           | Producer with Id 8 does not exists       |
| /movies  | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[9]} | 400           | Genre with ID 9 does not exists          |

Scenario Outline: Update movie
Given I am a client
When I make a put request to '<Endpoint>' with the following data '<Data>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint  | Data                                                                                                                 | Response Code | Response Data              |
| /movies/1 | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[1]} | 200           | Movie Updated Successfully |

@invalidData
Examples:
| Endpoint  | Data                                                                                                                 | Response Code | Response Data                            |
| /movies/5 | {"name":"","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[1]}      | 400           | Movie with ID 5 does not exist           |
| /movies/1 | {"name":"","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[1]}      | 400           | Movie Name cannot be null or empty       |
| /movies/1 | {"name":"movie","yearofrelease":3000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[1]} | 400           | Year of release must be a valid year     |
| /movies/1 | {"name":"movie","yearofrelease":2000,"plot":"","coverimage":"image","actors":[1],"producer":1,"genres":[1]}          | 400           | Movie plot cannot be null or empty       |
| /movies/1 | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"","actors":[1],"producer":1,"genres":[1]}      | 400           | Movie CoverImage cannot be null or empty |
| /movies/1 | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[6],"producer":1,"genres":[1]} | 400           | Actor with Id 6 does not exists          |
| /movies/1 | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":8,"genres":[1]} | 400           | Producer with Id 8 does not exists       |
| /movies/1 | {"name":"movie","yearofrelease":2000,"plot":"plot here","coverimage":"image","actors":[1],"producer":1,"genres":[9]} | 400           | Genre with ID 9 does not exists          |


Scenario: Get all Movies
Given I am a client
When I make a get request to '/movies'
Then the response code is '200'
And response data should be '[{"id":1,"name":"movie","yearOfRelease":2000,"plot":"plot here","producer":{"id":1,"name":"producer","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"},"actors":[{"id":1,"name":"actor","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"}],"genres":[{"id":1,"name":"genre"}],"coverImage":"image"}]'

	
Scenario: Get Movie By Id
Given I am a client
When I make a get request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint | Response Code | Response Data                                                                                                                                                                                                                                                                                                    |
| movies/1 | 200           | {"id":1,"name":"movie","yearOfRelease":2000,"plot":"plot here","producer":{"id":1,"name":"producer","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"},"actors":[{"id":1,"name":"actor","bio":"bio","dob":"2003-03-03T00:00:00","gender":"Male"}],"genres":[{"id":1,"name":"genre"}],"coverImage":"image"} |

@invalidData
Examples:
| Endpoint | Response Code | Response Data                  |
| movies/5 | 404           | Movie with ID 5 does not exist |


Scenario Outline: Delete Movie
Given I am a client
When I make a delete request to '<Endpoint>'
Then the response code is '<Response Code>'
And response data should be '<Response Data>'

@validData
Examples:
| Endpoint  | Response Code | Response Data              |
| /movies/1 | 200           | Movie Deleted Successfully |

@invalidData
Examples:
| Endpoint  | Response Code | Response Data                                                |
| /movies/5 | 400           | Trying to delete the movie with ID 5 which is not present |


