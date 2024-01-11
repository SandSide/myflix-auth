# Myflix Auth

## Description

A microservice apart of `Myflix` project which servers as a  Authentication service.
The service is built using ASP.NET Core, ASP.NET Identity, Entity Framework, MSSql Server and Docker.

## Features

- **Login**: Handle login requests.
- **Registration**: Handles new user registration.
- **Authentication**: Verifies user and provides **Json Web Token**.

## Deployment

### Using Docker:
1. Build the Docker image from `Dockerfile` in `/src` folder.

```bash
docker build -t {image-name} .
```

2. Run the docker image.

```bash
docker run -p 5000:5000 --name {container-name} {image-name}
```

## Usage

### Login

#### Request

`POST` `/api/auth/login`

```json
{
    "Username": "your_username",
    "Password": "your_password"
}
```

#### Response

```json
"Json Web Token"
```


### Registration

#### Request

`POST` `/api/auth/register`

```json
{
    "Username": "new_username",
    "Password": "new_password"
}
```

#### Response

```
Outcome Message
```