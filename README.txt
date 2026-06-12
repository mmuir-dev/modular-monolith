# RiverBooks — Modular Monolith in .NET

A training project following the Dometrain course
**"Getting Started: Modular Monoliths in .NET"** by Steve "ardalis" Smith.
https://dometrain.com/course/getting-started-modular-monoliths-in-dotnet/

## About

RiverBooks is a sample ecommerce application used to demonstrate how to structure
a .NET application as a modular monolith — breaking the application into largely
independent logical modules without the deployment overhead of microservices.

## Architecture

The solution uses a modular monolith pattern with a single deployable web API host
and independently structured modules behind it.

### Projects

| Project | Description |
|---|---|
| `RiverBooks.Web` | ASP.NET Core Web API host — startup project |
| `RiverBooks.Books` | Books module — domain, services, EF Core persistence, and API endpoints |

### Key Technologies

- .NET 10
- ASP.NET Core Web API
- FastEndpoints (v8)
- Entity Framework Core
- SQLite (development)

## Getting Started

### Prerequisites

- .NET 10 SDK
- A REST client (e.g. Insomnia, Postman, or the `.http` file in `RiverBooks.Web`)

### Run the application

```bash
cd RiverBooks.Web
dotnet run
```

### Apply migrations

```bash
dotnet ef migrations add <MigrationName> -c BookDbContext \
  -p ..\RiverBooks.Books\RiverBooks.Books.csproj \
  -s .\RiverBooks.Web.csproj \
  -o Data/Migrations

dotnet ef database update -c BookDbContext \
  -p ..\RiverBooks.Books\RiverBooks.Books.csproj \
  -s .\RiverBooks.Web.csproj
```

## Course Modules Covered

- [x] Architecture Comparison (monolith vs microservices vs modular monolith)
- [x] Application Setup
- [x] The Books Module (domain, persistence, EF Core)
- [ ] Building the Web API
- [ ] The Users Module
- [ ] Module Deep Dive


Useful migration command:  dotnet ef migrations add Initial -c BookDbContext -p ..\RiverBooks.Books\RiverBooks.Books.csproj -s .\RiverBooks.Web.csproj -o Data/Migrations