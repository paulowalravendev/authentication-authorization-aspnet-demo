namespace ConfArch.Data.Models;

public class ConferenceModel : IModel
{
    public ConferenceModel(string name, string location, DateTime start)
    {
        Name = name;
        Location = location;
        Start = start;
    }

    public ConferenceModel(long id, string name, string location, DateTime start, int attendeeCount) : this(name,
        location, start)
    {
        Id = id;
        AttendeeCount = attendeeCount;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Start { get; set; }
    public int AttendeeCount { get; set; }
}
