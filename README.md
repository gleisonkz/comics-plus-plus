## 📖 About the project

This application is comics web store. it's possible to create, edit, update and delete each book.

## 🤖 Technologies

Technologies, Design and Patterns that I used to develop this application.

- Front-end

  - [Angular 10](https://angular.io/)
    - [Angular Material 10.2.7](https://material.angular.io/)
    - [Angular Flex Layout](https://github.com/angular/flex-layout/wiki/fxLayout-API)
    - [RxJS 6.5](https://rxjs-dev.firebaseapp.com/guide/overview)
  - [SASS](https://sass-lang.com/)
    - [Flexbox](https://www.w3schools.com/css/css3_flexbox.asp)
    - [Grid Layout](https://www.w3schools.com/css/css_grid.asp)
    - [BEM Methodology](http://getbem.com/naming/)
  - [TypeScript 3.9](https://www.typescriptlang.org/)

- Back-end

  - [.NET Core 3.1 Web API](https://dotnet.microsoft.com/download)
  - [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
  - [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
  - [SQL Server](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)
  - Nuget Packages

    - [Microsoft.EntityFrameworkCore 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/5.0.0?_src=template)
    - [Microsoft.EntityFrameworkCore.Design 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/5.0.0?_src=template)
    - [Microsoft.EntityFrameworkCore.Proxies 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/5.0.0?_src=template)
    - [Microsoft.EntityFrameworkCore.Tools 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.0?_src=template)
    - [Microsoft.AspNetCore.Identity.EntityFrameworkCore 5.0.0](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/5.0.0?_src=template)
    - [Predicate Builder 1.0.0](https://www.nuget.org/packages/PredicateBuilder/)
    - [System.Drawing.Common 5.0.0](https://www.nuget.org/packages/System.Drawing.Common/5.0.0?_src=template)
    - [Microsoft.AspNetCore.Mvc.Newtonsoft 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/3.1.10?_src=template)
    - [Microsoft.AspNetCore.Authentication.JwtBearer 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/3.1.10?_src=template)
    - [Swashbuckle.AspNetCore 5.6.3](https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.6.3?_src=template)

  - Development Approach
    - DDD - Domain Drive Design
    - SOLID Principles
    - API Layers:
      - Application
      - Domain
      - Services
      - Infrastructure
  - Patterns Applied
    - Repository
    - Generic Repository
    - Generic Pagination
    - Unity Of Work
    - Facade
    - Factory
    - Command
    - Adapter

## Folder Structure

|-- app
|-- [+] components
|-- [+] pages
|-- [+] guards
|-- [+] interceptors
|-- [+] services
|-- [+] mocks
|-- [+] models  
|-- modules

    |-- admin --Lazy Load Module Example
        |-- [+] components
        |-- [+] models
        |-- [+] services
        |-- [+] pages
        |-- admin.module.ts
        |-- admin.routes.ts

    |-- authentication
        |-- [+] models
        |-- [+] services
        |-- [+] pages
        |-- authentication.module.ts
        |-- authentication.routes.ts

    |-- shared
        |-- [+] animations
        |-- [+] classes
        |-- [+] components
        |-- [+] enums
        |-- [+] services
        |-- shared.module.ts

|-- app.module.ts
|-- app.component.ts

## ✨ Main Features

- Toggle Theme
- JTW Bearer Authentication
- CRUD operations
- Pagination
- Generic Dropdown Component with server side search filter
- ...
