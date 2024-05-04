using LightFeather.CodeChallenge.Domain.Entities;
using LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories.Bases;

namespace LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories.Interfaces;

public interface ISubmitSupervisorQueryRepository : IQueryRepositoryBase<SubmitSupervisorEntity, long>
{
}