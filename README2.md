<div align="right">
  
  [![English](https://www.countryflags.io/us/flat/32.png)](README.md)
  [![Portuguese](https://www.countryflags.io/br/flat/32.png)](README-PT.md)
  
</div>

<p align="center">
  <img alt="PROJECT NAME" src=".github/banner.svg" width="250px"/>
</p>

<p align="center"> 
  <img alt="Repository Size" src="https://img.shields.io/github/repo-size/gleisonkz/dev-readme?color=3498db&style=for-the-badge">
  <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/gleisonkz/dev-readme?color=3498db&style=for-the-badge">
  <a href="https://github.com/rafaelfachinelli">
    <img alt="Developed by Gleison" src="https://img.shields.io/badge/Developer-Gleison-%3498db?color=3498db&style=for-the-badge">
  </a>
  <img alt="Project License" src="https://img.shields.io/github/license/gleisonkz/dev-readme?color=3498db&style=for-the-badge"/>
</p>

<p align="center">
 <a href="#eye_speech_bubble-preview">Preview</a> •
 <a href="#information_source-about">About</a> •
 <a href="#arrow_forward-run">Run</a> •
 <a href="#hammer_and_wrench-technologies">Technologies</a> •
 <a href="#✨">Features</a> •
 <a href="#boy-author">Author</a> •
 <a href="#balance_scale-license">License</a>
</p>

---

## :eye_speech_bubble: **Preview**

<div align="center">

### :desktop_computer: Computer

|                                  Desktop                                   |                                   Ultra Wide                                    |
| :------------------------------------------------------------------------: | :-----------------------------------------------------------------------------: |
| <kbd><img src=".github/previews/desktop_preview.jpg" alt="Desktop"/></kbd> | <kbd><img src=".github/previews/ultraWide_preview.jpg" alt="Ultra Wide"/></kbd> |

### :iphone: Responsive

|                                  Tablet                                  |                                  Mobile                                  |
| :----------------------------------------------------------------------: | :----------------------------------------------------------------------: |
| <kbd><img src=".github/previews/tablet_preview.jpg" alt="Tablet"/></kbd> | <kbd><img src=".github/previews/mobile_preview.jpg" alt="Mobile"/></kbd> |

</div>
  
---
## :information_source: About

Your description about this project.

---

## :arrow_forward: **Run**

To run the project you need to download this repository, have the Node Package Manager ([`NPM`](https://www.npmjs.com/get-npm)) or the YARN Package Manager installed ([`YARN`](https://yarnpkg.com/getting-started)).

### :desktop_computer: **WEB Responsive**

Open the command prompt in the project directory, open the [`exemple/`](exemple/) folder and execute the following commands:

<details>
  <summary><i>with <b>npm</b></i></summary>
  
  ```bash
  # Install dependencies
  $ npm install

# Start development server

$ npm start

````

</details>

<details>
<summary><i>with <b>yarn</b></i></summary>

```bash
# Install dependencies
$ yarn

# Start development server
$ yarn start

````

</details>

> ⚠️ The development server will start on port:YOURPORT - Access <http://localhost:YOURPORT>

---

## :hammer_and_wrench: **Technologies**

The following tools is used to build this project:

<div align="center">

|                            :globe_with_meridians: FrontEnd                             |                                                     :file_cabinet: BackEnd                                                     |
| :------------------------------------------------------------------------------------: | :----------------------------------------------------------------------------------------------------------------------------: |
|                           [Angular 10](https://angular.io/)                            |                                 [.NET Core 3.1 Web API](https://dotnet.microsoft.com/download)                                 |
|                [Angular Material 10.2.7](https://material.angular.io/)                 |                                     [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)                                      |
|    [Angular Flex-Layout 11.0.0](https://www.npmjs.com/package/@angular/flex-layout)    |                              [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)                              |
|         [@auth0/angular-jwt](https://www.npmjs.com/package/@auth0/angular-jwt)         |                      [SQL Server](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)                      |
|              [RxJS 6.5](https://rxjs-dev.firebaseapp.com/guide/overview)               |                                                         Nuget Packages                                                         |
|                             [SASS](https://sass-lang.com/)                             |         [EntityFrameworkCore 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/5.0.0?_src=template)          |
|               [Flexbox](https://www.w3schools.com/css/css3_flexbox.asp)                |    [EF Core Identity Design 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/5.0.0?_src=template)    |
|               [Grid Layout](https://www.w3schools.com/css/css_grid.asp)                |   [EF Core Identity Proxies 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/5.0.0?_src=template)   |
|                      [BEM Methodology](http://getbem.com/naming/)                      |     [EF Core Identity Tools 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.0?_src=template)     |
|                   [TypeScript 3.9](https://www.typescriptlang.org/)                    | [EF Core Identity 5.0.0](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/5.0.0?_src=template) |
|                                      NGX Packages                                      |                          [Predicate Builder 1.0.0](https://www.nuget.org/packages/PredicateBuilder/)                           |
|               [Ngx Mask 11.1.4](https://www.npmjs.com/package/ngx-mask)                |        [Newtonsoft 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/3.1.10?_src=template)        |
|   [Ngx Mat Select Search 3.1.4](https://www.npmjs.com/package/ngx-mat-select-search)   |     [JwtBearer 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/3.1.10?_src=template)      |
| [Ngx Material File Input 2.1.1](https://www.npmjs.com/package/ngx-material-file-input) |           [Swashbuckle.AspNetCore 5.6.3](https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.6.3?_src=template)            |
|            [Cep Promise 4.0.3 ](https://www.npmjs.com/package/cep-promise)             |                                                                                                                                |

</div>

- Development Approach
  - DDD - Domain Drive Design
  - SOLID Principles
  - Application Layers:
    - 1 - Application
    - 2 - Domain
    - 3 - Services
    - 4 - Infrastructure
    - 5 - Shared
- Patterns and Resources Applied
  - Repository
  - Generic Repository
  - Generic Pagination
  - Unity Of Work
  - Facade
  - Factory
  - Command
  - Adapter

## Folder Structure

- Front-end

  |-- app

      |-- 🎯 core
          |-- [+] classes
          |-- [+] components
          |-- [+] enums
          |-- [+] guards
          |-- [+] interceptors
          |-- [+] models
          |-- [+] pages
          |-- [+] services
          |-- core.module.ts

      |-- 👨‍💼 admin (lazy 🦥)
          |-- [+] classes
          |-- [+] components
          |-- [+] constants
          |-- [+] models
          |-- [+] services
          |-- [+] pages
          |-- admin-routing.module.ts
          |-- admin.module.ts

      |-- 📦 order (lazy 🦥)
          |-- [+] components
          |-- [+] enums
          |-- [+] guards
          |-- [+] models
          |-- [+] services
          |-- [+] pages
          |-- order-routing.module.ts
          |-- order.module.ts

      |-- 🔑 authentication (lazy 🦥)
          |-- [+] interceptors
          |-- [+] models
          |-- [+] pages
          |-- authentication-routing.module.ts
          |-- authentication.module.ts

      |-- 🤝 shared
          |-- [+] animations
          |-- [+] classes
          |-- [+] components
          |-- [+] enums
          |-- shared.module.ts

  |-- app-routing.module.ts
  |-- app.component.html
  |-- app.component.scss
  |-- app.component.ts
  |-- app.module.ts

- Modules Diagram
  ![modules-diagram](./front-end/.github/modules-diagram.png)

- Back-end

  |-- Solution ComicStoreWebAPI

      |-- 1 - Application
          |-- [+] Properties
          |-- [+] Classes
          |-- [+] Controllers
          |-- [+] DTO
          |-- [+] Filters
          |-- Program.cs
          |-- Startup.cs

      |-- 2 - Domain
          |-- [+] Enums
          |-- [+] Interfaces
          |-- [+] POCO

      |-- 3 - Service
          |-- [+] Classes
          |-- [+] Interfaces
          |-- [+] Services

      |-- 4 - Infrastructure

        |-- BaseRepository
          |-- [+] Interfaces

        |-- EFRepository
          |-- [+] Configurations
          |-- [+] Context
          |-- [+] Migrations
          |-- [+] Repository

        |-- Security
          |-- [+] Context
          |-- [+] Migrations

      |-- 5 - Shared
          |-- [+] classes

---

## ✨ **Features**

<div align="center">

- Toggle Theme Preference
- JTW Bearer Authentication
- Role-based Access Control
- CRUD operations
- Server Side Pagination
- Generic Dropdown Component with server side search filter
- Inventory Management
- Swagger Specification
- Custom Reactive Forms Validation Class

</div>

---

## :boy: **Author**

<div align="center">

<a href="https://github.com/gleisonkz">
 <img src="https://avatars1.githubusercontent.com/u/9919?s=200&v=4" width="100px;" alt="Profile Photo Gleison Almeida"/>
 <br/>
 <sub><b>Gleison de Almeida</b></sub>
</a>

Developed with ❤️ by Gleison Almeida 👋🏽 Contact me!

[![Linkedin Badge](https://img.shields.io/badge/-Gleison-blue?style=flat-square&logo=Linkedin&logoColor=white)](https://www.linkedin.com/in/gleison-ribeiro-a65257119)
[![Github Badge](https://img.shields.io/badge/-Gleison-000?style=flat-square&logo=Github&logoColor=white)](https://github.com/gleisonkz)
[![Outlook Badge](https://img.shields.io/badge/-Gleison-0078d4?style=flat-square&logo=microsoft-outlook&logoColor=white)](mailto:gleisonsubzerokz@gmail.com)

</div>

---

## :balance_scale: **License**

<div align="center">

Copyright © 2021 [Gleison Almeida](https://github.com/gleisonkz).<br />
This project is licensed by [MIT](./LICENSE).

</div>
