# LightFeather With RazorPages

---

## Overview

The application consists of an API layer, a UI layer, an Infrastructure Layer, a Database, and a Domain Layer.

The application is also dockerized.

---

# Technologies Used
- .Net Core 8
- Docker
- Razor Pages
- Web API
- Class Library
- Git
- SQL Server
- Entity Framework Core

---

## Prerequisites

- [Git](https://git-scm.com/downloads)
- [Docker](https://www.docker.com/products/docker-desktop/)

---

## Run the application

To run the application, you need docker installed on your machine, and Git to clone the repository.

1. Clone the repository
```bash
git clone https://github.com/johnMedlockDev/LightFeather.RazorPages.git
```

2. Change the directory to the repository
```bash
cd LightFeather.RazorPages
```

3. Run the application
```bash
docker-compose up -d
```

4. Open your browser and navigate to `http://localhost:8080/swagger/index.html`

Here you will see the swagger documentation for the application Api Layer.

5. To view the UI, navigate to `localhost`

Test the form by inputting values for the various fields.

---

## Expected Behavior

You will see a success message if the form is submitted successfully.

You will see error messages if the form is not submitted successfully in the UI and the logs.

---

## How I would improve the application

- <del>I would add a database to store the form data.</del>
- I would test the application using xUnit and Postman.
- I would spend more time on the UI to make it better. IE: loading animations, fonts, colors, shading, etc.

---

### Database Access

- username: sa
- password: yourStrong(!)Password
- host: localhost

---

### Troubleshooting

- If you get no response immediately after it starts it's probably because it's applying the migrations. I just waited a few seconds and it worked fine for me.
- When you see something similar to this in your API logs. Then you're good to go.
![image](https://github.com/johnMedlockDev/LightFeather.RazorPages/assets/42301475/861e9e64-97d4-48fe-8cdf-5fd3c5dfae2f)

---

### Screenshots

#### Swagger
![image](https://github.com/johnMedlockDev/LightFeather.RazorPages/assets/42301475/6b8439e6-37bc-4717-8a41-2b3f0848155a)

#### UI
![image](https://github.com/johnMedlockDev/LightFeather.RazorPages/assets/42301475/ff2a279d-6e6f-4ae2-8be8-f5b0f1cc2cf8)

#### UI Validation
![image](https://github.com/johnMedlockDev/LightFeather.RazorPages/assets/42301475/2af19062-b588-458d-9d60-9838c8342858)

#### UI Validation Success
![image](https://github.com/johnMedlockDev/LightFeather.RazorPages/assets/42301475/b6e540b1-44ea-4da2-9751-63a642d838a8)

#### DB Persistence
![image](https://github.com/johnMedlockDev/LightFeather.RazorPages/assets/42301475/bc7bfb85-36ec-4900-be63-e87ce64a408c)
