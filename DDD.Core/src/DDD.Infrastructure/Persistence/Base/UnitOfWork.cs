using DDD.Application.Interfaces.Base;
using DDD.Domain.Entities.Base;
using DDD.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Persistence.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly SchoolDbContext _context;
    private readonly Dictionary<string, object> _repositories;

    public UnitOfWork(SchoolDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<string, object>();
    }

    public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
    {
        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryInstance = new Repository<TEntity>(_context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IRepository<TEntity>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
