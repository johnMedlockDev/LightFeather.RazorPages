# LightFeather Code Challenge

## Overview

The application consist of a Api layer, Ui layer, and a Class Library.
The application is dockerized.

# Technologies Used
- .Net Core 8
- Docker
- Razor Pages
- Web Api
- Class Library
- Git

## Run the application

To run the application, you need to have docker installed on your machine, and Git to clone the repository.

1. Clone the repository
```bash
git clone https://github.com/johnMedlockDev/LightFeather.CodeChallenge.git
```

2. Change directory to the repository
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

Test the form by inputing values for the various fields.

## Expected Behavior
You will see a success message if the form is submitted successfully.

You will see error messages if the form is not submitted successfully both in the ui and the logs.

## How I would improve the application
- I would add a database to store the form data.
- I would test the application using a xUnit and Postman.
- I would spend more time on the UI to make it better. IE: loading animations, fonts, colors, shading, etc.