namespace SolarSystem.Core;

public class Planet
{
    public required string Name { get; init; }
    public required int OrderFromSun { get; init; }
    public required string PlanetType { get; init; }
    public required int DiameterKm { get; init; }
    public required double LengthOfDayHours { get; init; }
    public required int NumberOfMoons { get; init; }
    public required string Description { get; init; }
}
