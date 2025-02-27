Task Management API
Overview
The Task Management API is a web application that allows users to manage tasks. It includes features such as creating, reading, updating, and deleting tasks. This project uses ASP.NET Core for the backend and Angular for the frontend.

The backend communicates with a SQL Server database using Entity Framework Core. The frontend consumes the API to display and manipulate task data.

Technologies Used
Backend
ASP.NET Core 5.0 (or higher)
Entity Framework Core for database management
Swagger for API documentation
SQL Server (using LocalDB for development)
Frontend
Angular (latest version)
HttpClientModule to interact with the API
Bootstrap (optional) for styling
Features
CRUD Operations for tasks:
Create a task
Read all tasks or a specific task
Update a task
Delete a task
Swagger UI for easy API testing in development
Setup
Prerequisites
Before running the project, ensure that you have the following installed:

.NET SDK (5.0 or later)
Node.js and npm (for Angular frontend)
SQL Server (LocalDB should be fine for local development)
Backend Setup (ASP.NET Core)
Clone the repository to your local machine:

bash
Copy
git clone <repository-url>
cd TaskManagementApi
Restore the required NuGet packages:

bash
Copy
dotnet restore
Update your appsettings.json with the correct connection string to the database. For example:

json
Copy
"ConnectionStrings": {
  "TaskDb": "Server=(localdb)\\mssqllocaldb;Database=TaskManagementDb;Trusted_Connection=True;"
}
Create the database by running the following command to apply migrations:

bash
Copy
dotnet ef database update
Start the API backend:

bash
Copy
dotnet run
This will launch the API, and you should see something like:

nginx
Copy
Now listening on: https://localhost:5001
Open the Swagger UI to test the API endpoints in your browser by navigating to:

bash
Copy
https://localhost:5001/swagger
Frontend Setup (Angular)
Navigate to the frontend directory:

bash
Copy
cd TaskManagementFrontend
Install the required npm packages:

bash
Copy
npm install
Start the Angular development server:

bash
Copy
ng serve
The frontend will now be running at http://localhost:4200. You can interact with the API through the Angular frontend.

API Endpoints
The backend exposes the following API endpoints for managing tasks:

GET /api/tasks

Fetch all tasks.
GET /api/tasks/{id}

Fetch a task by its ID.
POST /api/tasks

Create a new task. The request body should contain the task data, for example:
json
Copy
{
  "title": "Task 1",
  "description": "Description for Task 1",
  "isCompleted": false
}
PUT /api/tasks/{id}

Update an existing task. The request body should contain the updated task data.
DELETE /api/tasks/{id}

Delete a task by its ID.
Swagger UI
Swagger is enabled for API documentation. It provides a visual interface to interact with the API without needing to write custom code or use external tools. To access it, go to:

bash
Copy
https://localhost:5001/swagger
Folder Structure
Backend (TaskManagementApi):

Controllers: Contains API controllers that handle HTTP requests.
Models: Contains the database models and the DbContext.
Migrations: Contains Entity Framework Core migration files for database schema.
Startup.cs: Configures services like database context, API routes, and middleware.
Frontend (TaskManagementFrontend):

src/app: Contains Angular components and services.
app.component.ts: Main Angular component for managing the task UI.
task.service.ts: Service to communicate with the backend API.
How It Works
Frontend: The frontend is built using Angular and communicates with the backend via HTTP requests. It displays a list of tasks, allows adding new tasks, and provides options to edit or delete tasks.

Backend: The backend API built with ASP.NET Core exposes a set of RESTful endpoints for CRUD operations. The backend interacts with a SQL Server database using Entity Framework Core. The API also uses Swagger to document and test the endpoints.

Database: The database stores the tasks, and the schema is defined using Entity Framework Core models. Upon running migrations, the database is created, and the schema is set up automatically.
