public static class Buildings {
    public static readonly Building STC = new Building("STC", 43.81466645356304, -111.7844775878557);
    public static readonly Building HIN = new Building("HIN", 43.81586639983394, -111.77990393342996);
    public static readonly Building ROM = new Building("ROM", 43.82022989231845, -111.78310697755614);
    public static readonly Building BEN = new Building("BEN", 43.81551281845149, -111.78317204339629);
    public static readonly Building SNO = new Building("SNO", 43.82130840506149, -111.783620608693);
    public static readonly Building TAY = new Building("TAY", 43.81693010696672, -111.78249435968654);
    public static readonly Building KIM = new Building("KIM", 43.81710180082301, -111.78151013970248);

    public static readonly List<Building> AllBuildings = [
        STC,
        HIN,
        ROM,
        BEN,
        SNO,
        TAY,
        KIM
    ];

    public static Building FromString(string buildingName) {
        return AllBuildings.FirstOrDefault(b => b.Name.Equals(buildingName, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException($"Building with name '{buildingName}' does not exist.");
    }
}

public record Building(string Name, double Latitude, double Longitude);