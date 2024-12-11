using Ical.Net;

class Schedule {
    private readonly List<Class> classes = [];
    
    public Schedule(Calendar calendar) {
        DateTime semesterStart = calendar.Events[0].Start.AsSystemLocal;
        DateTime fullWeekStart = semesterStart.AddDays(6 - (int) semesterStart.DayOfWeek);
        DateTime fullWeekEnd = fullWeekStart.AddDays(7);

        foreach (var evt in calendar.Events) {
            var eventStart = evt.Start.AsSystemLocal;
            var eventEnd = evt.End.AsSystemLocal;
            if (eventStart < fullWeekEnd && eventEnd >= fullWeekStart) {
                classes.Add(new Class(eventStart, eventEnd, Buildings.FromString(evt.Location.ToString()[..3]), int.Parse(evt.Location[4..])));
            }
        }
    }

    public List<Class> GetClasses() {
        return classes;
    }
}