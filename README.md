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
- Visual Studio (recommended)

### Steps
1. Open the application solution (`.sln`) file in Visual Studio.
2. Restore NuGet packages:  
   **Solution Explorer → Right‑click Solution → Restore NuGet Packages**
3. Build the solution:  
   **Build → Build Solution**
4. Start the backend:  
   Press **F5** or start with the debug icon.

Your backend will run at: **https://localhost:7163**

## Frontend Setup (React Application)

### Prerequisites
- Use Node Version >= 18.x (LTS Recommended)
- Ensure **port 3000** is free

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
Visit the application at:  **http://localhost:3000**

## Output Preview
Syncfusion React Scheduler
![FrontEnd React Scheduler Output](/react-frontend/react-scheduler-output.png)
*Image illustrating the Syncfusion React Scheduler* 

## Troubleshooting

| Issue | Possible Cause | Solution |
|-------|----------------|----------|
| **404 – Page Not Found** | Backend not running | Start backend at **localhost:7163** |
| **CORS Errors** | Frontend/backend mismatch | Ensure frontend runs at **localhost:3000** |
| **Backend fails to respond** | Build issues | Visual Studio → **Build → Rebuild Solution** |
| **Port conflict** | Other apps using port | Close the conflicting app or change port |