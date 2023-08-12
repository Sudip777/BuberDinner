# Buber Dinner API

Table of Contents
- [Buber Dinner API ](#buber-dinner-api)
	-[Auth](#auth)
		-[Register](#register)
			-[Register Request](#register-request)
			-[Register Response](#register-response)
		-[Login](#login)
			-[Login Request](#login-request)
			-[Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
	"firstName": "Sudip",
	"lastName": "Parajuli",
	"email": "sudipparajuli06@gmail.com",
	"password": "Sudip1234"

}
```

#### Register Response

```js
200 OK
```

```json
{
 "id": "asadhsjhdjs90292922",
 "firstName": "Sudip",
 "lastName": "Parajuli",
 "email": "sudipparajuli06@gmail.com",
 "token": "ehandnsdsd3343",
}
``` 

### Login
```json
{
 
 "email": "sudipparajuli06@gmail.com",
 "password": "Sudip1234"
}
``` 


### Login Response

```json
{
"id" : "asadhsjhdjs90292922",
"firstName" : "Sudip",
"lastName" : "Parajuli",
"email" : "sudipparajuli06@gmail.com",
"token" : "ehandnsdsd3343"

}
```
