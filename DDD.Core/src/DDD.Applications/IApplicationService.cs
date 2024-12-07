namespace DDD.Application;

public interface IApplicationService<TDto> where TDto : ApplicationDto
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(Guid id);
    Task AddAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task DeleteAsync(Guid id);
}
