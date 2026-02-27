# Syncfusion React Scheduler With ASP.NET Core API Using Axios
## Description

A full‑stack sample application demonstrating how to integrate the **Syncfusion React Scheduler** with a **ASP.NET Core Web API backend** using **Axios** for performing CRUD (Create, Read, Update, Delete) operations.  
The application features a responsive scheduling UI on the frontend and REST API–based event management on the backend.

## Overview

This project showcases:

- A **React** frontend that uses the **Syncfusion React Scheduler** component to display and manage events.
- A **ASP.NET Core 10 Web API** backend exposing RESTful API endpoints.
- **Axios** for communication between the React UI and the server.
- Complete CRUD support: create, update, delete, and retrieve events.
- A practical example of synchronizing UI state with a server‑side database.

## Setup
- Clone the repository to your local machine.

## Backend Setup (ASP.NET Core 10 Web API Application)

### Prerequisites
- .NET 10 SDK (ASP.NET Core 10 Web API)

### Steps
1. Go into the API folder:
   ```bash
   cd ScheduleApi
   ```
2. Restore all .NET packages: 
  ```bash
   dotnet restore
   ```
3. Update the database:
   As this repo includes migrations, simply run
   ```bash
   dotnet ef database update
   ```
4. Run the API:
   ```
   dotnet run
   ```

Your backend will run at: **https://localhost:7268**

## Frontend Setup (React Application)

### Prerequisites
- Use Node Version >= 18.x (LTS Recommended)
- Ensure **port 5173** is free

### Steps
1. Open a terminal and navigate to:
   ```
   cd react-frontend/
   ```
2. Install dependencies:
   ```
   npm install
   ```
3. Start the React application:
   ```
   npm start
   ```
Visit the application at:  **http://localhost:5173**

## Output Preview
Syncfusion React Scheduler
![FrontEnd React Scheduler Output](/react-frontend/react-scheduler-output.png)
*Image illustrating the Syncfusion React Scheduler* 

## Troubleshooting

| Issue | Possible Cause | Solution |
|-------|----------------|----------|
| **404 – Page Not Found** | Backend not running | Start backend at **localhost:7268** |
| **CORS Errors** | Frontend/backend mismatch | Ensure frontend runs at **localhost:5173** |
| **Backend fails to respond** | Build issues | Visual Studio → **Build → Rebuild Solution** |
| **Port conflict** | Other apps using port | Close the conflicting app or change port |