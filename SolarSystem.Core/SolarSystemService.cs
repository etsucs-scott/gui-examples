namespace SolarSystem.Core;

public sealed class SolarSystemService
{
    private static readonly IReadOnlyList<Planet> Planets = new List<Planet>
    {
        new()
        {
            Name = "Mercury",
            OrderFromSun = 1,
            PlanetType = "Rocky",
            DiameterKm = 4879,
            LengthOfDayHours = 1407.6,
            NumberOfMoons = 0,
            Description = "Mercury is the smallest planet and the closest one to the Sun."
        },
        new()
        {
            Name = "Venus",
            OrderFromSun = 2,
            PlanetType = "Rocky",
            DiameterKm = 12104,
            LengthOfDayHours = 5832.5,
            NumberOfMoons = 0,
            Description = "Venus has a thick atmosphere that traps heat, making it the hottest planet."
        },
        new()
        {
            Name = "Earth",
            OrderFromSun = 3,
            PlanetType = "Rocky",
            DiameterKm = 12742,
            LengthOfDayHours = 24,
            NumberOfMoons = 1,
            Description = "Earth is the only known planet with liquid water on the surface and life."
        },
        new()
        {
            Name = "Mars",
            OrderFromSun = 4,
            PlanetType = "Rocky",
            DiameterKm = 6779,
            LengthOfDayHours = 24.6,
            NumberOfMoons = 2,
            Description = "Mars is known as the red planet because of iron-rich dust on its surface."
        },
        new()
        {
            Name = "Jupiter",
            OrderFromSun = 5,
            PlanetType = "Gas giant",
            DiameterKm = 139820,
            LengthOfDayHours = 9.9,
            NumberOfMoons = 95,
            Description = "Jupiter is the largest planet in the solar system and has a giant storm called the Great Red Spot."
        },
        new()
        {
            Name = "Saturn",
            OrderFromSun = 6,
            PlanetType = "Gas giant",
            DiameterKm = 116460,
            LengthOfDayHours = 10.7,
            NumberOfMoons = 146,
            Description = "Saturn is famous for its bright ring system made of ice and rock."
        },
        new()
        {
            Name = "Uranus",
            OrderFromSun = 7,
            PlanetType = "Ice giant",
            DiameterKm = 50724,
            LengthOfDayHours = 17.2,
            NumberOfMoons = 28,
            Description = "Uranus rotates on its side, which makes its seasons very unusual."
        },
        new()
        {
            Name = "Neptune",
            OrderFromSun = 8,
            PlanetType = "Ice giant",
            DiameterKm = 49244,
            LengthOfDayHours = 16.1,
            NumberOfMoons = 16,
            Description = "Neptune is the farthest major planet from the Sun and has very strong winds."
        }
    };

    public IReadOnlyList<Planet> GetPlanets()
    {
        return Planets;
    }

    public Planet? GetPlanet(string name)
    {
        return Planets.FirstOrDefault(planet =>
            planet.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
