# Solar System GUI Examples

This folder contains one shared domain library and two UI applications:

- `SolarSystem.Core`: `Planet` model plus `SolarSystemService`
- `SolarSystem.Blazor`: Blazor Server UI that consumes the class library directly
- `SolarSystem.Api`: Minimal API plus an HTMX-powered static page

## Run

```bash
dotnet run --project SolarSystem.Blazor
dotnet run --project SolarSystem.Api
```

Default development URLs from the current launch settings:

- Blazor: `http://localhost:5088`
- API + HTMX: `http://localhost:5247`
