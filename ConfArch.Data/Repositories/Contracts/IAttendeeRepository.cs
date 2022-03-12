using ConfArch.Data.Models;

namespace ConfArch.Data.Repositories.Contracts;

public interface IAttendeeRepository
{
    Task<int> Add(AttendeeModel model);
    Task<int> GetAttendeesTotal(long conferenceId);
}
