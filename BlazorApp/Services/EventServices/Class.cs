

class Class(DateTime startTime, DateTime endTime, Location location, int roomNumber) {
    public DateTime startTime = startTime;
    public DateTime endTime = endTime;
    public Location location = location;
    public int roomNumber = roomNumber;

    public Route CreateRoute(Class cls) {
        return new(location, cls.location);
    }
}