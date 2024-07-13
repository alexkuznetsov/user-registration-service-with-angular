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

If there are some plans for modify the app, so, first, open console in the `client` folder
and run:

```
npm i
```

After installing the dependencies, run 
```
ng serve
```

and open the application in the ~~preferred browser~~ Google Chrome.

After making changes to the application, we need to build it so that the latest changes are available for use.

```

ng build --configuration production

```

### Localization

Run from console:

```
 ng extract-i18n --output-path src/locale
```

This command will update the translations.


## Tests

Run from console:

```
 ng test
```

All tests must be green.