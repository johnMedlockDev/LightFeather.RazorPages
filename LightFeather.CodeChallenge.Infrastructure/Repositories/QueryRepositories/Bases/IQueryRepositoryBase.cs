namespace LightFeather.CodeChallenge.Infrastructure.Repositories.QueryRepositories.Bases;

public interface IQueryRepositoryBase<TEntity, T> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(T id);
}