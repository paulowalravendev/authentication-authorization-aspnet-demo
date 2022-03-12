using ConfArch.Data.Models;

namespace ConfArch.Data.Entities;

public class Proposal : IEntity
{
    public Proposal(long conferenceId, string speaker, string title, bool approved)
    {
        ConferenceId = conferenceId;
        Speaker = speaker;
        Title = title;
        Approved = approved;
    }

    public Proposal(long id, long conferenceId, string speaker, string title)
    {
        Id = id;
        ConferenceId = conferenceId;
        Speaker = speaker;
        Title = title;
    }

    public long Id { get; set; }
    public long ConferenceId { get; set; }
    public Conference? Conference { get; set; }
    public string Speaker { get; set; }
    public string Title { get; set; }
    public bool Approved { get; set; }

    public ProposalModel ToModel() => new(Id, ConferenceId, Speaker, Title, Approved);

    public static Proposal FromModel(ProposalModel model) =>
        new(model.ConferenceId, model.Speaker, model.Title, model.Approved);
}
