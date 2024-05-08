using LightFeather.Domain.Entities;
using LightFeather.Infrastructure.Repositories.CommandRepositories.Bases;
using LightFeather.Infrastructure.Repositories.CommandRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.Infrastructure.Repositories.CommandRepositories;

public sealed class SubmitSupervisorCommandRepository(IDbContextFactory<LightFeatherDbContext> dbContextFactory) : CommandRepositoryBase<SubmitSupervisorEntity,long>(dbContextFactory), ISubmitSupervisorCommandRepository
{
}