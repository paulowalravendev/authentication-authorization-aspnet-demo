using ConfArch.Data.Entities;
using ConfArch.Data.Models;

namespace ConfArch.Data.Repositories.Contracts;

public interface IConferenceRepository
{
    Task<int> Add(ConferenceModel model);
    Task<List<ConferenceModel>> GetAll();
    Task<Conference?> GetById(long id);
}