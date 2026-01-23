# Getting Started with React Scheduler Component using React and .Net application
## Description

This repository showcases a full‑stack sample application demonstrating how to integrate the Syncfusion React Scheduler component into a React application that communicates with a .NET backend using Axios.<br />
The .NET API provides REST endpoints for managing calendar events stored on the server, while the React frontend delivers a responsive scheduling interface that enables users to create, update, view, and delete events seamlessly through the Syncfusion Scheduler.

## Setup
- Clone the repository to your local machine.

### Backend Setup
<u>**.Net Application**</u>

#### Prerequisites
- .NET Framework 4.7+ / 4.8 Developer Pack
- IIS Express software (to run .Net application)
- Use Visual Studio
- Make sure there is nothing running on the port 54738.

#### Getting ready to run 
1. Open the application solution (`.sln`) file in Visual Studio.
2. To install the needed packages
   - In Solution Explorer, right click the Solution file and click Restore NuGet Packages.
3. Build the solution to ensure all dependencies are resolved. (Build → Build Solution)

### Frontend Setup
<u>**React Application**</u>

#### Prerequisites
- Use Node Version >= 20.19.0
- Make sure there is nothing running on the port 3000.

#### Getting ready to run
1. In a new terminal, navigate to the project folder `Frontend-React/`:
2. Install application dependencies:
    ```bash
    npm install
    ```

## Running the Application

#### <u> Backend Server </u>
1. Make sure that we had completed the `backend setup` mentioned above. 
2. Start the backend server from Visual Studio.
    - Press F5 or Click the debug symbol manually.
3. Server started running on the http://localhost:54738.


#### <u> Frontend Application </u>
1. Make sure that we had completed the `frontend setup` mentioned above. 
2. From the same path `Frontend-React/`.
3. Start the frontend:
    ```bash
    npm start
    ```
4. Access the application by navigating to http://localhost:3000 in your web browser to view the output.

<br />

## Output Preview
Syncfusion React Scheduler
![FrontEnd React](./SampleOutputs/FrontEnd.png)
*Image illustrating the Syncfusion React Scheduler* 

## Troubleshooting
- **404 PageNotFound**: Ensure the backend server running on `localhost:54738`.
- **CORS errors**: Ensure the frontend running on `localhost:3000`.
- If you face any issue in .Net server application, rebuild solution. (`visual studio -> build -> rebuild solution`)