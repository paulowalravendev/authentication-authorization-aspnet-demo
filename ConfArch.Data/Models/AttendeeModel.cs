namespace ConfArch.Data.Models;

public class AttendeeModel : IModel
{
    public AttendeeModel(long conferenceId, string name)
    {
        ConferenceId = conferenceId;
        Name = name;
    }

    public long ConferenceId { get; set; }
    public string Name { get; set; }
    public long Id { get; set; }
}
