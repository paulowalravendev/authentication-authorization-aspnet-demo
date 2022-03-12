using ConfArch.Data.Models;

namespace ConfArch.Data.Repositories.Contracts;

public interface IProposalRepository
{
    Task<int> Add(ProposalModel model);
    Task<ProposalModel> Approve(long id);
    Task<List<ProposalModel>> GetAllForConference(long conferenceId);
}