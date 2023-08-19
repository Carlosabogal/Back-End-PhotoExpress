# Back-End-PhotoExpress
PhotoExpress Back-End API README
This README provides an overview of the PhotoExpress Back-End API project, which is developed using C# with .NET. The API is designed to manage event registrations and utilize a database to store event information. It includes functionality to create event registrations and retrieve existing registrations.
- Table of Contents
    - Prerequisites  
    - Database Setup
    - Getting Started
    - API Endpoints
## Prerequisites
Before running the PhotoExpress Back-End API, make sure you have the following software installed:

- .NET SDK
- MySqlWorchbend
A compatible code editor (e.g., Visual Studio, Visual Studio Code)
## Database Setup
The API uses a database to store event registration information. The provided SQL script creates a table named Events with the required columns. Here's the script:
 ``` create database register  ```
After create table :
 ```
sql
Copy code
create table Events(
    Id INT NOT NULL AUTO_INCREMENT,
    InstitucionSuperior VARCHAR(255),
    DireccionInstitucion VARCHAR(255),
    NumeroAlumnos INT,
    HoraInicio DATE,
    ValorServicio DECIMAL,
    PRIMARY KEY (ID)
  ```
## Getting Started
Clone the repository to your local machine.
Open the project in your preferred code editor.
Update the database connection string in the appsettings.json file to match your database configuration.
## API Endpoints
The PhotoExpress Back-End API includes the following endpoints:
 ```
Create Event Registration
Endpoint: POST http://localhost:5242/api/register/create
Request JSON:
json
Copy code
{
  "InstitucionSuperior": "Nombre de la institución",
  "DireccionInstitucion": "Dirección de la institución",
  "NumeroAlumnos": 100,
  "HoraInicio": "2023-08-16T09:00:00",
  "ServicioTogaBirete": false
 ```
Response: 200 OK (Success) or 400 Bad Request (Error)
Get Event Registrations
 ```
Endpoint: GET http://localhost:5242/api/register/get
Response: List of event registrations in JSON format or 400 Bad Request (Error)
Example Usage
Run the API project locally.
Use a tool like Postman or curl to send requests to the API endpoints as described above
 ```
