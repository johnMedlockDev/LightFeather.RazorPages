using LightFeather.Domain.Entities;
using LightFeather.Infrastructure.Repositories.QueryRepositories.Bases;

namespace LightFeather.Infrastructure.Repositories.QueryRepositories.Interfaces;

public interface ISubmitSupervisorQueryRepository : IQueryRepositoryBase<SubmitSupervisorEntity,long>
{
}