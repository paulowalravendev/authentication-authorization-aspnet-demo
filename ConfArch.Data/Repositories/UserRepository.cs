using ConfArch.Data.Entities;
using ConfArch.Data.Extensions;
using ConfArch.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ConfArchDbContext _dbContext;

    public UserRepository(ConfArchDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User?> GetByUsernameAndPassword(string username, string password) =>
        _dbContext.Users.FirstOrDefaultAsync(u => u.Name == username && u.Password == password.Sha256());

    public Task<User?> GetByGoogleId(string googleId)
    {
        throw new NotImplementedException();
    }
}
