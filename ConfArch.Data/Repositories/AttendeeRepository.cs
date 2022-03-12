using ConfArch.Data.Entities;
using ConfArch.Data.Models;
using ConfArch.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data.Repositories;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly ConfArchDbContext _dbContext;

    public AttendeeRepository(ConfArchDbContext dbContext) => _dbContext = dbContext;

    public Task<int> Add(AttendeeModel model)
    {
        var entity = Attendee.FromModel(model);
        _dbContext.Attendees.Add(entity);
        return _dbContext.SaveChangesAsync();
    }

    public Task<int> GetAttendeesTotal(long conferenceId) =>
        _dbContext.Attendees.CountAsync(a => a.ConferenceId == conferenceId);
}
