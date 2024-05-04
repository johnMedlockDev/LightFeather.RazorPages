using Microsoft.EntityFrameworkCore;

namespace LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories.Bases;

public abstract class QueryRepositoryBase<TEntity, TId>(IDbContextFactory<LightFeatherDbContext> dbContextFactory) : IQueryRepositoryBase<TEntity, TId> where TEntity : class
{
    protected readonly IDbContextFactory<LightFeatherDbContext> _dbContextFactory = dbContextFactory;

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync();
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        return await dbContext.Set<TEntity>().FindAsync(id);
    }
}