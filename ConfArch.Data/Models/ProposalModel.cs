namespace ConfArch.Data.Models;

public class ProposalModel : IModel
{

    public ProposalModel()
    {
    }

    public ProposalModel(long conferenceId)
    {
        ConferenceId = conferenceId;
    }
    
    public ProposalModel(long id, long conferenceId, string speaker, string title, bool approved) : this(conferenceId)
    {
        Id = id;
        Speaker = speaker;
        Title = title;
        Approved = approved;
    }

    public long Id { get; set; }
    public long ConferenceId { get; set; }
    public string Speaker { get; set; }
    public string Title { get; set; }
    public bool Approved { get; set; }
}
