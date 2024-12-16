using AutoMapper;
using DDD.Application.Dtos.Base;
using DDD.Application.Interfaces.Base;
using DDD.Domain.Entities.Base;

namespace DDD.Application.Services.Base;

public class ApplicationService<TEntity> : IApplicationService<TEntity> where TEntity : Entity
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    public ApplicationService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        //var entity = _mapper.Map<TEntity>(dto);
        await _unitOfWork.Repository<TEntity>().AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _unitOfWork.Repository<TEntity>().DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {

        var entities = await _unitOfWork.Repository<TEntity>().GetAllAsync();
        //var dtos = _mapper.Map<IEnumerable<TEntity>>(entities);
        return entities;
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
        //var dto = _mapper.Map<TEntity>(entity);
        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        //var entity = _mapper.Map<TEntity>(dto);
        await _unitOfWork.Repository<TEntity>().UpdateAsync(entity);

        await _unitOfWork.SaveChangesAsync();
    }
}
