using ConfArch.Data.Repositories;
using ConfArch.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ConfArch.Data;

public static class DataServiceCollectionsExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddScoped<IAttendeeRepository, AttendeeRepository>()
            .AddScoped<IConferenceRepository, ConferenceRepository>()
            .AddScoped<IProposalRepository, ProposalRepository>()
            .AddScoped<IUserRepository, UserRepository>();

    public static IServiceCollection AddConfArchDbContext(this IServiceCollection services, string connectionString,
        Action<SqlServerDbContextOptionsBuilder>? sqlServerOptionsAction) =>
        services.AddSqlServer<ConfArchDbContext>(connectionString, sqlServerOptionsAction);
}
