using DDD.Domain.Entities.Base;

namespace DDD.Application.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
    Task<int> SaveChangesAsync();
}
