# LightFeather Code Challenge

## Overview

The application consists of an Api layer, a Ui layer, and a Class Library.
The application is dockerized.

# Technologies Used
- .Net Core 8
- Docker
- Razor Pages
- Web API
- Class Library
- Git

## Run the application

To run the application, you need docker installed on your machine, and Git to clone the repository.

1. Clone the repository
```bash
git clone https://github.com/johnMedlockDev/LightFeather.CodeChallenge.git
```

2. Change the directory to the repository
```bash
cd LightFeather.CodeChallenge
```

3. Run the application
```bash
docker-compose up -d
```

4. Open your browser and navigate to `http://localhost:8080/swagger/index.html`

Here you will see the swagger documentation for the application Api Layer.

5. To view the UI, navigate to `localhost`

Test the form by inputting values for the various fields.

## Expected Behavior
You will see a success message if the form is submitted successfully.

You will see error messages if the form is not submitted successfully in the UI and the logs.

## How I would improve the application
- I would add a database to store the form data.
- I would test the application using xUnit and Postman.
- I would spend more time on the UI to make it better. IE: loading animations, fonts, colors, shading, etc.

### Screenshots

#### Swagger
![Swagger](https://github.com/johnMedlockDev/LightFeather.CodeChallenge/assets/42301475/c7e09d1c-c298-4658-ac75-d5792cf936ba)

#### UI
![UI](https://github.com/johnMedlockDev/LightFeather.CodeChallenge/assets/42301475/dcb6ee12-5e30-4f70-9c93-c05448047c82)

#### UI Validation
![UI Validation](https://github.com/johnMedlockDev/LightFeather.CodeChallenge/assets/42301475/fbfc2e84-1633-4fc4-9ebe-87c167210656)

#### UI Validation Fixed
![UI Validation Fixed](https://github.com/johnMedlockDev/LightFeather.CodeChallenge/assets/42301475/b38706b6-f43a-4a8c-b736-1d0977c5532d)

#### UI Validation Success
![UI Validation Success](https://github.com/johnMedlockDev/LightFeather.CodeChallenge/assets/42301475/e9f43afc-1855-4d22-a457-8a964a1fafd3)
