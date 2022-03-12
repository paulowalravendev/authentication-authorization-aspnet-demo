using System.ComponentModel.DataAnnotations;
using ConfArch.Data.Models;

namespace ConfArch.Data.Entities;

public class Conference : IEntity
{
    public Conference()
    {
    }

    public Conference(string name, string location) : this()
    {
        Name = name;
        Location = location;
        Start = DateTime.Now;
    }

    public Conference(long id, string name, string location, DateTime start) : this(name, location)
    {
        Id = id;
        Start = start;
    }

    public long Id { get; set; }
    [StringLength(250)] public string Name { get; set; } = null!;
    public DateTime Start { get; set; }
    [StringLength(250)] public string Location { get; set; } = null!;
    public List<Attendee>? Attendees { get; set; }

    public ConferenceModel ToModel() =>
        new(Id, Location, Name, Start, Attendees?.Count ?? 0);

    public static Conference FromModel(ConferenceModel model) =>
        new(model.Id, model.Name, model.Location, model.Start);
}
