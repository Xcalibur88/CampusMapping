using System.Text;
using System.Text.Json;

class Route(double startLatitude, double startLongitude, double endLatitude, double endLongitude) {
    private readonly double startLatitude = startLatitude;
    private readonly double startLongitude = startLongitude;
    private readonly double endLatitude = endLatitude;
    private readonly double endLongitude = endLongitude;
    public string? geoJson;

    public bool IsComputed() {
        return geoJson != null;
    }

    public string GetGeoJson() {
        return geoJson;
    }
    
    public async Task SendRequestAsync() {
        string baseUrl = "http://localhost:8082/ors/v2/directions/foot-walking/geojson";
        StringContent content = new($"{{\"coordinates\": [[{startLongitude},{startLatitude}],[{endLongitude},{endLatitude}]]}}", Encoding.UTF8, "application/geo+json");
        
        using HttpClient client = new();
        HttpResponseMessage response = await client.PostAsync(baseUrl, content);

        if (response.IsSuccessStatusCode) {
            geoJson = await response.Content.ReadAsStringAsync();
            //File.WriteAllText("C:\\Users\\Elijah\\source\\repos\\CampusMapping\\wwwroot\\geojson.json", jsonResponse);
        } else {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }
}