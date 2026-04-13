using System.Net;
using System.Text;
using SolarSystem.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SolarSystemService>();

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () => Results.Redirect("/index.html"));

app.MapGet("/api/planets", (SolarSystemService solarSystemService) =>
{
    return Results.Json(solarSystemService.GetPlanets());
});

app.MapGet("/api/planets/{name}", (string name, SolarSystemService solarSystemService) =>
{
    var planet = solarSystemService.GetPlanet(name);

    return planet is null
        ? Results.NotFound(new { message = $"No planet found with name '{name}'." })
        : Results.Json(planet);
});

app.MapGet("/planets/{name}/fragment", (string name, SolarSystemService solarSystemService) =>
{
    var planet = solarSystemService.GetPlanet(name);

    if (planet is null)
    {
        return Results.NotFound($"""
            <section class="planet-card">
                <h2>Planet not found</h2>
                <p>No planet matched the name <code>{WebUtility.HtmlEncode(name)}</code>.</p>
            </section>
            """);
    }

    return Results.Content(BuildPlanetFragment(planet), "text/html");
});

app.Run();

static string BuildPlanetFragment(Planet planet)
{
    var builder = new StringBuilder();

    builder.AppendLine("""<section class="planet-card">""");
    builder.AppendLine($"<h2>{WebUtility.HtmlEncode(planet.Name)}</h2>");
    builder.AppendLine($"<p>{WebUtility.HtmlEncode(planet.Description)}</p>");
    builder.AppendLine($"""
        <p>
            You can also compare the fragment approach with the JSON endpoint:
            <a class="json-link" href="/api/planets/{WebUtility.UrlEncode(planet.Name)}" target="_blank">/api/planets/{WebUtility.HtmlEncode(planet.Name)}</a>
        </p>
        """);
    builder.AppendLine("""<dl class="planet-facts">""");
    AppendFact("Order from Sun", planet.OrderFromSun.ToString());
    AppendFact("Planet type", planet.PlanetType);
    AppendFact("Diameter", $"{planet.DiameterKm:N0} km");
    AppendFact("Length of day", $"{planet.LengthOfDayHours:N1} hours");
    AppendFact("Moons", planet.NumberOfMoons.ToString());
    builder.AppendLine("</dl>");
    builder.AppendLine("</section>");

    return builder.ToString();

    void AppendFact(string label, string value)
    {
        builder.AppendLine($"""
            <div class="planet-fact">
                <dt>{WebUtility.HtmlEncode(label)}</dt>
                <dd>{WebUtility.HtmlEncode(value)}</dd>
            </div>
            """);
    }
}
