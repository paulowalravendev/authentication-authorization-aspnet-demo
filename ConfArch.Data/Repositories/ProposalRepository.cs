using ConfArch.Data.Entities;
using ConfArch.Data.Models;
using ConfArch.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data.Repositories;

public class ProposalRepository : IProposalRepository
{
    private readonly ConfArchDbContext _dbContext;

    public ProposalRepository(ConfArchDbContext dbContext) => _dbContext = dbContext;

    public Task<int> Add(ProposalModel model)
    {
        var entity = Proposal.FromModel(model);
        _dbContext.Proposals.Add(entity);
        return _dbContext.SaveChangesAsync();
    }

    public async Task<ProposalModel> Approved(long id)
    {
        var proposal = await _dbContext.Proposals.FirstOrDefaultAsync(p => p.Id == id);
        // TODO: Improve this exception
        if (proposal is null) throw new Exception("Proposal not found");
        proposal.Approved = true;
        _dbContext.Proposals.Update(proposal);
        await _dbContext.SaveChangesAsync();
        return proposal.ToModel();
    }

    public Task<List<ProposalModel>> GetAllForConference(long conferenceId) =>
        _dbContext.Proposals.Where(p => p.ConferenceId == conferenceId).Select(p => p.ToModel()).ToListAsync();
}
