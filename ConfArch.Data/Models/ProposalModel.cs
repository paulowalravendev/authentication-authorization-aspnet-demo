namespace ConfArch.Data.Models;

public class ProposalModel : IModel
{
    public ProposalModel(long id, long conferenceId, string speaker, string title, bool approved)
    {
        Id = id;
        ConferenceId = conferenceId;
        Speaker = speaker;
        Title = title;
        Approved = approved;
    }

    public ProposalModel(long conferenceId)
    {
        ConferenceId = conferenceId;
    }

    public long Id { get; set; }
    public long ConferenceId { get; set; }
    public string Speaker { get; set; }
    public string Title { get; set; }
    public bool Approved { get; set; }
}
