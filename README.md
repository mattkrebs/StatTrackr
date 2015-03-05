# StatTrackr

##Authentication

#### - Get Auth Token

*Sample Request*

```
POST /Token HTTP/1.1
Host: stattrackerwebapi.azurewebsites.net
Content-Type: application/json
Cache-Control: no-cache
Content-Type: application/x-www-form-urlencoded

grant_type=password&username=sample@domain.com&password=mypassword
```

*Sample Response*

```
{
    "access_token": "bearer_token_ABCDEFG12345",
    "token_type": "bearer",
    "expires_in": 1209599,
    "userName": "sample@domain.com",
    ".issued": "Thu, 05 Mar 2015 21:08:55 GMT",
    ".expires": "Thu, 19 Mar 2015 21:08:55 GMT"
}
````

#### - Make Authenicated Requests

*Sample Request*

```
GET /api/Game HTTP/1.1
Host: stattrackerwebapi.azurewebsites.net
Content-Type: application/json
Authorization: Bearer bearer_token_ABCDEFG12345g
Cache-Control: no-cache
Content-Type: application/x-www-form-urlencoded
```
