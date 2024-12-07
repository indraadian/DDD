using AutoMapper;
using DDD.Domain;

namespace DDD.Application;

public class ApplicationService<TDto> : IApplicationService<TDto> where TDto : ApplicationDto
{
    protected readonly IRepository<Entity, Guid> _repository;
    protected readonly IMapper _mapper;

    public ApplicationService(IRepository<Entity, Guid> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task AddAsync(TDto dto)
    {
        var entity = this._mapper.Map<Entity>(dto);
        await _repository.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public virtual async Task<IEnumerable<TDto>> GetAllAsync()
    {

        var entities = await _repository.GetAllAsync();
        var dtos = this._mapper.Map<IEnumerable<TDto>>(entities);
        return dtos;
    }

    public virtual async Task<TDto> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        var dto = this._mapper.Map<TDto>(entity);
        return dto;
    }

    public virtual async Task UpdateAsync(TDto dto)
    {
        var entity = this._mapper.Map<Entity>(dto);
        await _repository.UpdateAsync(entity);
    }
}
