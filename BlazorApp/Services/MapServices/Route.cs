using System.Text;

class Route(Location startLocation, Location endLocation) {

    private readonly Location startLocation = startLocation;
    private readonly Location endLocation = endLocation;

    private string? geoJson;

    public bool IsComputed() {
        return geoJson != null;
    }

    public string GetGeoJson() {
        #pragma warning disable CS8603
        return geoJson;
        #pragma warning restore CS8603
    }
    
    public async Task SendRequestAsync() {
        string baseUrl = "http://localhost:8082/ors/v2/directions/foot-walking/geojson";
        StringContent content = new($"{{\"coordinates\": [[{startLocation.Longitude},{startLocation.Latitude}],[{endLocation.Longitude},{endLocation.Latitude}]]}}", Encoding.UTF8, "application/geo+json");
        
        using HttpClient client = new();
        HttpResponseMessage response = await client.PostAsync(baseUrl, content);

        if (response.IsSuccessStatusCode) {
            geoJson = await response.Content.ReadAsStringAsync();
        } else {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }

    public double[] GetStartLatLng() {
        return [startLocation.Latitude, startLocation.Longitude];
    }

    public double[] GetEndLatLng() {
        return [endLocation.Latitude, endLocation.Longitude];
    }

    public Location GetStartLocation() {
        return startLocation;
    }

     public Location GetEndLocation() {
        return endLocation;
    }
}