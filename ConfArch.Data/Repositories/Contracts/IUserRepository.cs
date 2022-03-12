using ConfArch.Data.Entities;

namespace ConfArch.Data.Repositories.Contracts;

public interface IUserRepository
{
    Task<User?> GetByUsernameAndPassword(string username, string password);
    Task<User?> GetByGoogleId(string googleId);
}
