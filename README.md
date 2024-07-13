# User registration service

Simple user registration service.

## Tech information

The backend was created using:
- ASP.NET Core Minimal APIs;
- MediarR;
- FluentValidation;
- Microsoft EF Core;
- Sqlite;
- xUnit for testing.


The frontend was created using:
- Angular 18;
- Angular Material;
- Karma for testing.

## Run

Open it in VS 2022 and run it by F5.
The path to the Api endpoint information is `/swagger/`.

## Client Application

The Clent application is in the `client` folder (the built-in VS template 
  could not create it, so the project is separate from the solution).

After modifying an application, we need to build it so that the latest changes are available for use.

```

ng build --configuration production

```