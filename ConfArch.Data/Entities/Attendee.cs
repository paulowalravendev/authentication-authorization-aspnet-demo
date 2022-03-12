using System.ComponentModel.DataAnnotations;
using ConfArch.Data.Models;

namespace ConfArch.Data.Entities;

public class Attendee : IEntity
{
    public Attendee()
    {
        
    }
    public Attendee(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public Attendee(long id, long conferenceId, string name) : this()
    {
        Id = id;
        ConferenceId = conferenceId;
        Name = name;
    }

    public long Id { get; set; }
    public long ConferenceId { get; set; }
    public Conference? Conference { get; set; }
    [StringLength(250)] public string Name { get; set; } = null!;

    public static Attendee FromModel(AttendeeModel model) =>
        new Attendee(model.ConferenceId, model.Name);
}
