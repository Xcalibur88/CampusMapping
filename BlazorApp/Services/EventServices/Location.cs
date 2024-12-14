public static class Locations {
    public static readonly Location AGM = new("AGM", 43.81329566776566, -111.78313457712804);
    public static readonly Location AUS = new("AUS", 43.8157681429827, -111.78432512840953);
    public static readonly Location BEN = new("BEN", 43.81551281845149, -111.78317204339629);
    public static readonly Location CLK = new("CLK", 43.820244851535655, -111.781805131387);
    public static readonly Location CLM = new("CLM", 43.81610782443053, -111.78495746467836);
    public static readonly Location HIN = new("HIN", 43.81586639983394, -111.77990393342996);
    public static readonly Location KIM = new("KIM", 43.81710180082301, -111.78151013970248);
    public static readonly Location MCK = new("MCK", 43.819521116988945, -111.7824369923399);
    public static readonly Location RKS = new("RKS", 43.81481703079422, -111.78099008920391);
    public static readonly Location RIG = new("RIG", 43.817015358648256, -111.78441782271997);
    public static readonly Location ROM = new("ROM", 43.82022989231845, -111.78310697755614);
    public static readonly Location SMI = new("SMI", 43.819134161526904, -111.7814641850085);
    public static readonly Location SNO = new("SNO", 43.82130840506149, -111.783620608693);
    public static readonly Location SPO = new("SPO", 43.820847097196065, -111.78238890500523);
    public static readonly Location STC = new("STC", 43.81466645356304, -111.7844775878557);
    public static readonly Location TAY = new("TAY", 43.81693010696672, -111.78249435968654);

    public static readonly List<Location> AllLocations = [
        AGM,
        AUS,
        BEN,
        CLK,
        CLM,
        HIN,
        KIM,
        MCK,
        RKS,
        RIG,
        ROM,
        SMI,
        SNO,
        SPO,
        STC,
        TAY,
    ];

    public static Location FromString(string buildingName) {
        return AllLocations.FirstOrDefault(b => b.Name.Equals(buildingName, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException($"Building with name '{buildingName}' does not exist.");
    }
}

public record Location(string Name, double Latitude, double Longitude);