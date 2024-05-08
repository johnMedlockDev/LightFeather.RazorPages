using LightFeather.Domain.Entities;
using LightFeather.Infrastructure.Repositories.QueryRepositories.Bases;
using LightFeather.Infrastructure.Repositories.QueryRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.Infrastructure.Repositories.QueryRepositories;

public class SubmitSupervisorQueryRepository(IDbContextFactory<LightFeatherDbContext> dbContextFactory) : QueryRepositoryBase<SubmitSupervisorEntity,long>(dbContextFactory), ISubmitSupervisorQueryRepository
{
}