﻿using Microsoft.EntityFrameworkCore;

namespace LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories.Bases;

public abstract class CommandRepositoryBase<TEntity, TId>(IDbContextFactory<LightFeatherDbContext> dbContextFactory) : ICommandRepositoryBase<TEntity, TId> where TEntity : class
{
    protected readonly IDbContextFactory<LightFeatherDbContext> _dbContextFactory = dbContextFactory;

    public virtual async Task AddAsync(TEntity entity)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        using var transaction = dbContext.Database.BeginTransaction();
        try
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        using var transaction = dbContext.Database.BeginTransaction();
        try
        {
            await dbContext.Set<TEntity>().AddRangeAsync(entities);
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public virtual async Task DeleteAsync(TId id)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        using var transaction = dbContext.Database.BeginTransaction();
        try
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        return await dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        using var transaction = dbContext.Database.BeginTransaction();
        try
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public virtual async Task UpdateRange(IEnumerable<TEntity> entities)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        using var transaction = dbContext.Database.BeginTransaction();
        try
        {
            dbContext.Set<TEntity>().UpdateRange(entities);
            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}