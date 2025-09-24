# Project: DarElkotb

Comprehensive guide to set up, run, and develop this ASP.NET Core MVC application (an electronic library).

Main project file: `DarElkotb.csproj`

---

## Overview

This is an ASP.NET Core MVC web application (targeting .NET 9) for managing books, authors, publishers, categories and users via ASP.NET Identity.

Key features:

- Book CRUD pages (Index, Details, Add, Edit, Delete)
- Upload and serve images for books and authors from `wwwroot/assets/images/`
- User and role management using Identity
- EF Core with SQL Server and Lazy Loading Proxies

---

## Requirements

- .NET 9 SDK installed (verify with `dotnet --info`)
- SQL Server or LocalDB available
- (Optional) `dotnet-ef` tool for migrations management

---

## Install tooling (one-time)

Run in PowerShell from the project root:

```powershell
# If not already installed
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
```

You may need to run PowerShell as Administrator to install a global tool.

---

## Connection string

The connection string key used by the app is `MonasterConnection` (in `appsettings.json`). Example:

```json
{
  "ConnectionStrings": {
    "MonasterConnection": "Server=.;Database=DarElkotbDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

Adjust the value to match your SQL Server instance.

---

## EF Core Migrations and the "PendingModelChangesWarning"

If you see the exception/warning:

```
The model for context 'AppDbContext' has pending changes. Add a new migration before updating the database.
```

It means your EF Core model differs from the last applied migration. Two safe options:

Option A (recommended) — create & apply a migration:

```powershell
dotnet ef migrations add DescribeYourChange
dotnet ef database update
```

Option B (quick / temporary) — suppress or change the warning behavior in `Program.cs` when registering the DbContext:

```csharp
using Microsoft.EntityFrameworkCore.Diagnostics;

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseLazyLoadingProxies()
         .UseSqlServer(builder.Configuration.GetConnectionString("MonasterConnection"))
         .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
);
```

You can use `.Throw(...)` instead of `.Ignore(...)` if you want the app to fail fast when migrations are missing.

Note: prefer Option A for production as it keeps schema changes under source control.

---

## Run the app locally

From the project root (PowerShell):

```powershell
dotnet build
dotnet run
```

Or open `DarElkotb.sln` in Visual Studio and press F5.

Important runtime notes:

- `Program.cs` creates a scope at startup to run `IdentitySeeder` to seed roles and an admin user. Check `Helpers/Seeders/IdentitySeeder.cs` to see default credentials or change them.

---

## Important folders and files

- `Controllers/` — MVC controllers
- `Views/` — Razor views
- `wwwroot/assets/images/books/` — book images
- `wwwroot/assets/images/authors/` — author images
- `Data/AppDbContext.cs` — EF Core DbContext
- `Repository/`, `Services/` — repository and service layers

Make sure to include a `default.png` fallback image in the authors and books image folders to avoid broken image links.

---

## Publishing

Publish with Visual Studio Publish or via CLI:

```powershell
dotnet publish -c Release -o ./publish
```

Deploy the `publish` folder to IIS, Azure App Service, or your host of choice.

---

## Troubleshooting & common issues

- PendingModelChangesWarning: create and apply a migration (see above).
- Missing images: confirm files exist under `wwwroot/assets/images/...` and check model property names (e.g. `CoverImage`, `ProfileImage`, `Photo`).
- Identity / seeding issues: review `Helpers/Seeders/IdentitySeeder.cs` and application logs.

---

## Tests

There are no test projects included. To add tests, create an xUnit/NUnit project, add it to the solution, and write unit/integration tests for services and repositories.

---

## Recommended improvements

- Move sensitive connection strings to environment variables or a secrets manager.
- Add automated CI (GitHub Actions) to build the solution and optionally run `dotnet ef migrations` checks.
- Add unit and integration tests for repository and service layers.

---

## Contributing

Contributions are welcome. Create an Issue first, then open a PR. Follow coding conventions and include tests for new functionality.

---

## Resources

- EF Core docs: https://aka.ms/efcore-docs
- ASP.NET Core docs: https://learn.microsoft.com/aspnet/core

---

If you'd like, I can also add a GitHub Actions workflow that runs `dotnet build` (and an EF migration check) on push/PR — want me to add it?
