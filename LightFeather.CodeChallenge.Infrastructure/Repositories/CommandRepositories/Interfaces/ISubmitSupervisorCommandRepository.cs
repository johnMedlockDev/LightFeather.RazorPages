using LightFeather.CodeChallenge.Domain.Entities;
using LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories.Bases;

namespace LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories.Interfaces;

public interface ISubmitSupervisorCommandRepository : ICommandRepositoryBase<SubmitSupervisorEntity, long>
{
}