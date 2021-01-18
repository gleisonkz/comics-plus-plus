## Clique aqui para ver em : [Inglês](./README.md)

## 📖 Sobre o projeto

Está aplicação trata-se de um e-commerce de quadrinhos, onde é possível realizar as operações básicas de um CRUD
criar, editar, atualizar e deletar cada quadrinho.

## 🤖 Tecnologias e Recursos

tecnologias, padrões e pacotes que utilizei para está aplicação.

- Front-end

  - [Angular 10](https://angular.io/)
    - [Angular Material 10.2.7](https://material.angular.io/)
    - [Angular Flex-Layout 11.0.0](https://www.npmjs.com/package/@angular/flex-layout)
    - [@auth0/angular-jwt](https://www.npmjs.com/package/@auth0/angular-jwt)
    - [RxJS 6.5](https://rxjs-dev.firebaseapp.com/guide/overview)
  - [SASS](https://sass-lang.com/)
    - [Flexbox](https://www.w3schools.com/css/css3_flexbox.asp)
    - [Grid Layout](https://www.w3schools.com/css/css_grid.asp)
    - [BEM Methodology](http://getbem.com/naming/)
  - [TypeScript 3.9](https://www.typescriptlang.org/)
  - NGX Packages
    - [Ngx Mask 11.1.4](https://www.npmjs.com/package/ngx-mask)
    - [Ngx Mat Select Search 3.1.4](https://www.npmjs.com/package/ngx-mat-select-search)
    - [Ngx Material File Input 2.1.1](https://www.npmjs.com/package/ngx-material-file-input)
  - Other Packages
    - [Cep Promise 4.0.3 ](https://www.npmjs.com/package/cep-promise)

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
    - [Microsoft.AspNetCore.Mvc.Newtonsoft 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/3.1.10?_src=template)
    - [Microsoft.AspNetCore.Authentication.JwtBearer 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/3.1.10?_src=template)
    - [Swashbuckle.AspNetCore 5.6.3](https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.6.3?_src=template)

  - Abordagem de Desenvolvimento
    - DDD - Domain Drive Design
    - SOLID Principles
    - Application Layers:
      - 1 - Application
      - 2 - Domain
      - 3 - Services
      - 4 - Infrastructure
      - 5 - Shared
  - Design Patterns Utilizados
    - Repository
    - Generic Repository
    - Generic Pagination
    - Unity Of Work
    - Facade
    - Factory
    - Command
    - Adapter

## Estrutura de Pastas

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

- Diagrama dos Módulos utilizados.
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

## ✨ Features Principais

- Alternância entre temas claro e escuro
- Autenticação utilizando JTW Bearer
- Controle de acesso com Roles
- Operações básica de CRUD
- Paginação server-side
- Componente de Dropdown genérico com filtro de busca no servidor.
- Controle de Estoque
- Documentação com Swagger
- Classe customizada para validação de Reactive Forms
