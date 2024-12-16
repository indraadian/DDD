using DDD.Application.Interfaces.Base;
using DDD.Domain.Entities.Base;
using DDD.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Persistence.Base;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly SchoolDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(SchoolDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        await _dbSet.AddAsync(entity);
        
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
        
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        
        return true;
    }
}
