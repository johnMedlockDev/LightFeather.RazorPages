using LightFeather.Domain.Entities;
using LightFeather.Infrastructure.Repositories.CommandRepositories.Bases;

namespace LightFeather.Infrastructure.Repositories.CommandRepositories.Interfaces;

public interface ISubmitSupervisorCommandRepository : ICommandRepositoryBase<SubmitSupervisorEntity,long>
{
}