using DDD.Application.Dtos.Base;
using DDD.Domain.Entities.Base;

namespace DDD.Application.Interfaces.Base;

public interface IApplicationService<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}