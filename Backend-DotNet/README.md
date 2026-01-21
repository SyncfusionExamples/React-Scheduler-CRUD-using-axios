# Backend Setup

<br />

## .Net Application

## Prerequisites
- .NET Framework 4.7+ / 4.8 Developer Pack
- IIS Express software (to run .Net application)
- Use Visual Studio
- Make sure there is nothing running on the port 54738.

<br />

## Project Structure
```
ScheduleSample/                      
├── App_Data/
├── App_Start/
├── Controllers/
├── Models/
├── Views/
├── Content/
├── Scripts/
├── Global.asax
├── Web.config
├── Web.*.config
└── ScheduleSample.csproj
```

<br />

## Getting ready to run 
1. Open the application solution file in Visual Studio.
2. To install the needed packages
   - In Solution Explorer, right click the Solution file and click Restore NuGet Packages.

<br />

## Available Endpoints
The .Net server exposes the following REST routes:
| Method | URL                          | Description                         |
| ------ | ---------------------------- | ----------------------------------- |
| GET   | `Home/GetData`    | Fetch all the events |
| POST   | `Home/Insert`  | Insert event                
| POST   | `Home/Update`  | Update event   |
| POST   | `Home/Delete`  | Delete event 
