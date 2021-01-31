<div align="right">

[![Netlify Status](https://api.netlify.com/api/v1/badges/1fa15619-9ade-473e-9196-b53a0a03780c/deploy-status)](https://app.netlify.com/sites/comics-plus-plus/deploys)

<div align="right">

[![English](https://www.countryflags.io/us/flat/32.png)](README.md) [![Portuguese](https://www.countryflags.io/br/flat/32.png)](README-PT.md)

</div>

</div>

<p align="center">
  <img alt="Comics ++" src="./front-end/.github/logo.png" width="250px"/>
</p>

<p align="center"> 
  <img alt="Repository Size" src="https://img.shields.io/github/repo-size/gleisonkz/comics-plus-plus?color=3498db&style=for-the-badge&label=Tamanho%20repositorio">
  
  <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/gleisonkz/comics-plus-plus?color=3498db&style=for-the-badge&label=Ultimo%20Commit">     
  <a href="https://github.com/gleisonkz">
    <img alt="Developed by Gleison" src="https://img.shields.io/badge/Desenvolvedor-Gleison-%3498db?color=3498db&style=for-the-badge&">
  </a>    
  <img alt="Project License" src="https://img.shields.io/apm/l/vim-mode?style=for-the-badge&label=Licen%C3%A7a"/>
</p>

<p align="center">
 <a href="#eye_speech_bubble-visualizar">Visualizar</a> •
 <a href="#information_source-sobre">Sobre</a> •
 <a href="#arrow_forward-executar">Executar</a> •
 <a href="#hammer_and_wrench-tecnologias">Tecnologias</a> • 
 <a href="#sparkles-funcionalidades">Funcionalidades</a> •
 <a href="#boy-autor">Autor</a> •
 <a href="#balance_scale-licença">Licença</a>
</p>

---

## :eye_speech_bubble: **Visualizar**

<div align="center">

Deploy do front-end efetuado no [Netlify](https://www.netlify.com/) para visualizar: [Clique Aqui](https://comics-plus-plus.netlify.app/)
Deploy da API efetuado no [Heroku](https://www.heroku.com/) para visualizar: [Clique Aqui](https://kz-comic-store.herokuapp.com/index.html)

### :desktop_computer: Computer

|                                        Desktop                                        |                                        Ultra Wide                                        |
| :-----------------------------------------------------------------------------------: | :--------------------------------------------------------------------------------------: |
| <kbd><img src="./front-end/.github/previews/desktop-preview.png" alt="Tablet"/></kbd> | <kbd><img src="./front-end/.github/previews/ultra-wide-preview.png" alt="Mobile"/></kbd> |

### :iphone: Responsive

|                                        Tablet                                        |                                        Mobile                                        |
| :----------------------------------------------------------------------------------: | :----------------------------------------------------------------------------------: |
| <kbd><img src="./front-end/.github/previews/tablet-preview.png" alt="Tablet"/></kbd> | <kbd><img src="./front-end/.github/previews/mobile-preview.png" alt="Mobile"/></kbd> |

</div>
  
---
## :information_source: Sobre

<div align="center">

E-commerce de quadrinhos desenvolvido para um teste de uma vaga como .NET full-stack, nesta aplicação é possível realizar todas as operações de CRUD para os quadrinhos, autores e categorias, controle de estoque, autenticação e autorização de recursos.

</div>

---

## :arrow_forward: **Executar**

<div align="center">

Para executar esse projeto você precisa baixar este repositório, ter o Gerenciador de Pacotes do Node ([`NPM`](https://www.npmjs.com/get-npm)) ou o Gerenciador de Pacotes YARN ([`YARN`](https://yarnpkg.com/getting-started)) instalado.

Abra o prompt de comando no diretório do projeto, e execute os seguintes códigos:

<details>
  <summary><i>com <b>npm</b></i></summary>
  
  ```bash
  # Instalar dependências
  $ npm install ou npm i

# Iniciar o servidor de desenvolvimento

$ ng serve --open ou ng s -o

````

</details>

<details>
<summary><i>com <b>yarn</b></i></summary>

```bash
# Instalar dependências
$ yarn install

# Iniciar o servidor de desenvolvimento
$ ng serve --open ou ng s -o

````

</details>

> ⚠️ O servidor de desenvolvimento será iniciado na porta: 4200 - Acesse <http://localhost:4200>

</div>

---

## :hammer_and_wrench: **Tecnologias**

<div align="center">

Tecnologias, abordagem, padrões e pacotes utilizados para desenvolver esta aplicação.

|                            :globe_with_meridians: FrontEnd                             |                                                     :file_cabinet: BackEnd                                                     |
| :------------------------------------------------------------------------------------: | :----------------------------------------------------------------------------------------------------------------------------: |
|                           [Angular 10](https://angular.io/)                            |                                 [.NET Core 3.1 Web API](https://dotnet.microsoft.com/download)                                 |
|                [Angular Material 10.2.7](https://material.angular.io/)                 |                                     [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)                                      |
|    [Angular Flex-Layout 11.0.0](https://www.npmjs.com/package/@angular/flex-layout)    |                              [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)                              |
|         [@auth0/angular-jwt](https://www.npmjs.com/package/@auth0/angular-jwt)         |                      [SQL Server](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)                      |
|              [RxJS 6.5](https://rxjs-dev.firebaseapp.com/guide/overview)               |                                                         Nuget Packages                                                         |
|                             [SASS](https://sass-lang.com/)                             |         [EntityFrameworkCore 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/5.0.0?_src=template)          |
|               [Flexbox](https://www.w3schools.com/css/css3_flexbox.asp)                |        [EF Core.Design 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/5.0.0?_src=template)         |
|               [Grid Layout](https://www.w3schools.com/css/css_grid.asp)                |       [EF Core.Proxies 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/5.0.0?_src=template)        |
|                      [BEM Methodology](http://getbem.com/naming/)                      |         [EF Core.Tools 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/5.0.0?_src=template)          |
|            [Cep Promise 4.0.4 ](https://www.npmjs.com/package/cep-promise)             |            [EF Core.SqlServer 5.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/5.0.0)             |
|                   [TypeScript 3.9](https://www.typescriptlang.org/)                    | [EF Core Identity 5.0.0](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/5.0.0?_src=template) |
|                                      NGX Packages                                      |                          [Predicate Builder 1.0.0](https://www.nuget.org/packages/PredicateBuilder/)                           |
|               [Ngx Mask 11.1.4](https://www.npmjs.com/package/ngx-mask)                |        [Newtonsoft 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/3.1.10?_src=template)        |
|   [Ngx Mat Select Search 3.1.4](https://www.npmjs.com/package/ngx-mat-select-search)   |     [JwtBearer 3.1.10](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/3.1.10?_src=template)      |
| [Ngx Material File Input 2.1.1](https://www.npmjs.com/package/ngx-material-file-input) |           [Swashbuckle.AspNetCore 5.6.3](https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.6.3?_src=template)            |
|                                                                                        |                                                                                                                                |

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

## :sparkles: **Funcionalidades**

|              :globe_with_meridians: FrontEnd              |                          :file_cabinet: BackEnd                          |
| :-------------------------------------------------------: | :----------------------------------------------------------------------: |
|              Aplicação de Temas Dark e Light              |                       Autenticação com JTW Bearer                        |
|               Rotas com controle de acesso                |                        JTW Bearer Authentication                         |
|             Armazenamento de imagens em cache             |                      Retorno de dados com paginação                      |
|     Componente Genérico de busca e filtro no servidor     |                         Documentação com Swagger                         |
|   DataSource<T> customizado para paginação server side    | Conversor de Json customizado para mapear Interface para tipos concretos |
| Generic Dropdown Component with server side search filter |                     Validação de Models customizada                      |
|   Classe customizada para validação nos Reactive Forms    |           Contexto do Identity separado do Contexto do Domain            |
|               Componente de Dialog Genérico               |                             Testes Unitários                             |

---

## :boy: **Autor**

<div align="center">

<a href="https://github.com/gleisonkz">
 <img src="https://avatars1.githubusercontent.com/u/9919?s=200&v=4" width="100px;" alt="Profile Photo Gleison Almeida"/>
 <br/>
 <sub><b>Gleison de Almeida</b></sub>
</a>

Desenvolvido com ❤️ por Gleison Almeida 👋🏽 Meus Contatos!

[![Linkedin Badge](https://img.shields.io/badge/-Gleison-blue?style=flat-square&logo=Linkedin&logoColor=white)](https://www.linkedin.com/in/gleison-ribeiro-a65257119)
[![Github Badge](https://img.shields.io/badge/-Gleison-000?style=flat-square&logo=Github&logoColor=white)](https://github.com/gleisonkz)
[![Outlook Badge](https://img.shields.io/badge/-Gleison-0078d4?style=flat-square&logo=microsoft-outlook&logoColor=white)](mailto:gleisonsubzerokz@gmail.com)

</div>

---

## :balance_scale: **Licença**

<div align="center">

Copyright © 2021 [Gleison Almeida](https://github.com/gleisonkz).<br />
This project is licensed by [MIT](./LICENSE).

</div>
