using LightFeather.CodeChallenge.Domain.Entities;
using LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories.Bases;
using LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories;

public class SubmitSupervisorQueryRepository(IDbContextFactory<LightFeatherDbContext> dbContextFactory) : QueryRepositoryBase<SubmitSupervisorEntity, long>(dbContextFactory), ISubmitSupervisorQueryRepository
{
}