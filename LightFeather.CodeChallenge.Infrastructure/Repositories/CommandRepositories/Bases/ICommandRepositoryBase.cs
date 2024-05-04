namespace LightFeather.CodeChallenge.Infrastructure.Repositories.CommandRepositories.Bases;

public interface ICommandRepositoryBase<TEntity, T> where TEntity : class
{
    Task AddAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    Task DeleteAsync(T id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(T id);

    Task UpdateAsync(TEntity entity);
}