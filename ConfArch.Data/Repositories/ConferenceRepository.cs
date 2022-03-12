using ConfArch.Data.Entities;
using ConfArch.Data.Models;
using ConfArch.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data.Repositories;

public class ConferenceRepository : IConferenceRepository
{
    private readonly ConfArchDbContext _dbContext;

    public ConferenceRepository(ConfArchDbContext dbContext) => _dbContext = dbContext;

    public Task<int> Add(ConferenceModel model)
    {
        var entity = Conference.FromModel(model);
        _dbContext.Conferences.Add(entity);
        return _dbContext.SaveChangesAsync();
    }

    public Task<List<ConferenceModel>> GetAll() =>
        _dbContext.Conferences.Select(c => c.ToModel()).ToListAsync();

    public Task<Conference?> GetById(long id) =>
        _dbContext.Conferences.FirstOrDefaultAsync(c => c.Id == id);
}