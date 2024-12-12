public static class Buildings {
    public static readonly Building AGM = new Building("AGM", 43.81329566776566, -111.78313457712804);
    public static readonly Building AUS = new Building("AUS", 43.8157681429827, -111.78432512840953);
    public static readonly Building BEN = new Building("BEN", 43.81551281845149, -111.78317204339629);
    public static readonly Building CLK = new Building("CLK", 43.820244851535655, -111.781805131387);
    public static readonly Building CLM = new Building("CLM", 43.81610782443053, -111.78495746467836);
    public static readonly Building HIN = new Building("HIN", 43.81586639983394, -111.77990393342996);
     public static readonly Building KIM = new Building("KIM", 43.81710180082301, -111.78151013970248);
    public static readonly Building MCK = new Building("MCK", 43.819521116988945, -111.7824369923399);
    public static readonly Building RKS = new Building("RKS", 43.81481703079422, -111.78099008920391);
    public static readonly Building RIG = new Building("RIG", 43.817015358648256, -111.78441782271997);
    public static readonly Building ROM = new Building("ROM", 43.82022989231845, -111.78310697755614);
    public static readonly Building SMI = new Building("SMI", 43.819134161526904, -111.7814641850085);
    public static readonly Building SNO = new Building("SNO", 43.82130840506149, -111.783620608693);
    public static readonly Building SPO = new Building("SPO", 43.820847097196065, -111.78238890500523);
    public static readonly Building STC = new Building("STC", 43.81466645356304, -111.7844775878557);
    public static readonly Building TAY = new Building("TAY", 43.81693010696672, -111.78249435968654);

    public static readonly List<Building> AllBuildings = [
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

    public static Building FromString(string buildingName) {
        return AllBuildings.FirstOrDefault(b => b.Name.Equals(buildingName, StringComparison.OrdinalIgnoreCase)) ?? throw new ArgumentException($"Building with name '{buildingName}' does not exist.");
    }
}

public record Building(string Name, double Latitude, double Longitude);