# Employee Management System

## Description:
This Employee Management System allows verification of employee data via a web form that interacts with a backend API. The frontend is built with Next.js and React, using TypeScript for type safety. The backend is created with ASP.NET Core Web API, and an EF Core in-memory database for simplified data storage with pre-seeded employee records for testing.

## Assumptions:

* Employee records are static and stored in an in-memory EF Core database for testing.
* Basic sanitization checks are applied to prevent invalid inputs and cross-site scripting (XSS). Also, CORS is also enabled for Frontend to Ensure Security.
## Features:

* Frontend: Employment verification form, API call using axios.
* Backend: ASP.NET Core Web API with data stored in an in-memory EF Core database for testing.
* Security: Input validation and basic sanitization to ensure data integrity and prevent XSS attacks, CORS allowed for frontend, Console Logging for easier error fixing.

## Running the Application
### Backend:

Navigate to the Employment-Verification-API folder.
Run:
`dotnet run`
The API runs at http://localhost:5258.

### Frontend:

Navigate to the employment-verification folder.
Run:
`npm run dev`
The frontend runs at http://localhost:3000.

## Sample Data

| Employee ID   | Company name  |Verification code|
| ------------- |:-------------:|:-------------:  |
| 1             | HCLTech       | 12345           |
| 2             | cisive        | abcde           |
| 3             | DishTV        | ASDFG           |
| 4             | Youth4work    | 08642           |
| 5             | ALCHEMY       | AD468           |