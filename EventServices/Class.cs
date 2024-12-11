

class Class(DateTime startTime, DateTime endTime, Building location, int roomNumber) {
    public DateTime startTime = startTime;
    public DateTime endTime = endTime;
    public Building location = location;
    public int roomNumber = roomNumber;

    public Route CreateRoute(Class cls) {
        return new(location.Latitude, location.Longitude, cls.location.Latitude, cls.location.Longitude);
    }
}