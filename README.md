# Employee Management System

A production-style ASP.NET Core MVC application built step by step while learning enterprise application development.

This project is not just a CRUD application. It is designed to gradually evolve into a real-world Employee Management System using modern ASP.NET Core architecture and best practices.

---

## Tech Stack

- ASP.NET Core MVC (.NET 10)
- C#
- Razor Views
- Bootstrap 5
- Dependency Injection
- MVC Architecture

Future Technologies

- Entity Framework Core
- SQL Server
- Repository Pattern
- Service Layer
- Authentication & Authorization
- Logging
- Background Services
- Deployment

---

## Features Implemented

### Employee List

- Displays employees in a Bootstrap table
- Uses Razor foreach loop
- Strongly Typed View
- Data provided through Service Layer

### Employee Details

- Displays complete information of a selected employee
- Uses route parameters
- Returns HTTP 404 for invalid employee IDs

### Service Layer

- Business logic separated from controllers
- Registered using Dependency Injection
- Controllers remain thin and maintainable

### Shared Layout

- Common navigation bar
- Shared footer
- Bootstrap integration
- Uses `_Layout.cshtml`
- Shared across all pages

---

## Current Project Structure

```
EmployeeManagementSystem
│
├── Controllers
│   ├── HomeController.cs
│   └── EmployeeController.cs
│
├── Models
│   └── Employee.cs
│
├── Services
│   └── EmployeeService.cs
│
├── Views
│   ├── Employee
│   │   ├── List.cshtml
│   │   └── Details.cshtml
│   │
│   ├── Home
│   │
│   ├── Shared
│   │   └── _Layout.cshtml
│   │
│   └── _ViewStart.cshtml
│
├── wwwroot
│
├── Program.cs
│
└── appsettings.json
```

---

## Architecture

```
Browser

        │

        ▼

Routing

        │

        ▼

EmployeeController

        │

        ▼

EmployeeService

        │

        ▼

Employee Model

        │

        ▼

Razor View

        │

        ▼

Generated HTML

        │

        ▼

Browser
```

---

## Implemented MVC Flow

### Employee List

```
GET /Employee/List

↓

EmployeeController

↓

EmployeeService.GetEmployees()

↓

List<Employee>

↓

List.cshtml

↓

HTML Table

↓

Browser
```

---

### Employee Details

```
GET /Employee/Details/{id}

↓

EmployeeController

↓

EmployeeService.GetEmployeeById(id)

↓

Employee

↓

Details.cshtml

↓

HTML

↓

Browser
```

---

## Design Principles Used

- MVC Architecture
- Separation of Concerns
- Dependency Injection
- Thin Controllers
- Strongly Typed Views
- Convention over Configuration

---

## Current Limitations

Currently the application uses hardcoded employee data.

No database integration has been added yet.

This is intentional because the focus is to first master the MVC architecture before introducing Entity Framework Core.

---

## Roadmap

### Completed

- ASP.NET Core Fundamentals
- MVC Architecture
- Controllers
- Action Methods
- Views
- Razor
- Models
- Layouts
- Employee List
- Employee Details
- Dependency Injection
- Service Layer

---

### Coming Next

- HTML Forms
- GET vs POST
- Model Binding
- Employee Creation
- Validation
- ModelState
- Edit Employee
- Delete Employee
- Entity Framework Core
- SQL Server
- Repository Pattern
- Authentication
- Authorization
- Deployment

---

## Learning Goals

This project is being developed following enterprise development practices rather than tutorial shortcuts.

Each feature is introduced only after understanding the underlying concepts, ensuring that the application evolves from a simple MVC project into a production-ready Employee Management System.

---

## Author

Sarthak Sinha

Built while learning ASP.NET Core MVC with a focus on enterprise architecture and clean code principles.