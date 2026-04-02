# waitinglist

A starter ASP.NET Core MVC app for building a waiting-list product.

The project currently includes:

- ASP.NET Core MVC on .NET 8
- ASP.NET Core Identity (default UI)
- Entity Framework Core with SQLite (`app.db`)
- Tailwind CSS build/watch scripts

## Current Status

This repository is currently close to the default MVC + Identity scaffold and is ready for feature development.

## Tech Stack

- .NET 8 (`net8.0`)
- ASP.NET Core MVC + Razor Pages
- ASP.NET Core Identity
- Entity Framework Core + SQLite
- Tailwind CSS (`tailwindcss` + `@tailwindcss/cli`)

## Project Layout

- `waitinglist/` - main web app
- `waitinglist/Program.cs` - app startup and middleware pipeline
- `waitinglist/Data/ApplicationDbContext.cs` - EF Core Identity DbContext
- `waitinglist/Data/Migrations/` - EF Core migrations
- `waitinglist/wwwroot/css/input.css` - Tailwind source CSS
- `waitinglist/wwwroot/css/site.css` - generated CSS output

## Prerequisites

- .NET SDK 8.x
- Node.js 18+ and npm

## Getting Started

From the repository root:

```bash
cd waitinglist
```

Restore .NET dependencies:

```bash
dotnet restore
```

Install frontend dependencies:

```bash
npm install
```

## Run the App

Start the ASP.NET app:

```bash
dotnet run
```

Default development URLs (from `launchSettings.json`):

- `https://localhost:7091`
- `http://localhost:5113`

## Tailwind CSS

Build CSS once:

```bash
npm run css:build
```

Watch and rebuild on changes:

```bash
npm run css:watch
```

## Database and Identity

- Connection string is configured in `waitinglist/appsettings.json` as `DefaultConnection`.
- SQLite database file is `waitinglist/app.db`.
- Identity is configured with `RequireConfirmedAccount = true` in `waitinglist/Program.cs`.

If you add new models, create/apply migrations from `waitinglist/`:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

## Next Development Steps

1. Add waiting-list domain models (for example: queues, entries, status).
2. Build CRUD pages/APIs for queue management.
3. Add role-based authorization for admin/staff workflows.
4. Add tests for core queue logic and access control.

## Notes

- `appsettings.Development.json` can override local settings.
- The project includes a `UserSecretsId`; use user secrets for sensitive local development values.

