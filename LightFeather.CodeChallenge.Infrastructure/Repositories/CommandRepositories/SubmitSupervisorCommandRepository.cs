﻿using LightFeather.CodeChallenge.Domain.Entities;
using LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories.Bases;
using LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories;

public sealed class SubmitSupervisorCommandRepository(IDbContextFactory<LightFeatherDbContext> dbContextFactory) : CommandRepositoryBase<SubmitSupervisorEntity, long>(dbContextFactory), ISubmitSupervisorCommandRepository
{
}